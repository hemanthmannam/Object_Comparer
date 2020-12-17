using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectComparer.UnitOfWork
{
    internal static class ArrayGenericsComparer
    {
        internal static bool AreArraysGenericObjectsSimilar<T>(T first, T second)
        {
            List<bool> results = new List<bool>();
            int firstCount = 0, secondCount = 0;

            //set number of elements in First Array or Generic object
            foreach (var item in first as IEnumerable)
            {
                firstCount++;
            }
            //set number of elements in Second Array or Generic object
            foreach (var item in second as IEnumerable)
            {
                secondCount++;
            }


            //return if the counts are not equal as the object is not similar
            if (firstCount != secondCount)
            {
                return false;
            }

            //iterate through the items in the first object
            foreach (var firstElement in first as IEnumerable)
            {
                bool IsMatched = false;

                //iterate through second Object to find the match
                foreach (var secondElement in second as IEnumerable)
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
            return true;
        }

    }
}
