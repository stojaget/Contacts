using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.BusinessEntities.Collections
{
    /// <summary>
    /// The ContactCollection class is designed to work with lists of instances of ContactPerson.
    /// </summary>
    public class ContactCollection : BusinessCollectionBase<Contact>
    {
        /// <summary>
		/// Initializes a new instance of the ContactCollection class.
		/// </summary>
		public ContactCollection()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ContactCollection class.
		/// </summary>
		public ContactCollection(IList<Contact> initialList)
			: base(initialList)
		{
		}
    }
}
