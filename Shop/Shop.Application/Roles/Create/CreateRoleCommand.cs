using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.RoleAgg;

namespace Shop.Application.Roles.Create
{
    public record CreateRoleCommand(string Title , List<Permission> Permissions):IBaseCommand;
}
