using Backend_MusicTime.Customer.Domain.Model.ValueObjects;

namespace Backend_MusicTime.Customer.Domain.Model.Queries;

public record GetCustomerByEmailQuery(EmailAddress Email);