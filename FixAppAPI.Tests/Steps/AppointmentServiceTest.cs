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
public class AppointmentsServiceStepDefinitions : WebApplicationFactory<Program>
{

    private readonly WebApplicationFactory<Program> _factory;

    public AppointmentsServiceStepDefinitions(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    
    private Task<HttpResponseMessage> Response { get; set; }
    

    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/appointments is available")]
    public void GivenTheEndpointHttpsLocalhostApiVTutorialsIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/appointments");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }


    [When(@"a Post Request is sent to")]
    public void WhenAPostRequestIsSent(Table saveAppointmentResource)
    {
        var resource = saveAppointmentResource.CreateSet<SaveAppointmentResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"A Response  is received with Status of(.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a Appointment Resource is included in Response Body")]
    public async Task ThenATutorialResourceIsIncludedInResponseBody(Table expectedAppointmentResource)
    {
        var expectedResource = expectedAppointmentResource.CreateSet<AppointmentResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<ArtifactResource>(responseData);
        Assert.Equal(expectedResource.user.name, resource.user.name);
    }

}