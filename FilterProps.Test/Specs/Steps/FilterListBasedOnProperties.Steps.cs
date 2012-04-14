using System;
using System.Collections.Generic;
using System.Linq;
using FilterProps.Test.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace FilterProps.Test.Specs.Steps
{
    [Binding]
    public class FilterListBasedOnProperties
    {
        private static Student CreateStudent(IEnumerable<string> data)
        {
            var list = data.ToArray();
            var student = new Student
                              {
                                  FirstName = list[0],
                                  LastName = list[1],
                                  Gender = list[2],
                                  IsInternational = Convert.ToBoolean(list[3])
                              };
            return student;
        }

        [Given(@"These students:")]
        public void GivenTheseStudents(Table table)
        {
            var students = new List<Student>();
            foreach (var row in table.Rows)
            {
                students.Add(CreateStudent(row.Values));
            }
            ScenarioContext.Current.Add("students", students);
        }

        [Given(@"I add a filter where FirstName is Jesse")]
        public void GivenIAddAFilterWhereFirstNameIsJesse()
        {
            var service = new FilterService<Student>();
            service.AddBinaryFilter(e => e.FirstName == "Jesse");
            ScenarioContext.Current.Add("service", service);
        }

        [When(@"I apply the filters")]
        public void WhenIApplyTheFilters()
        {
            var service = ScenarioContext.Current.Get<FilterService<Student>>("service");
            var students = ScenarioContext.Current.Get<IList<Student>>("students");
            ScenarioContext.Current.Add("filteredStudents", new List<Student>(service.Filter(students)));
        }

        [Then(@"The student list should contain Jesse")]
        public void ThenTheStudentListShouldContainJesse()
        {
            var filteredStudents = ScenarioContext.Current.Get<List<Student>>("filteredStudents");
            var jesse = filteredStudents.First();
            Assert.AreEqual("Jesse", jesse.FirstName);
        }

        [Given(@"I add a filter where FirstName is Elenor")]
        public void GivenIAddAFilterWhereFirstNameIsElenor()
        {
            var service = new FilterService<Student>();
            service.AddBinaryFilter(e => e.FirstName == "Elenor");
            ScenarioContext.Current.Add("service", service);
        }

        [Then(@"The student list should contain Elenor")]
        public void ThenTheStudentListShouldContainElenor()
        {
            var filteredStudents = ScenarioContext.Current.Get<List<Student>>("filteredStudents");
            var elenor = filteredStudents.First();
            Assert.AreEqual("Elenor", elenor.FirstName);
        }

        [Given(@"I add a filter where FirstName is Jose")]
        public void GivenIAddAFilterWhereFirstNameIsJose()
        {
            var service = new FilterService<Student>();
            service.AddBinaryFilter(e => e.FirstName == "Jose");
            ScenarioContext.Current.Add("service", service);
        }

        [Then(@"These students should be on the list")]
        public void ThenTheseStudentsShouldBeOnTheList(Table table)
        {
            var filteredStudents = ScenarioContext.Current.Get<List<Student>>("filteredStudents");
            var students = new List<Student>();
            foreach (var row in table.Rows)
            {
                students.Add(CreateStudent(row.Values));
            }

            Assert.AreEqual(students.Count, filteredStudents.Count);

            for (var i = 0; i < students.Count; i++)
            {
                Assert.AreEqual(students[i].FirstName, filteredStudents[i].FirstName);
                Assert.AreEqual(students[i].LastName, filteredStudents[i].LastName);
                Assert.AreEqual(students[i].IsInternational, filteredStudents[i].IsInternational);
                Assert.AreEqual(students[i].Gender, filteredStudents[i].Gender);
            }
        }

        [Given(@"I add a filter where LastName is Jackson")]
        public void GivenIAddAFilterWhereLastNameIsJackson()
        {
            var service = new FilterService<Student>();
            service.AddBinaryFilter(e => e.LastName == "Jackson");
            ScenarioContext.Current.Add("service", service);
        }

        [Given(@"I add a filter where LastName contains Jackson")]
        public void GivenIAddAFilterWhereLastNameContainsJackson()
        {
            var service = new FilterService<Student>();
            service.AddBinaryFilter(e => e.LastName.Contains("Jackson"));
            ScenarioContext.Current.Add("service", service);
        }

        [Given(@"I add a filter for international students")]
        public void GivenIAddAFilterForInternationalStudents()
        {
            var service = new FilterService<Student>();
            service.AddBinaryFilter(e => e.IsInternational);
            ScenarioContext.Current.Add("service", service);
        }
    }
}
