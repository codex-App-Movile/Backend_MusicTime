using Backend_MusicTime.Client.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Client.Domain.Model.Queries;

public record GetClientByEmailQuery(EmailAddress Email);