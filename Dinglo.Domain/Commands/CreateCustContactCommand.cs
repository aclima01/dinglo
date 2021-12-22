using Flunt.Notifications;
using Flunt.Validations;
using Dinglo.Domain.Commands.Contracts;
using System;

namespace Dinglo.Domain.Commands
{
    public class CreateCustContactCommand : Notifiable, ICommand
    {
        public Guid CustAccountId { get; set; }
        public string Fullname { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsPrincipal { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(CustAccountId, "CustAccountId", "Favor informar o id do cliente.")
                .IsNotNull(Fullname, "Fullname", "Favor informar o nome do contato.")
                .IsNotNull(Type, "Type", "Favor informar o tipo do contato.")
                .IsNotNull(Value, "Value", "Favor informar valor do contato."));
        }
    }
}
