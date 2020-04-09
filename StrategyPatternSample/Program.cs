using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var basket = new EShopBasket();

            var amount = 32.32m;

            Console.Write("How would you like to pay? 1) CC, 2) PayPal, 3) ApplePay : ");
            var input = int.Parse(Console.ReadLine().Trim());
            switch (input)
            {
                case 1:
                    basket.SelectPaymentMethod(new CreditCard());
                    break;

                case 2:
                    basket.SelectPaymentMethod(new PayPal());
                    break;

                case 3:
                    basket.SelectPaymentMethod(new ApplePay());
                    break;

                default:
                    basket.SelectPaymentMethod(new CreditCard());
                    break;

            }

            basket.SetDueAmount(amount);
            var success = basket.Pay();
            Console.WriteLine(success);
            Console.Read();

        }
    }
}
