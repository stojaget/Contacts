using Kontakti.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.BusinessEntities
{
   public class Contact: BusinessBase
    {
       	#region Constructor(s)

		/// <summary>
		/// Initializes a new instance of the contact class.
		/// </summary>
		public Contact()
		{
			
		}

		#endregion

		#region Public Properties

		
		[DataObjectFieldAttribute(true, true, false)]
		public override int Id { get; set; }

		
		[NotNullOrEmpty(Key = "FirstNameNotEmpty")]
		public string FirstName { get; set; }

		
		[NotNullOrEmpty(Key = "LastNameNotEmpty")]
		public string LastName { get; set; }

        
        [NotNullOrEmpty(Key = "PhoneNumberNotEmpty")]
        public string Phone { get; set; }

        
        [NotNullOrEmpty(Key = "EmailNotEmpty")]
        [ValidEmail(Key = "EmailNotValid")]
        public string Email { get; set; }

		
		public DateTime DateCreated { get; set; }

       /// <summary>
       /// helper for counting records
       /// </summary>
        public int RecordCount { get; set; }

		
		/// Returns <c>true</c> if the instance is valid, <c>false</c> otherwise.
		/// </returns>
		public override bool Validate()
		{
			bool baseValid = base.Validate();
			
			return baseValid;
		}
		#endregion
    }
}
