using FilterProps.Test.TestData;
using TechTalk.SpecFlow;

namespace FilterProps.Test.Specs.Steps
{
    [Binding]
    public class MultipleFilters
    {
        [Given(@"I AND a filter where Gender is Female")]
        public void GivenIANDAFilterWhereGenderIsFemale()
        {
            var service = ScenarioContext.Current.Get<FilterService<Student>>("service");
            service.DoAndWith(e => e.Gender == "Female");
        }

        [Given(@"I add a filter where IsInternataional is true")]
        public void GivenIAddAFilterWhereIsInternataionalIsTrue()
        {
            var service = ScenarioContext.Current.Get<FilterService<Student>>("service");
            service.AddBinaryFilter(e => e.IsInternational);
        }
    }
}
