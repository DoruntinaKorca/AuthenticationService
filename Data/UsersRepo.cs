
using AuthenticationService.Models;
using AuthenticationService.Persistence;
using System;
using System.Linq;

public class UsersRepo : IUsersRepo
{
    private readonly AuthenticationContext _context;

    public UsersRepo(AuthenticationContext context)
    {
        _context = context;
    }

    public void CreateUser(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        _context.Users.Add(user);
    }

    public void DeleteUser(User user)
    {
       var us= _context.Users.FirstOrDefault(x => x.Id == user.Id);
        _context.Users.Remove(us);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public bool UserExists(string id)
    {
        return _context.Users.Any(x => x.Id == id);
    }
}
