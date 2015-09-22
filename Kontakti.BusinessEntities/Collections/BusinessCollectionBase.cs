using Kontakti.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakti.BusinessEntities.Collections
{
    /// <summary>
    ///  serve as the base class for all main business entity collections.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BusinessCollectionBase<T> : ValidationCollectionBase<T> where T : ValidationBase
    {
        /// <summary>
        /// Initializes a new instance of the BusinessCollectionBase class.
        /// </summary>
        public BusinessCollectionBase() { }

        /// <summary>
        /// Initializes a new instance of the BusinessCollectionBase class and populates it with the initial list.
        /// </summary>
        public BusinessCollectionBase(IList<T> initialList) : base(initialList) { }

        /// <summary>
        /// Sorts the collection based on the specified comparer.
        /// </summary>
        /// <param name="comparer">The comparer that is used to sort this collection.</param>
        public void Sort(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer", "Comparer is null.");
            }
            List<T> list = this.Items as List<T>;
            if (list == null)
            {
                return;
            }
            list.Sort(comparer);
        }
    }
}
