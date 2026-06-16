using System.Security.Cryptography.X509Certificates;

namespace OOP_Part1
{
    
    public class Room
    {
        public int roomNumber;
        public string roomType;
        public double pricePerNight;
        public bool isAvailable;

        public Room(int roomNum, string Type , double price , bool availability)
        {
            roomNumber = roomNum;
            roomType = Type;
            pricePerNight = price;
            isAvailable = availability;
        }

        
    }

    internal class Program
    {
        static int choice;
        static bool flag = true;
        static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("""
                ================================================
                GRAND VISTA HOTEL — MANAGEMENT SYSTEM
                ================================================
                """);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("""
                1. Add New Room
                2. Register New Guest
                3. Book a Room for a Guest
                """);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("""
                4. Search & Filter Rooms
                5. Guest & Booking Statistics
                """);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("""
                6. Check Out a Guest
                7. Remove Unavailable Rooms
                """);
            
            Console.ResetColor();
            Console.WriteLine("0. Exit");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("""
                ================================================
                Enter your choice:
                """);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            while (flag)
            {
                MainMenu();
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ResetColor();
                    choice = -1;
                }
                
                switch (choice)
                {

                    //Add New Room
                    case 1:
                        break;

                    //Register New Guest
                    case 2:
                        break;

                    //Book a Room for a Guest
                    case 3:
                        break;

                    //Search & Filter Rooms
                    case 4:
                        break;

                    //Guest & Booking Statistics
                    case 5:
                        break;

                    //Check Out a Guest
                    case 6:
                        break;

                    //Remove Unavailable Rooms
                    case 7:
                        break;

                    //Exception error
                    case -1:
                        break;

                    //Exit the system
                    case 0:
                        Console.WriteLine("Thank you for using our system");
                        flag = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Option");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("Please Press Any Key to Continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
