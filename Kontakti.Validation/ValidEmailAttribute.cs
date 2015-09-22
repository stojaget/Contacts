using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.Validation
{
    /// <summary>
    /// The ValidEmailAttribute class allows you to make sure that a string value contains a valid e-mail address.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ValidEmailAttribute : ValidationAttribute
    {
       
        public override bool IsValid(object item)
        {
            string tempValue = item as string;
            if (string.IsNullOrEmpty(tempValue))
            {
                return true;
            }
            return (tempValue).Contains("@");
        }
    }
}
