using AutoMapper;
using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Resources;

namespace FixAppAPI.App.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveUserResource, User>();
        CreateMap<SaveArtifactResource, Artifact>();
        CreateMap<SaveAppointmentResource, Appointment>();
    }
}
