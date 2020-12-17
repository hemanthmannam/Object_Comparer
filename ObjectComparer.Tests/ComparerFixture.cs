using System;
using ObjectComparer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectComparer.UnitOfWork;
using System.Collections.Generic;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {
        [TestMethod]
        public void Null_values_are_similar_test()
        {
            Assert.IsTrue(Comparer.AreSimilar<Student>(null, null));
        }
        [TestMethod]
        public void Objects_are_equal_test()
        {
            Student student1 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = null,
                Subjects = new List<string> { "C", "Java", "Python" },
                Address = new Dictionary<string, int>
                {
                    { "Chennai", 600089 },{ "Ongole", 523002 }
                },
                Values=new Test()
            };
            Student student2 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = null,
                Subjects = new List<string> { "C", "Java", "Python" },
                Address = new Dictionary<string, int>
                {
                    { "Chennai", 600089 },{ "Ongole", 523002 }
                }
            };
            Assert.IsTrue(Comparer.AreSimilar(student1, student2));
        }

        [TestMethod]
        public void Objects_are_not_equal_test()
        {
            Student student1 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = new[] { 60, 70, 80 },
                Subjects = new List<string> { "C", "Java", "Python" }
            };
            Student student2 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = new[] { 80, 90, 70 },
                Subjects = new List<string> { "C", "Java", "Python" }
            };
            Assert.IsFalse(Comparer.AreSimilar(student1, student2));
        }
        [TestMethod]
        public void Objects_are_not_equal_test_second_item_empty()
        {
            Student student1 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = new[] { 60, 70, 80 },
                Subjects = new List<string> { "C", "Java", "Python" }
            };
            Student student2 = new Student();

            Assert.IsFalse(Comparer.AreSimilar(student1, student2));
        }

        [TestMethod]
        public void Objects_are_not_equal_test_array_items_extra()
        {
            Student student1 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = new[] { 60, 70, 80 },
                Subjects = new List<string> { "C", "Java", "Python" }
            };
            Student student2 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = false,
                Grade = 'B',
                Percentage = 74.01F,
                Name = "Jack",
                Marks = new[] { 60, 90, 70, 30 },
                Subjects = new List<string> { "C", "Java", "Python" }
            };
            Assert.IsFalse(Comparer.AreSimilar(student1, student2));
        }

        [TestMethod]
        public void Objects_are_not_equal_array_null_test()
        {
            Student student1 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = new[] { 60, 70, 80 },
                Subjects = new List<string> { "C", "Java", "Python" }
            };
            Student student2 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = null,
                Subjects = new List<string> { "C", "Java", "Python" }
            };
            Assert.IsFalse(Comparer.AreSimilar(student1, student2));
        }

        [TestMethod]
        public void Objects_are_not_equal_collections_not_equal_test()
        {
            Student student1 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = new[] { 60, 70, 80 },
                Subjects = new List<string> { "C", "Java", "Python" }
            };
            Student student2 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = new[] { 60, 70, 80 },
                Subjects = new List<string> { "C#", "Java", "Python" }
            };
            Assert.IsFalse(Comparer.AreSimilar(student1, student2));
        }

        [TestMethod]
        public void Objects_are_not_equal_second_object_null()
        {
            Student student1 = new Student()
            {
                Id = 100,
                Average = 10.01,
                IsActive = true,
                Grade = 'B',
                Percentage = 76.01F,
                Name = "John",
                Marks = new[] { 60, 70, 80 },
                Subjects = new List<string> { "C", "Java", "Python" }
            };
            Student student2 = null;
            Assert.IsFalse(Comparer.AreSimilar(student1, student2));
        }

    }
}
