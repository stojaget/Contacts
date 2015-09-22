using Kontakti.BusinessEntities;
using Kontakti.BusinessEntities.Collections;
using Kontakti.BusinessEntities.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.DAL
{
    // currently not used
   public interface IContactDao
    {
       Contact GetItem(int id);
       ContactCollection GetList(string sidx, string sord, int page, int rows);
       ContactCollection GetList(ContactCriteria ContactCriteria);
       int SelectCountForGetList();
       int Save(Contact myContact);
       bool Delete(int id);
    }
}
