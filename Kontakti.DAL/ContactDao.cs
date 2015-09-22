using Kontakti.BusinessEntities;
using Kontakti.BusinessEntities.Collections;
using Kontakti.BusinessEntities.SearchCriteria;
using Kontakti.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.DAL
{
    /// <summary>
    /// responsible for interacting with the database to retrieve and store information
    /// </summary>
    public static class ContactDao 
    {
        #region Public Methods

        /// <summary>Gets an instance of Contact from the underlying datasource.</summary>
        /// <param name="id">The unique ID of the Contact in the database.</param>
        /// <returns>An Contact when the ID was found in the database, or null otherwise.</returns>
        public static  Contact GetItem(int id)
        {
            try
            {
                Contact myContact = null;
                using (SqlConnection myConnection = new SqlConnection(AppConfig.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("sprocContactGet", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@id", id);

                        myConnection.Open();
                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                myContact = FillDataRecord(myReader);
                            }
                            myReader.Close();
                        }
                    }
                    myConnection.Close();
                }
                return myContact;
            }
            catch (Exception ex)
            {

                throw new DataAccessException(Exceptions.EX01, ex);
            }

        }

        /// <summary>Returns a list with Contact objects.</summary>
       
        public static List<Contact> GetList(int pageIndex, int size)
        {
            try
            {
                List<Contact> tempList = new List<Contact>();
                using (SqlConnection myConnection = new SqlConnection(AppConfig.ConnectionString))
                {
                  
                      using (SqlCommand myCommand = new SqlCommand("sprocContactGetContacts", myConnection))
                {

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@PageIndex", pageIndex);
                    myCommand.Parameters.AddWithValue("@PageSize", size);
                    myCommand.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    myCommand.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                        
                            if (myReader.HasRows)
                            {
                               // tempList = new List<Contact>();
                                while (myReader.Read())
                                {
                                    
                                    tempList.Add(FillDataRecord(myReader));
                                }
                            
                            myReader.Close();
                        }
                    myConnection.Close();
                   
                   
                }
            
                }
                return tempList;
            }
            catch (Exception ex)
            {

                throw new DataAccessException(Exceptions.EX01, ex);
            }

        }

        /// <summary>Returns a list with Contact objects.</summary>
       
        public static List<Contact> GetListSorted(int pageIndex, int size, string sortOrd, string sortExp, string firstName, string lastName)
        {
           
            try
            {
                List<Contact> tempList = new List<Contact>();
                using (SqlConnection myConnection = new SqlConnection(AppConfig.ConnectionString))
                {

                    using (SqlCommand myCommand = new SqlCommand("sprocContactGetContactsSorted", myConnection))
                    {

                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@PageIndex", pageIndex);
                        myCommand.Parameters.AddWithValue("@PageSize", size);
                        myCommand.Parameters.AddWithValue("@SortOrderBy", sortOrd);
                        myCommand.Parameters.AddWithValue("@SortColumnName", sortExp);
                        myCommand.Parameters.AddWithValue("@firstName", firstName);
                        myCommand.Parameters.AddWithValue("@lastName", lastName);
                        myCommand.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                        myCommand.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                        myConnection.Open();
                        SqlDataReader myReader = myCommand.ExecuteReader();

                        if (myReader.HasRows)
                        {
                            // tempList = new List<Contact>();
                            while (myReader.Read())
                            {

                                tempList.Add(FillDataRecord(myReader));
                            }

                            myReader.Close();
                        }
                        myConnection.Close();


                    }

                }
                return tempList;
            }
            catch (Exception ex)
            {

                throw new DataAccessException(Exceptions.EX01, ex);
            }

        }

        /// <summary>
        /// This method lets you search for specific contact people based on the search criteria passed in.
        /// </summary>
        /// <param name="ContactCriteria">The criteria to search for.</param>
        public static List<Contact> GetList(ContactCriteria ContactCriteria)
        {
            try
            {
                List<Contact> tempList = new List<Contact>();
                using (SqlConnection myConnection = new SqlConnection(AppConfig.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("sprocContactSearch", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        if (!string.IsNullOrEmpty(ContactCriteria.FirstName))
                        {
                            myCommand.Parameters.AddWithValue("@firstName", ContactCriteria.FirstName);
                        }
                        if (!string.IsNullOrEmpty(ContactCriteria.LastName))
                        {
                            myCommand.Parameters.AddWithValue("@lastName", ContactCriteria.LastName);
                        }


                        myConnection.Open();
                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {
                            if (myReader.HasRows)
                            {
                                tempList = new List<Contact>();
                                while (myReader.Read())
                                {
                                    tempList.Add(FillDataRecord(myReader));
                                }
                            }
                            myReader.Close();
                        }
                    }
                }
                return tempList;
            }
            catch (Exception ex)
            {

                throw new DataAccessException(Exceptions.EX01, ex);
            }

        }

        /// <summary>
        /// Returns the number of contact people in the database.
        /// </summary>
        public static int SelectCountForGetList()
        {
            using (SqlConnection myConnection = new SqlConnection(AppConfig.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("sprocContactSelectList", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    DbParameter idParam = myCommand.CreateParameter();
                    idParam.DbType = DbType.Int32;
                    idParam.Direction = ParameterDirection.InputOutput;
                    idParam.ParameterName = "@recordCount";
                    idParam.Value = 0;
                    myCommand.Parameters.Add(idParam);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    return (int)myCommand.Parameters["@recordCount"].Value;
                }
            }
        }



        /// <summary>Saves a contact person in the database.</summary>
        /// <param name="myContact">The Contact instance to save.</param>
        /// <returns>The new ID if the Contact is new in the database or the existing ID when an item was updated.</returns>
        public static int Save(Contact myContact)
        {
            if (!myContact.Validate())
            {
                throw new InvalidSaveOperationException("Can't save a contact in an Invalid state.");
            }
            try
            {
                int result = 0;
                using (SqlConnection myConnection = new SqlConnection(AppConfig.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("sprocContactInsertUpdate", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@firstName", myContact.FirstName);
                        myCommand.Parameters.AddWithValue("@lastName", myContact.LastName);
                        myCommand.Parameters.AddWithValue("@phone", myContact.Phone);
                        myCommand.Parameters.AddWithValue("@email", myContact.Email);
                        myCommand.Parameters.AddWithValue("@dateCreated", myContact.DateCreated);
                       

                        Helpers.SetSaveParameters(myCommand, myContact);

                        myConnection.Open();
                        int numberOfRecordsAffected = myCommand.ExecuteNonQuery();
                        if (numberOfRecordsAffected == 0)
                        {
                            throw new DBConcurrencyException("Can't update contact as it has been updated by someone else");
                        }


                        result = Helpers.GetBusinessBaseId(myCommand); 
                    }
                    myConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {

                throw new DataAccessException(Exceptions.EX01, ex);
            }

        }

        /// <summary>Deletes a contact person from the database.</summary>
        /// <param name="id">The ID of the contact person to delete.</param>
        
        public static bool Delete(int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(AppConfig.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("sprocContactDelete", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@id", id);
                        myConnection.Open();
                        result = myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                return result > 0;
            }
            catch (Exception ex)
            {

                throw new DataAccessException(Exceptions.EX01, ex);
            }

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes a new instance of the Contact class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static Contact FillDataRecord(IDataRecord myDataRecord)
        {
            Contact myContact = new Contact();

            myContact.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
            myContact.FirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("FirstName"));

            myContact.LastName = myDataRecord.GetString(myDataRecord.GetOrdinal("LastName"));
            myContact.Phone = myDataRecord.GetString(myDataRecord.GetOrdinal("Phone"));
            myContact.Email = myDataRecord.GetString(myDataRecord.GetOrdinal("Email"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DateCreated")))
            {
                myContact.DateCreated = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DateCreated"));
            }
              
            return myContact;
        }
        #endregion
    }
}
