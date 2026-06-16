using System.Security.Cryptography.X509Certificates;

namespace OOP_Part1
{
internal class Program
    {
        //Variables Declarations
        static int choice;
        static bool flag = true;
        static int roomNumber;
        static bool validationFlag = true;
        static string roomType;
        static double pricePerNight;
        //static string guestName;
        //static string checkInDate;
        //static int numberOfNights;

        //Collections Declarations
        static List<Room> rooms = new List<Room>();
        static List<Guest> guests = new List<Guest>();

        //Methods Declarations
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
        static bool CheckIfEmpty(string name)
        {
            if (name == "")
            {
                return true;
            }
            return false;
        }
        static bool CheckIfZeroOrLess(int num)
        {
            if (num <= 0)
            {
                return true;
            }
            return false;
        }
        static bool CheckIfZeroOrLess(double num)
        {
            if (num <= 0)
            {
                return true;
            }
            return false;
        }
        //Task 1 - Add New Room   
        static bool CheckRoomExistence(int roomNum)
        {
            return rooms.Any(r => r.roomNumber == roomNum);
        }
        static void RoomTypeSubMenu()
        {
            Console.Write("""
                Choose your Room Type: 
                1. Single
                2. Double
                3. Suite
                Enter your Number:
                """);
            
        }
        static void ChooseRoomType(int num)
        {
            switch (num)
            {
                case 1:
                    roomType = "Single";
                    break;
                case 2:
                    roomType = "Double";
                    break;
                case 3:
                    roomType = "Suite";
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Option");
                    Console.ResetColor();
                    validationFlag = false;
                    break;
            }
        }  
        static void AddNewRoom()
        {
            Console.Write("Enter room Number: ");
            try
            {
                roomNumber = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                return;
            }
            if (CheckRoomExistence(roomNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Room number {roomNumber} is already in exists!!");
                Console.ResetColor();
                return;
            }

            if (CheckIfZeroOrLess(roomNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Room number can't be zero or less!!");
                Console.ResetColor();
                return;
            }

            RoomTypeSubMenu();
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)

            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                return;
            }
            ChooseRoomType(choice);

            if (!validationFlag)
            {
                validationFlag = true;
                return;
            }

            Console.Write("Please Enter the Price Per Night: ");
            try
            {
                pricePerNight = double.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                return;
            }
            if (CheckIfZeroOrLess(pricePerNight))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Price can't be zero or less!!");
                Console.ResetColor();
                return;
            }

            Room r = new Room(roomNumber, roomType, pricePerNight, true);
            rooms.Add(r);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("""
                ===========================================
                          Room Added Successfully!!
                ===========================================
                """);
            r.DisplayRoom();

            Console.WriteLine($"""
                ===========================================
                Total room Registered: {rooms.Count}
                """);
            //Console.WriteLine($"""

            //    ===========================================
            //    Room Added Successfully!!
            //    ===========================================
            //    Room Number: {roomNumber} 
            //    Room Type: {roomType}
            //    Price Per Night: {pricePerNight}
            //    ===========================================
            //    Total room Registered: {rooms.Count}
            //    """);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {

            rooms.AddRange(
                new Room(12, "Single", 20, true),
                new Room(13, "Double", 30, true),
                new Room(122, "Single", 20, true),
                new Room(123, "Double", 30, true),
                new Room(40, "Suite", 50, true),
                new Room(18, "Single", 20, true)
                );

            //Room r1 = new Room(12,"Single",20,true);
            //Room r2 = new Room(13, "Double", 30, true);
            //Room r3 = new Room(122, "Single", 20, true);
            //Room r4 = new Room(123, "Double", 30, true);
            //Room r5 = new Room(40, "Suite", 50, true);
            //Room r6 = new Room(18, "Single", 20, true);
            //rooms.AddRange(r1,r2,r3,r4,r5,r6);
            
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
                        AddNewRoom();
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
