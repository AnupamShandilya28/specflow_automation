using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SpecflowAPIAutomation.StepDefinitions
{
    [Binding]
    public class PetShopStepDefinitions
    {
        RestClient restClient;
        RestRequest request;
        RestResponse response;

        [Given(@"I have base url '([^']*)' and resourse '([^']*)'")]
        public void GivenIHaveBaseUrlAndResourse(string baseUrl, string resource)
        {
            restClient = new RestClient(baseUrl+resource);
        }

        [When(@"I do the Get request")]
        public void WhenIDoTheGetRequest()
        {
           request = new RestRequest();
           response= restClient.Execute(request);
        }

        [Then(@"I should get the response as (.*)")]
        public void ThenIShouldGetTheResponseAs(int expectedStatusCode)
        {
            int actualStatusCode = (int)response.StatusCode;
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"I should get the pet details in json format")]
        public void ThenIShouldGetThePetDetailsInJsonFormat()
        {
            
        }

        [Then(@"I should get message as '([^']*)'")]
        public void ThenIShouldGetMessageAs(string expectedMessage)
        {
            string actualResponse=response.Content;
            Assert.Contains(expectedMessage,actualResponse);
        }


        [Given(@"I need add api_key '([^']*)' in the header")]
        public void GivenINeedAddApi_KeyInTheHeader(string apiKey)
        {
           // restClient.AddDefaultHeader("api_key", apiKey);
        }

        [When(@"I do the Delete request")]
        public void WhenIDoTheDeleteRequest()
        {
            request = new RestRequest("",Method.Delete);
            response = restClient.Execute(request);
        }
    }
}
