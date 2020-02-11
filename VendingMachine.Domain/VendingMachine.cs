using System;
using System.Linq;
using static VendingMachine.Domain.Money;

namespace VendingMachine.Domain
{
    /// <summary>
    /// Author      : Emmanuel Nuyttens
    /// Date        : 02-2020
    /// Purpose     : Vendingmachine
    /// </summary>
    public class VendingMachine : Entity
    {
        public Money MoneyInside { get; set; } = None;
        public Money MoneyInTransaction { get; set; } = None;

        public virtual void InsertMoney(Money money)
        {
            Money[] euroCentsAndCoins =
            {
                FiveEuroCent,TenEuroCent,TwentyEuroCent,FiftyEuroCent,OneEuroCoin,TwoEuroCoin
            };

            if (!euroCentsAndCoins.Contains(money))
            {
                throw new InvalidOperationException();
            }

            MoneyInTransaction += money;
        }

        public virtual void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public virtual void Vend()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }

        public virtual void InitializeMoneyInside(Money money)
        {
            MoneyInside = money;
        }
    }
}
