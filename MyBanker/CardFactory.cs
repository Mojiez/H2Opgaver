using MyBanker.Accounts;
using MyBanker.Cards;
using MyBanker.Customers;
using MyBanker.Generators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    public class CardFactory
    {
        private static object controle = new object();
        private static CardFactory _factory = null;
        public static CardFactory Factory
        {
            get
            {
                lock (controle)
                {
                    if (_factory == null)
                    {
                        _factory = new CardFactory();
                        return _factory;
                    }
                    else
                    {
                        return _factory;
                    }
                }
            }
        }
        /// <summary>
        /// Creates a card with a customer on it
        /// based on input 
        /// </summary>
        /// <param name="cardType"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Card CreateCard(string cardType, Customer customer)
        {
            Card card = null;
            switch (cardType)
            {
                case "Maestro":
                    return CreateMaestro(customer, customer.Accounts[0]);

                case "MasterCard":
                    return CreateMasterCard(customer, customer.Accounts[0]);

                case "VISA":
                    return CreateVISA(customer, customer.Accounts[0]);

                case "DebitCard":
                    return CreateDebitCard(customer, customer.Accounts[0]);

                case "VISAElectron":
                    return CreateVISAElectron(customer, customer.Accounts[0]);

                default:
                    break;
            }
            return card;
        }

        /// <summary>
        /// Creates a Maestro card based on customer name and account number
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        private Maestro CreateMaestro(Customer customer, Account account)
        {
            if (DateTime.Now.Year - customer.BirthDate.Year >= 18)
                return new Maestro(customer.Name, "Maestro", account.Number);
            else
                return null;
        }
        /// <summary>
        /// Creates a Debit card based on customer name and account number
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        private DebitCard CreateDebitCard(Customer customer, Account account)
        {
            return new DebitCard(customer.Name, "DebitCard", account.Number);
        }
        /// <summary>
        /// Creates a VISA card based on customer name and account number
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        private VISA CreateVISA(Customer customer, Account account)
        {
            if (DateTime.Now.Year - customer.BirthDate.Year >= 18)
                return new VISA(customer.Name, "VISA", account.Number);
            else return null;
        }
        /// <summary>
        /// Creates a VISAElectron card based on customer name and account number
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        private VISAElectron CreateVISAElectron(Customer customer, Account account)
        {
            if (DateTime.Now.Year - customer.BirthDate.Year > 15)
                return new VISAElectron(customer.Name, "VISAElectron", account.Number);
            else return null;
        }
        /// <summary>
        /// Creates a MasterCard based on customer name and account number
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        private MasterCard CreateMasterCard(Customer customer, Account account)
        {
            if (DateTime.Now.Year - customer.BirthDate.Year > 18)
                return new MasterCard(customer.Name, "MasterCard", account.Number);
            else return null;
        }
    }
}
