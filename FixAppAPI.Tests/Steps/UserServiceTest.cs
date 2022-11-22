using System.Net;
using System.Net.Mime;
using System.Text;
using FixAppAPI.App.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace FixAppAPI.Tests.Steps;

[Binding]
public class UsersServiceStepDefinitions : WebApplicationFactory<Program>
{

    private readonly WebApplicationFactory<Program> _factory;

    public UsersServiceStepDefinitions(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    
    private Task<HttpResponseMessage> Response { get; set; }
    

    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/users is available")]
    public void GivenTheEndpointHttpsLocalhostApiVTutorialsIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/users");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }


    [When(@"a Post Request is sent to users")]
    public void WhenAPostRequestIsSent(Table saveUserResource)
    {
        var resource = saveUserResource.CreateSet<SaveUserResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"A Response  is received with Statuss (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a User Resource is included in Response Body")]
    public async Task ThenATutorialResourceIsIncludedInResponseBody(Table expectedArtifactResource)
    {
        var expectedResource = expectedArtifactResource.CreateSet<ArtifactResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<ArtifactResource>(responseData);
        Assert.Equal(expectedResource.name, resource.name);
    }

}