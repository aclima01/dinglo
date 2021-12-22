using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using Dinglo.Domain.Commands;
using Dinglo.Domain.Commands.Contracts;
using Dinglo.Domain.Entities.Account;
using Dinglo.Domain.Handlers.Contracts;
using Dinglo.Domain.Repositories;
using Dinglo.Domain.Repositories.AGRO_HerdManagerRepositories;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Authorizations;

namespace Dinglo.Domain.Handlers
{
    public class AppUserHandler : Notifiable, IHandler<CreateAppUserCommand>
    {
        private readonly ICustAccountRepository _custAccountRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthUser _authUser;

        public AppUserHandler(
                 ICustAccountRepository custAccountRepository,
                 IUserRepository userRepository,
                 UserManager<UserIdentity> userManager,
                 RoleManager<IdentityRole> roleManager,
                 IAuthUser authUser
                )
        {
            _custAccountRepository = custAccountRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _authUser = authUser;
        }

        public ICommandResult Handle(CreateAppUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro na validação do request", command.Notifications,
                    StatusCodes.Status400BadRequest);

            var roles = new List<string>();

            roles.Add($"cust_{command.CustAccountId.ToString()}");

            var identity = _authUser.CreateUser(command.Email, command.Email, command.Password, roles).Result;

            var appUser = new AppUser
            {
                FullName = command.Fullname,
                IdentityDocumentNr = command.IdentityDocumentNr,
                AspNetUserIdentityId = identity.Id,
                RoleDefault = roles.FirstOrDefault()
            };

            _userRepository.Create(appUser);

            // Retorna o resultado
            return new GenericCommandResult(true, "Usuário criado com sucesso", true,
                StatusCodes.Status200OK);
        }
    }
}