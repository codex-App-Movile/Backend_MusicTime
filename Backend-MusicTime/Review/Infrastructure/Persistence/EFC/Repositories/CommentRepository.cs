using Backend_MusicTime.Review.Domain.Model.Entities;
using Backend_MusicTime.Review.Domain.Repositories;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_MusicTime.Review.Infrastructure.Persistence.EFC.Repositories;

public class CommentRepository(AppDbContext context) : BaseRepository<Comment>(context), ICommentRepository
{
    public async Task<IEnumerable<Comment>> GetAllCommentsByUserId(int userId)
    {
        return await Context.Comments.Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<Comment>> GetCommentsByBandId(int bandId)
    {
        return await Context.Comments.Where(c => c.BandId == bandId).ToListAsync();
    }
}
