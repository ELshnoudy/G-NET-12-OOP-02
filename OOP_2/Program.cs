using System.Security.Cryptography.X509Certificates;

namespace OOP_2
{
    public enum typeOFTicket
    {
        Standard = 1,
        VIP,
        IMAX
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 : Theoretical Questions

            #region Q1
            // Consider the following class:
            //    Public class bsnkAccount
            //{
            //    public string owner;
            //    public double balance;
            //    public void withdraw(double amount)
            //    {
            //        balance -= amount;
            //    }
            //}
            //a) Identify at least two problems with this design from an encapsulation perspective.
            // the balance is public, it should be private and accessed through a method
            // method withdraw should check if the balance is valid  before withdrawing

            //b) Describe how you would fix this class to follow proper encapsulation principles. You do not need to write the full code.
            // i will make balance private and add method to get and set balance and same for owner
            // and check the balance before withdrawing

            //) Explain why exposing fields directly (as public) is considered a bad practice in OOP.
            // the filds can access from anywhere and can be modified without any control, this have security issues
            #endregion

            #region Q2
            // What is the difference between a field and a property in C#? Can a property contain logic?
            // Give an example of a read-only property that returns a calculated value.
            // field is a variable that is declared directly in a class or struct,
            // property a class member that provides controlled access to data .
            // A property can contain logic in its get and set accessors.
            //private int num;

            //public int Id
            //{
            //    get { return num*3; }         

            //}

            #endregion

            #region Q3
            //Look at the following code and answer the questions below:
            //    Public class studentRegister
            //{
            //    private string[] names = new string[5];
            //    Public string this[int index]
            //    {
            //        get { return names[index]; }
            //        set { names[index] = value; }
            //    }
            //}

            //a) What is `this[int index]` called? Explain its purpose.
            // An indexer lets an object be accessed using array-like syntax ([]), just like lists or arrays.

            // b) What happens if someone writes `register[10] = "Ali";` ? How would you make the indexer safer?
            // it will throw exception because capacity of the array is 5,
            // to make it safer we can check the index before accessing the array 

            //c) Can a class have more than one indexer? If yes, give an example of when that would be useful.
            // yes A class can have multiple indexers with different parameter types
            //    public class Matrix
            //{
            //    private int[,] _data = new int[3, 3];

            //    public int this[int row, int col]       // 2 parameters!
            //    {
            //        get { return _data[row, col]; }
            //        set { _data[row, col] = value; }
            //    }
            //}




            #endregion

            #region Q4
            // Consider the following code and answer the questions below:
            //    Public class order
            //{
            //    public static int totalOrders = 0;
            //    public string items;
            //    public order(string items)
            //    {
            //        items = items;
            //        totalOrders++;
            //    }
            //}

            //a) What does the `static` keyword mean on `TotalOrders`? How is it different from the `Item` field?
            //static means the prop can be accessed without creating an instance of the class not specific object item belong to 
            // specific object and can be different for each object

            //b) Can a static method inside `Order` access the `Item` field directly? Why or why not?
            //no because it is not static and belong to specific object and static method can be accessed without any object




            #endregion

            #endregion


            #region Part 02 : Practical (Extending the Movie Ticket Booking System)


            Cinema cinema = new Cinema();
            for (int i = 1; i < 4; i++) 
            {
                Console.WriteLine($"please enter details for ticket {i}");
                Console.Write("please enter the Movie Name :");
                string movieName = Console.ReadLine()!;
                Console.Write("please Enter Ticket Type (1 = standard, 2 = vip, 3 = imax): ");
                int ticketTypeInput;
                int.TryParse(Console.ReadLine()!, out ticketTypeInput);
                typeOFTicket ticketType = (typeOFTicket)ticketTypeInput;
                Console.Write("please enter the seat row: ");
                char seatRow = Console.ReadLine()![0];
                Console.Write("please enter the seat number: ");
                int seatNumber;
                int.TryParse(Console.ReadLine()!, out seatNumber);
                seatLocation seat = new seatLocation(seatRow, seatNumber);
                Console.Write("please enter the ticket price: ");
                double ticketPrice;
                double.TryParse(Console.ReadLine()!, out ticketPrice);
                Ticket ticket = new Ticket(movieName, ticketType, seat, ticketPrice);
                cinema.AddTicket(ticket);
                Console.WriteLine(" ");
            }

            for(int i = 0;i < 3; i++)
            {
                Console.WriteLine($"ticket{i+1}");
                cinema[i].printTicket();
            }

            Console.Write("please enter movie name: ");
            string moviesName = Console.ReadLine()!;

            Ticket isFound = cinema.getMovieByName(moviesName);

            if (isFound != null)
            {
                Console.Write($"Found: ");
                isFound.printTicket();
            }
            else
                Console.WriteLine("this movie not founded");


            Console.WriteLine("total tickets sold: " + Ticket.GetTotalTicketsSold());
            Console.WriteLine("Booking Reference 1: " + BookingHelper.GenerateBookingReference());
            Console.WriteLine("Booking Reference 2: " + BookingHelper.GenerateBookingReference());
            double groupPrice = BookingHelper.CalcGroupDiscount(5, 80);
            Console.WriteLine("Group Discount Price (5 tickets * 80): " + groupPrice);






            #endregion


        }
    }
}
