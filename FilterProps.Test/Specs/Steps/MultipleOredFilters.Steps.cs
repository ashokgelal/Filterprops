using FilterProps.Test.TestData;
using TechTalk.SpecFlow;

namespace FilterProps.Test.Specs.Steps
{
    [Binding]
    public class MultipleOredFilters
    {
        [Given(@"I OR a filter where Gender is Female")]
        public void GivenIORAFilterWhereGenderIsFemale()
        {
            var service = ScenarioContext.Current.Get<FilterService<Student>>("service");
            service.DoOrWith(e => e.Gender == "Female");
        }

        [Given(@"I OR a filter where FirstName is Ashwàq")]
        public void GivenIORAFilterWhereFirstNameIsAshwaq()
        {
            var service = ScenarioContext.Current.Get<FilterService<Student>>("service");
            service.DoOrWith(e => e.FirstName == "Ashwàq Jawahir");
        }
    }
}
