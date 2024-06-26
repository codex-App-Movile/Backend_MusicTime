using Backend_MusicTime.Enterprise.Domain.Model.Commands;
using Backend_MusicTime.Enterprise.Domain.Repositories;
using Backend_MusicTime.Enterprise.Domain.Services;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Enterprise.Application.Internal.CommandServices;

public class EnterpriseCommandService(IEnterpriseRepository enterpriseRepository, IUnitOfWork unitOfWork) : IEnterpriseCommandService
{
    public async Task<Domain.Model.Aggregates.Enterprise?> Handle(CreateEnterpriseCommand command)
    {
        var enterprise = new Domain.Model.Aggregates.Enterprise(command);
        try
        {
            await enterpriseRepository.AddAsync(enterprise);
            await unitOfWork.CompleteAsync();
            return enterprise;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the enterprise: {e.Message}");
            return null;
        }
    }
}