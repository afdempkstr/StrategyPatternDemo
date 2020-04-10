﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPatternSample
{
    class EShopBasket
    {
        private PaymentMethod _paymentMethod;
        private decimal _dueAmount;

        public void SelectPaymentMethod(PaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public void SetDueAmount(decimal amount)
        {
            _dueAmount = amount;
        }

        public bool Pay()
        {
            return _paymentMethod.Pay(_dueAmount);
        }
    }

    class Eshop
    {
        public static void EShopDemo()
        {
            var basket = new EShopBasket();
            var amount = 32.32m;
            basket.SetDueAmount(amount);

            Console.Write("How would you like to pay? 1) CC, 2) PayPal, 3) ApplePay : ");
            var input = int.Parse(Console.ReadLine().Trim());
            bool success = PayBasket(basket, input);

            if (success)
            {
                Console.Write("Please select the shipment method (1=PostOffice, 2=Courier, 3=Own, 4=Pickup:");
                var carrierType = (CarrierType) int.Parse(Console.ReadLine().Trim());
                if (carrierType != CarrierType.Pickup)
                {
                    Console.Write("Please give your address:");
                    var address = Console.ReadLine().Trim();
                    var shipment = new Shipment();
                    if (shipment.CanShipTo(address, carrierType))
                    {
                        shipment.DeliverOrder(address, basket);
                    }
                }
            }



            Console.WriteLine(success);
            Console.Read();
        }

        private static bool PayBasket(EShopBasket basket, int input)
        {
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
            var success = basket.Pay();
            return success;
        }
    }

    // Order shipment subsystem
    class Shipment
    {
        public bool CanShipTo(string address, CarrierType carrier)
        {
            return false;
        }

        public void DeliverOrder(string address, EShopBasket basket)
        {

        }
    }

    enum CarrierType
    {
        PostOffice = 1,
        Courier = 2,
        OwnDelivery = 3,
        Pickup = 4
    }
}
