﻿using Application.Users.DTO;
using Application.Users.Repositroies;
using Domain.Models;
using Domain.StronglyTypes;
using Infrastructure.Data.ApplicaionDbContetxt;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repositories.UserRepositories;

public class UserRepository(AppDbContext dbContext) : Repository<User, UserId>(dbContext.Users), IUserRepository
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

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
