using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.DAL
{
    [Serializable]
  public class DataAccessException: Exception
    {
        public DataAccessException(string message) : base(message) { }

        public DataAccessException(string message, Exception inner) : base(message, inner) { }
    }
}
