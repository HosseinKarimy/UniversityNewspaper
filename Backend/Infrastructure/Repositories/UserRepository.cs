using Application.Bazaar.BazzarRepositories;
using Domain.Models;
using Domain.StronglyTypes;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(AppDbContext dbContext) : Repository<User,UserId>(dbContext.Users)  , IUserRepository
{
    public async Task<User> AddUserIfNotExistAsync(User user, CancellationToken cancellationToken = default)
    {
        var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);

        if (existingUser != null)
        {
            return existingUser;
        }

        dbContext.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }
}
