using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.BusinessEntities.SearchCriteria
{
    /// <summary>
    /// A simple criteria class used to search for contact instances.
    /// </summary>
   public class ContactCriteria
    {
      
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
    }
}
