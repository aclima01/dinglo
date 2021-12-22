using Flunt.Notifications;
using Flunt.Validations;
using Dinglo.Domain.Commands.Contracts;
using System.Collections.Generic;
using Dinglo.Domain.Models;
using System;

namespace Dinglo.Domain.Commands
{
    public class UpdateCustAddressCommand : Notifiable, ICommand
    {
        public int Id {get; set;}
        public Guid CustAccountId {get; set;}
        public string City { get; set; }
        public string Complement { get; set; }
        public string Country { get; set; }
        public string Distrinct { get; set; }
        public string Number { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public bool IsPrincipal { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Id, "Id do endereço", "Favor informar o Id do endereço.")
                .IsNotNull(City, "City", "Favor informar o City do cliente.")
                .IsNotNull(Complement, "Complement", "Favor informar o Complement do cliente.")
                .IsNotNull(Country, "Country", "Favor informar o Country do cliente.")
                .IsNotNull(Distrinct, "Distrinct", "Favor informar o Distrinct do cliente.")
                .IsNotNull(Number, "Number", "Favor informar o número do cliente.")
                .IsNotNull(State, "State", "Favor informar o State do cliente.")
                .IsNotNull(Street, "Street", "Favor informar o Street do cliente."));
        }
    }
}
