//The File Name  RegisterUsers.cs
namespace VibeBooks.Application.UseCases.Users;

public class UserService
{
    public void Register(params string[] usernames)
    {
        ArgumentNullException.ThrowIfNull(usernames);

        foreach (var name in usernames)
        {
            Console.WriteLine($"The following Person is Registered user: {name}.");
        }
    }
}
