using Flunt.Notifications;
using Flunt.Validations;
using Dinglo.Domain.Commands.Contracts;
using System;

namespace Dinglo.Domain.Commands
{
    public class DeleteCustContactCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Id, "Id", "Favor informar o Id do endereço."));
        }
    }
}
