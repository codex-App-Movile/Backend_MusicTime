using Backend_MusicTime.Enterprise.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Enterprise.Domain.Model.Queries;

public record GetEnterpriseByEmailQuery(EnterpriseEmailAddress Email);