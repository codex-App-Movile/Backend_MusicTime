using Backend_MusicTime.Review.Domain.Model.Commands;
using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Review.Domain.Services;
using Backend_MusicTime.Shared.Domain.Repositories;

namespace Backend_MusicTime.Review.Application.Internal.CommandServices;

public class PuntuationCommandService(IPuntuationRepository puntuationRepository, IUnitOfWork unitOfWork) : IPuntuationCommandService
{
    public Task<Puntuation?> Handle(CreatePuntuationCommand command)
    {
        throw new NotImplementedException();
    }
}
