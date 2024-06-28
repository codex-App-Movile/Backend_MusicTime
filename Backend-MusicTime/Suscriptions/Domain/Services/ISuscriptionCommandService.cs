using Backend_MusicTime.Suscriptions.Domain.Model.Aggregates;
using Backend_MusicTime.Suscriptions.Domain.Model.Commands;

namespace Backend_MusicTime.Suscriptions.Domain.Services;

public interface ISuscriptionCommandService
{
    Task<Suscription?> Handle(CreateSuscriptionCommand command);
}