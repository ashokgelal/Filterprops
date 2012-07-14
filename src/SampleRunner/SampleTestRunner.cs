using System;
using System.Collections.Generic;
using FilterProps.Test.TestData;
using FilterProps;
using System.Linq;

namespace SampleRunner
{
    public class SampleTestRunner
    {
        public SampleTestRunner()
        {
            var list = new List<Student>();
            var rand = new Random();
            const int total = 10000000;
            Console.WriteLine("Creating list ...");
            for(var i = 0; i < total; i++)
            {
                var student = new Student
                    {
                        FirstName = rand.Next().ToString(),
                        Id = i,
                        LastName = rand.Next().ToString(),
                        IsInternational = rand.Next(2) != 0,
                        Gender = rand.Next(2) == 0 ? "Male" : "Female",
                    };
                list.Add(student);
            }

            Console.WriteLine("Filtering ...");
            var st = DateTime.Now;
            var service = new FilterService<Student>();
            service.AddBinaryFilter(e => e.Id < total);
            service.AddBinaryFilter(e => e.FirstName.Contains("1"));
            service.AddBinaryFilter(e => e.LastName.Contains("2"));
            service.AddBinaryFilter(e => !e.IsInternational);
            service.AddBinaryFilter(e => e.Gender.Equals("Female"));
            var filtered = service.Filter(list);
            var et = DateTime.Now;
            Console.WriteLine("Done filtering...");
            Console.WriteLine("Filtering time (in ms): {0}", et.Subtract(st).TotalMilliseconds);

            Console.WriteLine("Total Count: {0}", list.Count);
            Console.WriteLine("Filtered Count: {0}", filtered.Count());
        }
    }
}
