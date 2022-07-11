using AuthenticationService.Models;
using System;

public interface IUsersRepo
{

    bool UserExists(string id);

    void CreateUser(User user);

    bool SaveChanges();

    void DeleteUser(User user);
}