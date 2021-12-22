using Flunt.Notifications;
using Flunt.Validations;
using Dinglo.Domain.Commands.Contracts;
using System.Collections.Generic;
using Dinglo.Domain.Models;
using System;

namespace Dinglo.Domain.Commands
{
    public class UpdateCustAccountCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string IdentityDocumentNr { get; set; }
        public string WebSite { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Id, "Id", "Favor informar o Id do cliente.")
                .IsNotNull(Name, "Name", "Favor informar o nome do cliente.")
                .IsNotNull(IdentityDocumentNr, "IdentityDocumentNr", "Favor informar o número de identidade do cliente.")
                .IsNotNull(Email, "Email", "Favor informar o email do cliente."));
        }
    }
}
