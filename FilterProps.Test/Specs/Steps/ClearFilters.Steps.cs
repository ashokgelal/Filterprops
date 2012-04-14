using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FilterProps.Test.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace FilterProps.Test.Specs.Steps
{
    [Binding]
    public class ClearFilters
    {
        [Given(@"I have a collection of filters")]
        public void GivenIHaveACollectionOfFilters()
        {
            var coll = new FilterCollection<Student>();
            ScenarioContext.Current.Add("coll", coll);
        }

        [When(@"I clear the collection")]
        public void WhenIClearTheCollection()
        {
            var coll = ScenarioContext.Current.Get<FilterCollection<Student>>("coll");
            coll.Clear();
        }

        [Then(@"The filters count should be 0")]
        public void ThenTheFiltersCountShouldBe0()
        {
            var coll = ScenarioContext.Current.Get<FilterCollection<Student>>("coll");
            Assert.AreEqual(0, coll.Count);
        }
        [Then(@"The collection expression should be null")]
        public void ThenTheCollectionExpressionShouldBeNull()
        {
            var coll = ScenarioContext.Current.Get<FilterCollection<Student>>("coll");
            Assert.IsNull(coll.ItsExpression);
        }

    }
}
