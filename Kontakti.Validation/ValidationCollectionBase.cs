using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.Validation
{
    /// <summary>
    /// The ValidationCollectionBase class serves as the base class for collections like BusinessCollectionBase.
    /// The entire collection class provides validation by checking the validity of the ValidationBase
    /// instances in its Items collection.
    /// </summary>

    public abstract class ValidationCollectionBase<T> : Collection<T> where T : ValidationBase
    {
        /// <summary>
        /// Initializes a new instance of the ValidationCollection class.
        /// </summary>
        public ValidationCollectionBase() : base(new List<T>()) { }

        /// <summary>
        /// Initializes a new instance of the ValidationCollection class and populates it with the initial list.
        /// </summary>
        public ValidationCollectionBase(IList<T> initialList) : base(initialList) { }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
     
        public virtual bool Validate()
        {
            foreach (T item in this)
            {
                if (!item.Validate())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
