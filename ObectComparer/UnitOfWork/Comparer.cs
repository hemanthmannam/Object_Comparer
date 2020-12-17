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

                //if type is Generic Type or Arrays
                if (FirstValue.GetType().IsArray || SecondValue.GetType().IsArray ||
                FirstValue.GetType().IsGenericType || SecondValue.GetType().IsGenericType)
                {
                    //if any of the generic objects or arrays are null
                    if ((FirstValue == null && SecondValue != null) || (FirstValue != null && SecondValue == null))
                        return false;

                    List<bool> results = new List<bool>();
                    int firstCount = 0, secondCount = 0;

                    //set number of elements in First Array or Generic object
                    foreach (var item in FirstValue as IEnumerable)
                    {
                        firstCount++;
                    }
                    //set number of elements in Second Array or Generic object
                    foreach (var item in SecondValue as IEnumerable)
                    {
                        secondCount++;
                    }


                    //return if the counts are not equal as the object is not similar
                    if (firstCount != secondCount)
                    {
                        return false;
                    }

                    //iterate through the items in the first object
                    foreach (var firstElement in FirstValue as IEnumerable)
                    {
                        bool IsMatched = false;
                        
                        //iterate through second Object to find the match
                        foreach (var secondElement in SecondValue as IEnumerable)
                        {
                            //if a match is found break out of the loop
                            if (firstElement.ToString().Trim() == secondElement.ToString().Trim())
                            {
                                IsMatched = true;
                                break;
                            }
                        }

                        if (IsMatched)
                        {
                            results.Add(true);
                        }
                        else
                        {
                            results.Add(false);
                        }
                    }

                    
                    if (results.Any(a => a == false))
                    {
                        return false;
                    }
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
