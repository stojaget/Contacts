using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.Validation
{
    /// <summary>
    /// The ValidationAttribute class is the base class for all validation attributes that can be applied to BO properties
    /// in order to define business validation rules.
    /// </summary>
  
    public abstract class ValidationAttribute : Attribute
    {
        #region Private Variables

        private string _key;
        private string _message;

        #endregion

        /// <summary>
        /// Determines whether the value of the underlying property
        /// is valid according to the validation rule.
        /// </summary>
      
        public abstract bool IsValid(object item);

        /// <summary>
        /// Gets the validation message associated with this validation.
        /// </summary>
       
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (!string.IsNullOrEmpty(_key))
                {
                    throw new ArgumentException("Can't set Message when Key has already been set.");
                }
                _message = value;
            }
        }

        /// <summary>
        /// Gets the the globalization key associated with this validation.
        /// </summary>
       
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                if (!string.IsNullOrEmpty(_message))
                {
                    throw new ArgumentException("Can't set Key when Message has already been set.");
                }
                _key = value;
            }
        }
    }
}
