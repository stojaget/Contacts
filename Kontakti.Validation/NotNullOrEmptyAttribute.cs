using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.Validation
{
    /// <summary>
    /// The NotNullOrEmptyAttribute class allows you to make sure that a string value is not null or an empty string.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NotNullOrEmptyAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines whether the value of the underlying property
        /// is not null or an empty string.
        /// </summary>
       
        public override bool IsValid(object item)
        {
            if (item is string)
            {
                return !string.IsNullOrEmpty(item as String);
            }
            return item != null;
        }
    }
}
