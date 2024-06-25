using Backend_MusicTime.Contracts.Domain.Model.Aggregates;
using Backend_MusicTime.Contracts.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Backend_MusicTime.Contracts.Infrastructure.Persistence.EFC.Repositories
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        private readonly AppDbContext context;

        public ContractRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        
        public override async Task<Contract?> FindByIdAsync(int id)
        {
            return await context.Contracts.FindAsync(id);
        }

        public async Task<Contract?> FindByIdAsync(string id)
        {
            return await context.Contracts.FindAsync(id);
        }

        public async Task<IEnumerable<Contract>> FindByMusicianIdAsync(Guid musicianId)
        {
            return await context.Contracts.Where(c => c.MusicianId == musicianId).ToListAsync();
        }

        public async Task AddAsync(Contract contract)
        {
            await context.Contracts.AddAsync(contract);
        }

        public void Update(Contract contract)
        {
            context.Contracts.Update(contract);
        }

        public async Task<IEnumerable<Contract>> ListAsync()
        {
            return await context.Contracts.ToListAsync();
        }

        public async Task<Contract?> FindContractByIdAsync(int id)
        {
            return await context.Contracts.FindAsync(id);
        }

        public Task<IEnumerable<Contract>> FindByMusicianIdAsync(int queryMusicianId)
        {
            throw new NotImplementedException();
        }
    }
}