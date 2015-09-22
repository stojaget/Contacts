using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.Validation
{
    /// <summary>
    /// The BrokenRule class provides information about the broken rules of validators.
    /// </summary>
    [Serializable]
    public class BrokenRule
    {
        #region Private Variables

        private string _propertyName = string.Empty;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the BrokenRule class.
        /// </summary>
        
        public BrokenRule(string propertyName, string message)
        {
            _propertyName = propertyName;
            Message = message;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the error message associated with the broken rule.
        /// </summary>
       
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the name of the property that caused the rule to be broken.
        /// </summary>
        
        public string PropertyName
        {
            get
            {
                return _propertyName;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                _propertyName = value;
            }
        }
        #endregion

        #region Public Methods

       
        public override string ToString()
        {
            return string.Format("{0}: {1}", _propertyName, Message);
        }
        #endregion
    }
}
