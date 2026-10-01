using BackEnd.Domain.Common.Entities;
using BackEnd.Domain.Entities.User.Enums;

namespace BackEnd.Domain.Entities.User;

public class User : BaseEntity
{
    public string UserName { get; private set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string PasswordHash { get; private set; }

    public UserType UserType { get; private set; }
}
