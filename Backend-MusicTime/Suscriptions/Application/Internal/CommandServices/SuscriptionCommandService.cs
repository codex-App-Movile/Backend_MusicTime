using Backend_MusicTime.Shared.Domain.Repositories;
using Backend_MusicTime.Suscriptions.Domain.Model.Aggregates;
using Backend_MusicTime.Suscriptions.Domain.Model.Commands;
using Backend_MusicTime.Suscriptions.Domain.Repositories;
using Backend_MusicTime.Suscriptions.Domain.Services;

namespace Backend_MusicTime.Suscriptions.Application.Internal.CommandServices;

public class SuscriptionCommandService(ISuscriptionRepository suscriptionRepository, IUnitOfWork unitOfWork) : ISuscriptionCommandService
{
    public async Task<Suscription?> Handle(CreateSuscriptionCommand command)
    {
        var suscription = new Suscription(command);
        try
        {
            await suscriptionRepository.AddAsync(suscription);
            await unitOfWork.CompleteAsync();
            return suscription;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the subscription: {e.Message}");
            return null;
        }
    }
}