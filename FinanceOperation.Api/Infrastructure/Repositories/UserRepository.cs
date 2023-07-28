using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using FinanceOperation.Api.Infrastructure.Databases;

namespace FinanceOperation.Api.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserIdentity> GetUser(int id)
    {
        UserIdentity user = await _context.Users.FindAsync(id)
              ?? throw new Exception($"Unable to find the user with id {id}");

        if (!user.IsDeleted.HasValue || user.IsDeleted.Value)
        {
            throw new Exception($"Unable to find the user with id {id}");
        }

        return user;
    }

    public async Task<int> Create(UserIdentity user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task Update(UserIdentity user)
    {
        var userToUpdate = await _context.Users.FindAsync(user.Id)
            ?? throw new Exception($"Unable to find the user with id {user.Id}");

        UpdateUserInternal(userToUpdate, user);
        await _context.SaveChangesAsync();

        static void UpdateUserInternal(UserIdentity userToUpdate, UserIdentity newUser)
        {
            if (newUser.SecondName is not null && userToUpdate.SecondName != newUser.SecondName)
            {
                userToUpdate.SecondName = newUser.SecondName;
            }
            if (newUser.PhoneNumber is not null && userToUpdate.PhoneNumber != newUser.PhoneNumber)
            {
                userToUpdate.PhoneNumber = newUser.PhoneNumber;
            }
            if (newUser.FirstName is not null && userToUpdate.FirstName != newUser.FirstName)
            {
                userToUpdate.FirstName = newUser.FirstName;
            }
            if (newUser.Email is not null && userToUpdate.Email != newUser.Email)
            {
                userToUpdate.Email = newUser.Email;
            }
            if (newUser.Password is not null && userToUpdate.Password != newUser.Password)
            {
                userToUpdate.Password = newUser.Password;
            }
            if (userToUpdate.IsDeleted.HasValue && userToUpdate.IsDeleted.Value != newUser.IsDeleted)
            {
                userToUpdate.IsDeleted = newUser.IsDeleted;
            }
        }
    }

    public async Task Delete(int id)
    {
        var user = await _context.Users.FindAsync(id)
            ?? throw new Exception($"Unable to find the user with id {id}");

        user.IsDeleted = user.IsDeleted.HasValue && user.IsDeleted.Value
             ? throw new Exception($"Unable to delete the user with id {id}")
             : true;

        await _context.SaveChangesAsync();
    }
}
