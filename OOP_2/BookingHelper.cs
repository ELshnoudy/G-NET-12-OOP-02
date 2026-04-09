using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_2
{
    public static class BookingHelper
    {
        private static int counter = 0;
        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            double totalPrice = numberOfTickets * pricePerTicket;
            if (numberOfTickets >= 5)
            {
                totalPrice -= (totalPrice * 10 / 100);
            }
                return totalPrice;
        }

        public static string GenerateBookingReference()
        {
            counter++;
            return $"BK-{counter}";
        }
    }
}
