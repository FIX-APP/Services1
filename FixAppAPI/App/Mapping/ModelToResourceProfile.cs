using AutoMapper;
using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Resources;

namespace FixAppAPI.App.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
        CreateMap<Artifact, ArtifactResource>();
        CreateMap<Appointment, AppointmentResource>();
    }
}
