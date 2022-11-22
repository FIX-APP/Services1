using AutoMapper;
using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Services;
using FixAppAPI.App.Resources;
using FixAppAPI.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FixAppAPI.App.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ArtifactsController : ControllerBase
{
    private readonly IArtifactService _artifactService;
    private readonly IMapper _mapper;

    public ArtifactsController(IArtifactService artifactService, IMapper mapper)
    {
        _artifactService = artifactService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ArtifactResource>> GetAllAsync()
    {
        var artifacts = await _artifactService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Artifact>, IEnumerable<ArtifactResource>>(artifacts);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveArtifactResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var artifact = _mapper.Map<SaveArtifactResource, Artifact>(resource);

        var result = await _artifactService.SaveAsync(artifact);

        if (!result.Success)
            return BadRequest(result.Message);

        var artifactResource = _mapper.Map<Artifact, ArtifactResource>(result.Resource);

        return Ok(artifactResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveArtifactResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var artifact = _mapper.Map<SaveArtifactResource, Artifact>(resource);

        var result = await _artifactService.UpdateAsync(id, artifact);

        if (!result.Success)
            return BadRequest(result.Message);

        var tutorialResource = _mapper.Map<Artifact, ArtifactResource>(result.Resource);

        return Ok(tutorialResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _artifactService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var artifactResource = _mapper.Map<Artifact, ArtifactResource>(result.Resource);

        return Ok(artifactResource);
    }
    
}