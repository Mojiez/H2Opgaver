using MyBanker.Accounts;
using MyBanker.Cards;
using MyBanker.Customers;
using MyBanker.Generators;
using System;

namespace MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Kenneth", new DateTime(1988, 04, 25));
            Account account = new Account();

            Maestro maestro = new Maestro(name: customer.Name, cardType: "Maestro", 19, account.Number);


            
            
            
            
        }
    }
}
