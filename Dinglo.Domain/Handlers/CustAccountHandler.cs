using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Dinglo.Domain.Commands;
using Dinglo.Domain.Commands.Contracts;
using Dinglo.Domain.Entities.Account;
using Dinglo.Domain.Handlers.Contracts;
using Dinglo.Domain.Repositories;
using Dinglo.Domain.Entities;
using Dinglo.Domain.Authorizations;

namespace Dinglo.Domain.Handlers
{
    public class CustAccountHandler : Notifiable, IHandler<CreateCustAccountCommand>, IHandler<CreateCustAddressCommand>, IHandler<CreateCustContactCommand>, IHandler<DeleteCustAccountCommand>,
                                                  IHandler<DeleteCustAddressCommand>, IHandler<UpdateCustAccountCommand>, IHandler<UpdateCustAddressCommand>, IHandler<UpdateCustContactCommand>
    {
        private readonly ICustAccountRepository _custAccountRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthUser _authUser;

        public CustAccountHandler(
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

        public ICommandResult Handle(CreateCustAccountCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro na validação do request", command.Notifications,
                    StatusCodes.Status400BadRequest);

            var entity = new CustAccount
            {
                Name = command.Name,
                Email = command.Email,
                IdentityDocumentNr = command.IdentityDocumentNr,
                WebSite = command.WebSite,
                PrefixKey = "TODO: Avaliar"
            };

            _custAccountRepository.Create(entity);

            if (command.Addresses.Any())
            {
                foreach (var address in command.Addresses)
                {
                    var custAddress = new CustAddress
                    {
                        CustAccountId = entity.Id,
                        Street = address.Street,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        State = address.State,
                        Country = address.Country,
                        IsPrincipal = address.IsPrincipal
                    };

                    _custAccountRepository.CreateAddress(custAddress);
                }
            }

            if (command.Contacts.Any())
            {
                foreach (var contact in command.Contacts)
                {
                    var custContact = new CustContact
                    {
                        CustAccountId = entity.Id,
                        Fullname = contact.Fullname,
                        Type = contact.Type,
                        Value = contact.Value,
                        IsPrincipal = contact.IsPrincipal
                    };

                    _custAccountRepository.CreateContact(custContact);
                }
            }

            var role = _roleManager.CreateAsync(new IdentityRole($"cust_{entity.Id}")).Result;

            // Retorna o resultado
            return new GenericCommandResult(true, "Cliente cadastrado com sucesso", true,
                StatusCodes.Status200OK);
        }

        public ICommandResult Handle(UpdateCustAccountCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro na validação do request", command.Notifications,
                    StatusCodes.Status400BadRequest);

            var entity = new CustAccount
            {
                Id = command.Id,
                Name = command.Name,
                Email = command.Email,
                IdentityDocumentNr = command.IdentityDocumentNr,
                WebSite = command.WebSite,
                PrefixKey = "TODO: Avaliar"
            };

            _custAccountRepository.Update(entity);

            // Retorna o resultado
            return new GenericCommandResult(true, "Cliente atualizado com sucesso", true,
                StatusCodes.Status200OK);
        }

        public ICommandResult Handle(DeleteCustAccountCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro na validação do request", command.Notifications,
                    StatusCodes.Status400BadRequest);

            var custAddresses = _custAccountRepository.GetCustAddresses(command.Id);
            var custContacts = _custAccountRepository.GetCustContacts(command.Id);

            foreach (var address in custAddresses)
            {
                _custAccountRepository.DeleteAddress(address.Id);
            }

            foreach (var contact in custContacts)
            {
                _custAccountRepository.DeleteContact(contact.Id);
            }

            _custAccountRepository.Delete(command.Id);

            // Retorna o resultado
            return new GenericCommandResult(true, "Cliente excluido com sucesso", true,
                StatusCodes.Status200OK);
        }

        public ICommandResult Handle(CreateCustAddressCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro na validação do request", command.Notifications,
                    StatusCodes.Status400BadRequest);

            var entity = new CustAddress
            {
                CustAccountId = command.CustAccountId,
                City = command.City,
                Complement = command.Complement,
                Country = command.Country,
                District = command.Distrinct,
                IsPrincipal = command.IsPrincipal,
                Number = command.Number,
                State = command.State,
                Street = command.Street
            };

            _custAccountRepository.CreateAddress(entity);

            // Retorna o resultado
            return new GenericCommandResult(true, "Endereço atualizado com sucesso", true,
                StatusCodes.Status200OK);
        }

        public ICommandResult Handle(UpdateCustAddressCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro na validação do request", command.Notifications,
                    StatusCodes.Status400BadRequest);

            var entity = new CustAddress
            {
                Id = command.Id,
                CustAccountId = command.CustAccountId,
                City = command.City,
                Complement = command.Complement,
                Country = command.Country,
                District = command.Distrinct,
                IsPrincipal = command.IsPrincipal,
                Number = command.Number,
                State = command.State,
                Street = command.Street
            };

            _custAccountRepository.UpdateAddress(entity);

            // Retorna o resultado
            return new GenericCommandResult(true, "Endereco atualizado com sucesso", true,
                StatusCodes.Status200OK);
        }

        public ICommandResult Handle(DeleteCustAddressCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro na validação do request", command.Notifications,
                    StatusCodes.Status400BadRequest);

            _custAccountRepository.DeleteAddress(command.Id);

            // Retorna o resultado
            return new GenericCommandResult(true, "Cliente excluido com sucesso", true,
                StatusCodes.Status200OK);
        }

        public ICommandResult Handle(CreateCustContactCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro na validação do request", command.Notifications,
                    StatusCodes.Status400BadRequest);

            var entity = new CustContact
            {
                CustAccountId = command.CustAccountId,
                Fullname = command.Fullname,
                IsPrincipal = command.IsPrincipal,
                Type = command.Type,
                Value = command.Value
            };

            _custAccountRepository.CreateContact(entity);

            // Retorna o resultado
            return new GenericCommandResult(true, "Contao atualizado com sucesso", true,
                StatusCodes.Status200OK);
        }

        public ICommandResult Handle(UpdateCustContactCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro na validação do request", command.Notifications,
                    StatusCodes.Status400BadRequest);

            var entity = new CustContact
            {
                Id = command.Id,
                CustAccountId = command.CustAccountId,
                Fullname = command.Fullname,
                IsPrincipal = command.IsPrincipal,
                Type = command.Type,
                Value = command.Value
            };

            _custAccountRepository.UpdateContact(entity);

            // Retorna o resultado
            return new GenericCommandResult(true, "Contato atualizado com sucesso", true,
                StatusCodes.Status200OK);
        }

        public ICommandResult Handle(DeleteCustContactCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Erro na validação do request", command.Notifications,
                    StatusCodes.Status400BadRequest);

            _custAccountRepository.DeleteContact(command.Id);

            // Retorna o resultado
            return new GenericCommandResult(true, "Cliente excluido com sucesso", true,
                StatusCodes.Status200OK);
        }
    }
}