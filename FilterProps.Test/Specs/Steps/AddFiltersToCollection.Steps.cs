using System.Collections.Generic;
using FilterProps.Test.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace FilterProps.Test.Specs.Steps
{
    [Binding]
    public class AddFiltersSteps
    {
        [Given(@"I have a filter collection of type Student")]
        public void GivenIHaveAFilterCollectionOfTypeStudent()
        {
            var coll = new FilterCollection<Student>();
            ScenarioContext.Current.Add("coll", coll);
        }

        [When(@"I add a new filter")]
        public void WhenIAddANewFilter()
        {
            var coll = ScenarioContext.Current.Get<FilterCollection<Student>>("coll");
            var filter = new BinaryFilterExpression<Student>(e => e.FirstName == "foo");
            coll.AddNewFilter(filter);
            ScenarioContext.Current.Add("filter", filter);
        }

        [Then(@"The filter should be added to the collection")]
        public void ThenTheFilterShouldBeAddedToTheCollection()
        {
            var coll = ScenarioContext.Current.Get<FilterCollection<Student>>("coll");
            var filter = ScenarioContext.Current.Get<BinaryFilterExpression<Student>>("filter");
            Assert.IsTrue(coll.Contains(filter));
        }
        [Then(@"The filter collection count should be 1")]
        public void ThenTheFilterCollectionCountShouldBe1()
        {
            var coll = ScenarioContext.Current.Get<FilterCollection<Student>>("coll");
            Assert.AreEqual(1, coll.Count);
        }

        [Then(@"The filter expression should not be null")]
        public void ThenTheFilterExpressionShouldNotBeNull()
        {
            var coll = ScenarioContext.Current.Get<FilterCollection<Student>>("coll");
            Assert.IsNotNull(coll.ItsExpression);
        }

        [When(@"I add a list of two filters")]
        public void WhenIAddAListOfTwoFilters()
        {
            var newColl = new List<BinaryFilterExpression<Student>>
                              {
                                  new BinaryFilterExpression<Student>(e=>e.FirstName=="foo"), 
                                  new BinaryFilterExpression<Student>(e=>e.FirstName=="foo")
                              };
            var coll = ScenarioContext.Current.Get<FilterCollection<Student>>("coll");
            coll.Add(newColl);
        }

        [Then(@"The filter collection count should be 3")]
        public void ThenTheFilterCollectionCountShouldBe3()
        {
            var coll = ScenarioContext.Current.Get<FilterCollection<Student>>("coll");
            Assert.AreEqual(3, coll.Count);
        }
    }
}
