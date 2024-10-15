using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<User> AddUserIfNotExistAsync(User user, CancellationToken cancellationToken = default)
    {
        var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId, cancellationToken);

        if (existingUser != null)
        {
            return existingUser;
        }

        dbContext.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }
}
