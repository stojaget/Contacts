using Kontakti.BusinessEntities.Localization;
using Kontakti.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.BusinessEntities
{
    /// <summary>
    /// The BusinessBase class serves as the base class for all business entities in the Kontakti.BusinessEntities namespace.
    /// Since it inherits from ValidationBase, it provides validation behavior to its child classes.
    /// </summary>
    public abstract class BusinessBase : ValidationBase
    {
        /// <summary>
        /// The ID of the BusinessBase instance in the database.
        /// </summary>
        public abstract int Id { get; set; }

       
        public static ResourceManager ResourceManager { get; set; }

        /// <summary>
        /// Gets the localized validation message based on the message key.
        /// </summary>
        /// <param name="key">The translation key of the validation message.</param>
        protected override string GetValidationMessage(string key)
        {
            string tempValue;
            if (ResourceManager != null)
            {
                tempValue = ResourceManager.GetString(key);
            }
            else
            {
                tempValue = string.Empty;
            }
            if (string.IsNullOrEmpty(tempValue))
            {
                tempValue = General.ResourceManager.GetString(key);
            }
            return tempValue;
        }
    }
}
