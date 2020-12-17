using ObjectComparer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectComparer.Repository
{
    public class ObjectComparerRepository : IObjectComparerRepository
    {
        public bool CompareObjects<T>(T first,T second)
        {
            return Comparer.AreSimilar<T>(first, second);
        }
    }
}
