using Backend_MusicTime.Client.Domain.Model.Commands;

namespace Backend_MusicTime.Client.Domain.Services;

public interface IClientCommandService
{
    Task<Model.Aggregates.Client?> Handle(CreateClientCommand command);
}