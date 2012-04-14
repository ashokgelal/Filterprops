using FilterProps.Test.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace FilterProps.Test.Specs
{
    [Binding]
    public class FilterCollectionSteps
    {
        [Given(@"I have a student class")]
        public void GivenIHaveAStudentClass()
        {
            var student = new Student();
        }
        [When(@"I create new filter collection of type Student")]
        public void WhenICreateNewFilterCollectionOfTypeStudent()
        {
            var collection = new FilterCollection<Student>();
            ScenarioContext.Current.Add("coll", collection);
        }

        [Then(@"I should get an empty collection of filters")]
        public void ThenIShouldGetAnEmptyCollectionOfFilters()
        {
            var coll = ScenarioContext.Current.Get<FilterCollection<Student>>("coll");
            Assert.AreEqual(0, coll.Count);
        }
    }
}
