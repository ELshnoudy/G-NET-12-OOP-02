using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_2
{
    public struct seatLocation
    {
        public char row;
        public int seatnumber;

        public seatLocation(char row, int number)
        {
            row = row;
            seatnumber = number;
        }
    }
}
