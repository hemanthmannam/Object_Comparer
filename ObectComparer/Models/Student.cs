using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Models
{
    public class Student
    {
        public int Id { get; set; }
        public char Grade { get; set; }
        public bool IsActive { get; set; }
        public float Percentage { get; set; }
        public double Average { get; set; }
        public string Name { get; set; }
        public int[] Marks { get; set; }
        public List<string> Subjects { get; set; }
    }
}
