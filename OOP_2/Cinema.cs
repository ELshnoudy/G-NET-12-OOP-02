using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OOP_2
{
    public class Cinema
    {
        private Ticket[] tickets = new Ticket[20];


        public Ticket this[int Index]
        {
            get
            {
                if (Index < tickets.Length && Index >= 0)
                {
                    return tickets[Index];
                }
                else {
                    return null;
                }
            }
            set
            {
                if (Index < tickets.Length && Index >= 0)
                {
                    tickets[Index] = value;
                }
            }
        }


        public Ticket getMovieByName(string Name)
        {
            foreach (var item in tickets)
            {
                if (item.MovieName == Name)
                {
                    return item;
                }
            }
            return null;
          }


        public bool AddTicket(Ticket t)
        {
            for(int i =0;i< tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return true;
                }
            }
            return false;
        }
    }
}
