using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Kontakti.Validation
{
    /// <summary>
    /// The BrokenRulesCollection is designed to hold items 
    /// </summary>
    [Serializable]
    public class BrokenRulesCollection : Collection<BrokenRule>
    {
        #region Constructors

       
        internal BrokenRulesCollection(IList<BrokenRule> myList)
            : base(myList)
        { }

        
        public BrokenRulesCollection()
        { }


        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a BrokenRulesCollection with the rules for the specified property name.
        /// </summary>
        
        public BrokenRulesCollection FindByPropertyName(string propertyName)
        {
            return new BrokenRulesCollection((from rule in this
                                              where rule.PropertyName.ToUpperInvariant() == propertyName.ToUpperInvariant()
                                              select rule).ToList<BrokenRule>());
        }

        /// <summary>
        /// Returns a BrokenRulesCollection with the rules that contain (a part) of the specified message..
        /// </summary>
        /// <param name="message">The (case insensitive) part of the message to search for.</param>
        /// <returns>A BrokenRulesCollection containing the rules that match the specified message.</returns>
        public BrokenRulesCollection FindByMessage(string message)
        {
            return new BrokenRulesCollection((from rule in this
                                              where rule.Message.ToUpperInvariant().Contains(message.ToUpperInvariant())
                                              select rule).ToList<BrokenRule>());
        }

        /// <summary>
        /// Creates a new BrokenRule instance and adds it to the inner list.
        /// </summary>
        /// <param name="message">The validation message associated with the broken rule.</param>
        public void Add(string message)
        {
            Add(new BrokenRule(string.Empty, message));
        }

        /// <summary>
        /// Creates a new BrokenRule instance and adds it to the inner list.
        /// </summary>
        /// <param name="propertyName">The name of the property that caused the rule to be broken. Can be left empty.</param>
        /// <param name="message">The validation message associated with the broken rule.</param>
        public void Add(string propertyName, string message)
        {
            Add(new BrokenRule(propertyName, message));
        }

     
        public override string ToString()
        {
            StringBuilder myStringBuilder = new StringBuilder();
            foreach (BrokenRule item in this)
            {
                myStringBuilder.Append(string.Format("{0}\r\n", item.ToString()));
            }
            return myStringBuilder.ToString();
        }



        #endregion
    }
}
