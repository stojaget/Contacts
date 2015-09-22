using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Transactions;
using System.Security;
using System.Security.Permissions;
using Kontakti.BusinessEntities.Collections;
using Kontakti.Validation;
using Kontakti.BusinessEntities;
using Kontakti.DAL;
using Kontakti.BusinessEntities.SearchCriteria;

namespace Kontakti.BLL
{

    public class ContactManager
    {

        #region Public Methods


        /// <summary>
        /// Gets a list with all Contact objects in the database based on the custom search criteria.
        /// </summary>

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static List<Contact> GetList(ContactCriteria contactCriteria)
        {

            return ContactDao.GetList(contactCriteria);
        }

        /// <summary>
        /// Gets a list with paged Contact objects in the database.
        /// </summary>

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static List<Contact> GetPagedList(int pageIndex, int pageSize)
        {
            List<Kontakti.BusinessEntities.Contact> myCollection = ContactDao.GetList(pageIndex, pageSize);

            return myCollection;
        }


        /// <summary>
        /// Gets a list with all or paged and sorted Contact objects in the database, filtered by first or last name.
        /// </summary>

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static List<Contact> GetPagedList(int pageIndex, int pageSize, string sortOrd, string sortExp, string firstName, string lastName)
        {

            List<Kontakti.BusinessEntities.Contact> myCollection = ContactDao.GetListSorted(pageIndex, pageSize, sortOrd, sortExp, firstName, lastName);

            return myCollection;
        }

        /// <summary>
        /// Gets the number of records in the database.
        /// </summary>
        
        public static int SelectCountForGetList()
        {
            return ContactDao.SelectCountForGetList();
        }

        /// <summary>
        /// Gets a single Contact from the database without its contact data.
        /// </summary>
      
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Contact GetItem(int id)
        {
            return ContactDao.GetItem(id);
        }



        /// <summary>
        /// Saves a contact person in the database.
        /// </summary>
        /// <param name="myContact">The Contact instance to save.</param>
        /// <returns>The new ID if the Contact is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static bool Save(Contact myContact)
        {
            if (!myContact.Validate())
            {
                throw new InvalidSaveOperationException("Can't save an invalid contact.");
            }

            int ContactId = ContactDao.Save(myContact);

            //  Assign the Contact its new or existing ID.
            myContact.Id = ContactId;

            return true;
        }


        /// <summary>
        /// Deletes a contact person from the database.
        /// </summary>
        /// <param name="id">The id of the contact to delete.</param>
        /// <returns>Returns <c>true</c> when the object was deleted successfully, or <c>false</c> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(int id)
        {
            try
            {
                // PrincipalPermission myPrincipalPermission = new PrincipalPermission(null, "Admin");
                // myPrincipalPermission.Demand();
                return ContactDao.Delete(id);
            }
            catch (Exception)
            {
                // TODO: Log error here
                throw;
            }
        }

        #endregion

        #region IComparable

        /// <summary>
        /// to allow Contact objects to be sorted.
        /// </summary>
        private class ContactComparer : IComparer<Contact>
        {
            private string _sortColumn;
            private bool _reverse;
            /// <summary>
            /// Constructor for the ContactComparer class that expects the property of the Contact class to sort on.
            /// </summary>
            /// <param name="sortExpression">Contains the property of the Contact class to sort on. Append [space]desc to sort in reversed order.</param>
            public ContactComparer(string sortExpression)
            {
                if (string.IsNullOrEmpty(sortExpression))
                {
                    sortExpression = "Id desc";
                }
                _reverse = sortExpression.ToUpperInvariant().EndsWith(" desc", StringComparison.OrdinalIgnoreCase);
                if (_reverse)
                {
                    _sortColumn = sortExpression.Substring(0, sortExpression.Length - 5);
                }
                else
                {
                    _sortColumn = sortExpression;
                }
            }

            /// <summary>
            /// Compares two instances of Contact.
            /// </summary>
            /// <param name="x">The first side Contact object.</param>
            /// <param name="y">The other side Contact object.</param>
            public int Compare(Contact x, Contact y)
            {
                int retVal = 0;
                switch (_sortColumn.ToUpperInvariant())
                {
                    case "ID":
                        retVal = x.Id.CompareTo(y.Id);
                        break;
                    case "FIRSTNAME":
                        retVal = string.Compare(x.FirstName, y.FirstName, StringComparison.OrdinalIgnoreCase);
                        break;

                    case "LASTNAME":
                        retVal = string.Compare(x.LastName, y.LastName, StringComparison.OrdinalIgnoreCase);
                        break;

                    case "DATECREATED":
                        retVal = DateTime.Compare(x.DateCreated, y.DateCreated);
                        break;
                    case "PHONE":
                        retVal = x.Phone.CompareTo(y.Phone);
                        break;
                    case "EMAIL":
                        retVal = x.Email.CompareTo(y.Email);
                        break;
                }
                int _reverseInt = 1;
                if ((_reverse))
                {
                    _reverseInt = -1;
                }
                return (retVal * _reverseInt);
            }
        }
        #endregion
    }
}
