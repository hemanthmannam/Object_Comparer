using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.UnitOfWork
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second)
        {
            Type type = typeof(T);

            //if both of the Objects are null
            if (first == null && second == null)
            {
                return true;
            }

            //if any of the Objects are null
            if (first == null || second == null)
            {
                return false;
            }

            //gets list if properties
            PropertyInfo[] properties = type.GetProperties();

            //loop through the list of properties to verify the values
            foreach (PropertyInfo property in properties)
            {
                var FirstValue = type.GetProperty(property.Name).GetValue(first);
                var SecondValue = type.GetProperty(property.Name).GetValue(second);

                //if both the items are null then exit out of the current iteration as the values are same
                if (FirstValue == null && SecondValue == null)
                    continue;

                //if type is Generic Type or Arrays
                if (FirstValue.GetType().IsArray || SecondValue.GetType().IsArray ||
                FirstValue.GetType().IsGenericType || SecondValue.GetType().IsGenericType)
                {
                    //if any of the generic objects or arrays are null
                    if ((FirstValue == null && SecondValue != null) || (FirstValue != null && SecondValue == null))
                        return false;

                    //all the elements in the first object will be checked with al the elements in second object for similarity
                    if (!ArrayGenericsComparer.AreArraysGenericObjectsSimilar(FirstValue, SecondValue))
                        return false;

                    //all the elements in second object will be checked with all the elements in first object
                    if (!ArrayGenericsComparer.AreArraysGenericObjectsSimilar(SecondValue, FirstValue))
                        return false;
                }
                else
                {
                    if (FirstValue?.ToString().Trim() != SecondValue?.ToString().Trim())
                    {
                        return false;
                    }
                }
            };
            return true;
        }



    }
}
