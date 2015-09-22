using Kontakti.BusinessEntities;
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
    internal class Helpers
    {
        const string idParamName = "@id";
      

        internal static void SetSaveParameters(SqlCommand command, BusinessBase businessBase)
        {
            DbParameter idParam = command.CreateParameter();
            idParam.DbType = DbType.Int32;
            idParam.Direction = ParameterDirection.InputOutput;
            idParam.ParameterName = idParamName;
            if (businessBase.Id == 0)
            {
                idParam.Value = DBNull.Value;
            }
            else
            {
                idParam.Value = businessBase.Id;
            }
            command.Parameters.Add(idParam);

            DbParameter returnValue = command.CreateParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(returnValue);
        }

       

        internal static int GetBusinessBaseId(SqlCommand command)
        {
            return (int)command.Parameters[idParamName].Value;
        }
    }
}
