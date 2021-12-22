using Flunt.Notifications;
using Flunt.Validations;
using Dinglo.Domain.Commands.Contracts;
using System.Collections.Generic;
using Dinglo.Domain.Models;
using System;

namespace Dinglo.Domain.Commands
{
    public class DeleteCustAccountCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Id, "Id", "Favor informar o Id do cliente."));
        }
    }
}
