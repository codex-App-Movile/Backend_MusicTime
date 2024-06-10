using Backend_MusicTime.Review.Domain.Model.Commands;
using Backend_MusicTime.Review.Domain.Model.Entities;

namespace Backend_MusicTime.Review.Domain.Services;

public interface IPuntuationCommandService
{
    Task<Puntuation?> Handle(CreatePuntuationCommand command);
}
