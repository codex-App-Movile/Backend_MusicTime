using Backend_MusicTime.Customer.Domain.Model.ValueObjects;
using Backend_MusicTime.Customer.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_MusicTime.Customer.Infrastructure.Persistence.EFC.Repositories;

public class CustomerRepository : BaseRepository<Domain.Model.Aggregates.Customer>, ICustomerRepository
{
    private readonly AppDbContext context;
    public Task<Customer.Domain.Model.Aggregates.Customer?> FindClientByEmailAsync(EmailAddress email)
    {
        return Context.Set<Customer.Domain.Model.Aggregates.Customer>().Where(c => c.Email == email).FirstOrDefaultAsync();    
    }

    public CustomerRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }
}