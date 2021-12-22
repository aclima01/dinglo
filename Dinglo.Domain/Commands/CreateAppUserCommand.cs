using Flunt.Notifications;
using Flunt.Validations;
using Dinglo.Domain.Commands.Contracts;
using System.Collections.Generic;
using Dinglo.Domain.Models;
using System;

namespace Dinglo.Domain.Commands
{
    public class CreateAppUserCommand : Notifiable, ICommand
    {
        public Guid CustAccountId { get; set; }
        public string Fullname { get; set; }
        public string IdentityDocumentNr { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(CustAccountId, "Id do Cliente", "Favor informar o Id do cliente.")
                .IsNotNull(Fullname, "Fullname", "Favor informar o nome.")
                .IsNotNull(Email, "Email", "Favor informar o email.")
                .IsNotNull(Password, "Password", "Favor informar a senha."));
        }
    }
}
