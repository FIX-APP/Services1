using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Repositories;
using FixAppAPI.App.Domain.Services;
using FixAppAPI.App.Domain.Services.Communication;
using FixAppAPI.App.Persistence.Repositories;
using FixAppAPI.Shared.Domain.Repositories;

namespace FixAppAPI.App.Services;

public class ArtifactService : IArtifactService
{
    private readonly IArtifactRepository _artifactRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public ArtifactService(IArtifactRepository artifactRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _artifactRepository = artifactRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Artifact>> ListAsync()
    {
        return await _artifactRepository.ListAsync();
    }

    public async Task<IEnumerable<Artifact>> ListByUserIdAsync(int userId)
    {
        return await _artifactRepository.FindByUserIdAsync(userId);
    }

    public async Task<ArtifactResponse> SaveAsync(Artifact artifact)
    {
        // Validate CategoryId

        var existingCategory = await _userRepository.FindByIdAsync(artifact.userId);

        if (existingCategory == null)
            return new ArtifactResponse("Invalid user");
        
        try
        {
            // Add Tutorial
            await _artifactRepository.AddAsync(artifact);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new ArtifactResponse(artifact);

        }
        catch (Exception e)
        {
            // Error Handling
            return new ArtifactResponse($"An error occurred while saving the tutorial: {e.Message}");
        }

        
    }

    public async Task<ArtifactResponse> UpdateAsync(int artifactId, Artifact artifact)
    {
        var existingArtifact = await _artifactRepository.FindByIdAsync(artifactId);
        
        // Validate Tutorial

        if (existingArtifact == null)
            return new ArtifactResponse("Artifact not found.");

        // Validate UserId

        var existingUser = await _userRepository.FindByIdAsync(artifact.userId);

        if (existingUser == null)
            return new ArtifactResponse("Invalid User");


        // Modify Fields
        existingArtifact.name = artifact.name;
        existingArtifact.url = artifact.url;

        try
        {
            _artifactRepository.Update(existingArtifact);
            await _unitOfWork.CompleteAsync();

            return new ArtifactResponse(existingArtifact);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ArtifactResponse($"An error occurred while updating the artifact: {e.Message}");
        }

    }

    public async Task<ArtifactResponse> DeleteAsync(int artifactId)
    {
        var existingArtifact = await _artifactRepository.FindByIdAsync(artifactId);
        
        // Validate Artifact

        if (existingArtifact == null)
            return new ArtifactResponse("Artifact not found.");
        
        try
        {
            _artifactRepository.Remove(existingArtifact);
            await _unitOfWork.CompleteAsync();

            return new ArtifactResponse(existingArtifact);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ArtifactResponse($"An error occurred while deleting the artifact: {e.Message}");
        }

    }
}