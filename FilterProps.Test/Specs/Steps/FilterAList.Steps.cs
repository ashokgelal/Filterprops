using System.Collections.Generic;
using FilterProps.Test.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace FilterProps.Test.Specs.Steps
{
    [Binding]
    public class FilterAList
    {
        [Given(@"I have a list of 5 students")]
        public void GivenIHaveAListOf5Students()
        {
            var students = new List<Student>
                               {
                                   new Student(),
                                   new Student(),
                                   new Student(),
                                   new Student(),
                                   new Student(),
                               };
            ScenarioContext.Current.Add("students", students);
        }

        [Given(@"I have a collection of filters with no filters")]
        public void GivenIHaveACollectionOfFiltersWithNoFilters()
        {
            var filters = new FilterCollection<Student>();
            ScenarioContext.Current.Add("filters", filters);
        }

        [Given(@"I have a filter service")]
        public void GivenIHaveAFilterService()
        {
            var filters = ScenarioContext.Current.Get<FilterCollection<Student>>("filters");
            var service = new FilterService<Student>(filters);
            ScenarioContext.Current.Add("service", service);
        }

        [When(@"I ask the fiter service to filter the list")]
        public void WhenIAskTheFiterServiceToFilterTheList()
        {
            var students = ScenarioContext.Current.Get<List<Student>>("students");
            var service = ScenarioContext.Current.Get<FilterService<Student>>("service");
            var filteredList = service.Filter(students);
            ScenarioContext.Current.Add("filteredList", filteredList);
        }

        [Then(@"I should get back a list of five students")]
        public void ThenIShouldGetBackAListOfFiveStudents()
        {
            var filteredList = ScenarioContext.Current.Get<List<Student>>("filteredList");
            Assert.AreEqual(5, filteredList.Count);
        }
    }
}
