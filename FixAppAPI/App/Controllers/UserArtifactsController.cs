using AutoMapper;
using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Services;
using FixAppAPI.App.Resources;
using Microsoft.AspNetCore.Mvc;

namespace FixAppAPI.App.Controllers;

[ApiController]
[Route("/api/v1/users/{userId}/artifacts")]
public class UserArtifactsController : ControllerBase
{
    private readonly IArtifactService _artifactService;
    private readonly IMapper _mapper;

    public UserArtifactsController(IArtifactService artifactService, IMapper mapper)
    {
        _artifactService = artifactService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ArtifactResource>> GetAllByCategoryIdAsync(int userId)
    {
        var artifacts = await _artifactService.ListByUserIdAsync(userId);

        var resources = _mapper.Map<IEnumerable<Artifact>, IEnumerable<ArtifactResource>>(artifacts);

        return resources;
    }
}