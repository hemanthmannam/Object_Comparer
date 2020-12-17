using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectComparer.Repository
{
    public interface IObjectComparerRepository
    {
        bool CompareObjects<T>(T first, T second);
    }
}
