using BackEnd.Domain.Core.Attributes;

namespace BackEnd.Domain.Entities.User.Enums;

public enum UserType
{
    NotSet = 0,

    [StringValue("Cliente")]
    UserType = 1,

    [StringValue("Funcionário")]
    Employee = 2,

    [StringValue("Empresa Contratada")]
    ContractedCompany = 3
}
