using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_2
{
    public class Ticket
    {
        private string movieName;
        private typeOFTicket type;
        private seatLocation seat;
        private double price;

        public static int ticketCounter = 0;
        public int ticketID { get; }


        public Ticket(string movieName, typeOFTicket type, seatLocation seat, double price)
        {
            this.movieName = movieName;
            this.type = type;
            this.seat = seat;
            this.price = price;
            ++ticketCounter;
            this.ticketID = ticketCounter;
        }

        public Ticket(string moviname)
        {
            this.movieName = moviname;
            this.type = typeOFTicket.Standard;
            this.seat = new seatLocation('A', 1);
            this.price = 50;
            ++ticketCounter;
            this.ticketID = ticketCounter;
        }


        public string MovieName
        {
            get { return movieName; }
            set {
                if (value!= null || value !=  "")
                {
                    movieName = value;
                }
            }
        }
        
        public typeOFTicket Type
        {
            get { return type; }
            set { type = value; }
        }

        public seatLocation Seat
        {
            get { return seat; }
            set { seat = value; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }

        public double PriceAfterTax
        {
            get { return price * 1.14; }
        }




        public double CalcTotal(double taxPercent)
        {
            double TaxPercent = price * taxPercent / 100;
            return price + TaxPercent;
        }

        public void ApplayDiscount(ref double discountAmount)
        {
            if (discountAmount > 0 && discountAmount <= price)
            {
                price -= discountAmount;
                discountAmount = 0;

            }
            else
                return;
        }

        public void printTicket()
        {
            Console.Write($"ticket id : {ticketID} | ");
            Console.Write($"Movie Name: {movieName} |");
            Console.Write($"Ticket Type: {type} |");
            Console.Write($"Seat Location: Row {seat.row}, Seat {seat.seatnumber} |");
            Console.Write($"Price: {price} |");
            Console.Write($"Price after tax: {PriceAfterTax}");
            Console.WriteLine( " ");
        }

        public static int GetTotalTicketsSold()
        {
            return ticketCounter;
        }

    }
}
