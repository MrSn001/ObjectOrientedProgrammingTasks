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
        static string guestName;
        static string checkInDate;
        static int numberOfNights;
        static int nextNum;
        static string genGuestID;
        static string guestId;
        static Room targetRoom;
        static Guest targetGuest;
        static int roomCount;
        static double avgPrice;
        static double maxPrice;
        static double minPrice;
        //Collections Declarations
        static List<Room> rooms = new List<Room>();
        static List<Guest> guests = new List<Guest>();
        static List<Room> roomFilter = new List<Room>();

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


        //Task 2 - Register New Guest
        static string GenerateGuestID()
        {
            nextNum = guests.Count + 1;
            genGuestID = $"G{nextNum:D3}";
            return genGuestID;
        }
        static void RegisterNewGuest()
        {
            Console.Write("Enter guest name: ");
            try
            {
                guestName = Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                return;
            }
            if (CheckIfEmpty(guestName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Guest name can't be empty");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("Enter the check-in date(dd/MM/yyyy): ");
            try
            {
                checkInDate = Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                return;
            }
            if (CheckIfEmpty(checkInDate))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Check-in date can't be empty");
                Console.ResetColor();
                return;
            }


            Console.WriteLine("Enter number of nights: ");
            try
            {
                numberOfNights = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                return;
            }
            if (CheckIfZeroOrLess(numberOfNights))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number of nights can't be zero or less");
                Console.ResetColor();
                return;
            }

            guestId = GenerateGuestID();

            Guest g = new Guest(guestId,guestName,"Not Assigned",checkInDate,numberOfNights);

            guests.Add(g);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("""
                ===========================================
                      Guest Registered Successfully!!
                ===========================================
                """);
            g.DisplayGuest();
            Console.WriteLine($"""
                ===========================================
                """);

        }

        //Task 3 - Book a Room for a Guest
        static void FindGuestID(string guestID)
        {
           if( guests.FirstOrDefault(g => g.guestId == guestID) == null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"The guest ID {guestID} is not found");
                Console.ResetColor();
                validationFlag = false;
                return;
            }
            targetGuest = guests.FirstOrDefault(g => g.guestId == guestID);
        }

        static void FindRoomNumber(int roomNum)
        {
            if (!rooms.Any(r => r.roomNumber == roomNum))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The room number {roomNum} is not found");
                Console.ResetColor();
                validationFlag = false;
                return;
                
            }
            targetRoom = rooms.FirstOrDefault(g => g.roomNumber == roomNum);
           

        }

        static double CalculateTotalCost(int totalNights,double pricePerNight)
        {
            return (totalNights * pricePerNight);
        }
        
        static void BookRoom()
        {
            if(guests.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Registered Guest!!");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter Guest ID: ");
            try
            {
                guestId = Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                return;
            }
            FindGuestID(guestId);
            if (!validationFlag)
            {
                validationFlag = true;
                return;
            }

            Console.Write("Enter Room Number: ");
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
            FindRoomNumber(roomNumber);
            if (!validationFlag)
            {
                validationFlag = true;
                return;
            }
            if (!targetRoom.isAvailable)
            {
                Console.WriteLine("Room is already booked.");
                return;
            }
            
            targetRoom.isAvailable = false;
            targetGuest.roomNumber = targetRoom.roomNumber.ToString();
            double totalPrice = CalculateTotalCost(targetGuest.totalNights, targetRoom.pricePerNight);

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Room Booked Successfully!!");
            Console.Write($"Guest Name: {targetGuest.guestName} | Room Number: {targetGuest.roomNumber} | Room Type: {targetRoom.roomType}");
            Console.WriteLine($" | Price Per Night: {targetRoom.pricePerNight} | Total Nights: {targetGuest.totalNights} | Total Cost: {totalPrice}");
            Console.ResetColor();

        }

        //Task 4 - Search & Filter Rooms
        static void SearchAndFilterSubMenu()
        {
            Console.Write("""
                Choose your Search and Filter Type: 
                1. Show all available rooms.
                2. Filter by room type.
                3. Filter by max price.
                4. Room price statistics.
                0. Back.
                Enter your Number:
                """);

        }

        static List<Room> ChcekAvailableRooms()
        {
            return rooms.Where(r => r.isAvailable == true).OrderBy(r => r.pricePerNight).ToList();
        }
        static void SearchAndFilterSwitch(int num)
        {
            switch (num)
            {
                case 1:
                    roomFilter = ChcekAvailableRooms();
                    Console.WriteLine("Available Rooms: ");
                    foreach(Room room in roomFilter)
                    {
                        Console.WriteLine($"Room Number: {room.roomNumber} | Room Type: {room.roomType} | Price Per Night: {room.pricePerNight} ");
                    }
                    Console.WriteLine("Total of Available Rooms: " + roomFilter.Count);
                    break;
                case 2:
                    Console.Write("Enter Room Type: ");
                    try
                    {
                        roomType = Console.ReadLine().ToLower();
                    }
                    catch(FormatException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: " + ex.Message);
                        Console.ResetColor();
                        break;
                    }
                    
                    if(roomType != "single" && roomType != "double" && roomType != "suite")
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine($"There is no {roomType} type room!!");
                        Console.ResetColor();
                        break;
                    }

                    if (!rooms.Any(r => r.roomType.ToLower() == roomType))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"There is no Room with the {roomType} Type!!");
                        Console.ResetColor();
                        break;
                    }

                    roomFilter = rooms.Where(r => r.roomType.ToLower() == roomType).ToList();
                    foreach (Room room in roomFilter)
                    {
                        Console.WriteLine($"Room Number: {room.roomNumber} | Room Type: {room.roomType} | Price Per Night: {room.pricePerNight} ");
                    }
                    Console.WriteLine($"Total of {roomType} Rooms: " + roomFilter.Count);
                    break;
                case 3:
                    Console.Write("Enter your maximum price: ");
                    try
                    {
                        pricePerNight = Double.Parse(Console.ReadLine());
                    }
                    catch(FormatException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: " + ex.Message);
                        Console.ResetColor();
                        break;
                    }

                    if (CheckIfZeroOrLess(pricePerNight))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Price Can't be zero or negative!!");
                        Console.ResetColor();
                        break;
                    }

                    roomFilter = rooms.Where(r => r.pricePerNight <= pricePerNight).OrderBy(r => r.pricePerNight).ToList();

                    foreach (Room room in roomFilter)
                    {
                        Console.WriteLine($"Room Number: {room.roomNumber} | Room Type: {room.roomType} | Price Per Night: {room.pricePerNight} ");
                    }
                    Console.WriteLine($"Total rooms that are equal to or less than {pricePerNight} are: " + roomFilter.Count);
                    break;
                case 4:
                    Console.WriteLine("");
                    avgPrice = rooms.Average(r => r.pricePerNight);
                    maxPrice = rooms.Max(r => r.pricePerNight);
                    minPrice = rooms.Min(r => r.pricePerNight);

                    Console.WriteLine("Total Rooms Count: " + rooms.Count);
                    roomFilter = rooms.Where(r => r.isAvailable == true).ToList();
                    Console.WriteLine("Total Available Rooms Count: " + roomFilter.Count);
                    Console.WriteLine("Average Price: " + avgPrice);
                    Console.WriteLine("Maximum Price: " + maxPrice);
                    Console.WriteLine("Minimum Price: " + minPrice);
                    break;
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Search Cancelled!!");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Option");
                    Console.ResetColor();
                    validationFlag = false;
                    break;
            }
        }

        static void SearchAndFilter()
        {
            SearchAndFilterSubMenu();
            choice = int.Parse( Console.ReadLine() );
            SearchAndFilterSwitch(choice);

        }

        //Task 5 - Guest & Booking Statistics
        static List<Guest> CheckRegisteredGuestsWhoHaveARoomAssigned()
        {
            return guests.Where(g => g.roomNumber != "Not Assigned").ToList();
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
                        RegisterNewGuest();
                        break;

                    //Book a Room for a Guest
                    case 3:
                        BookRoom();
                        break;

                    //Search & Filter Rooms
                    case 4:
                        SearchAndFilter();
                        break;

                    //Guest & Booking Statistics
                    case 5:
                        Console.WriteLine("Total Registered Guests: " + guests.Count);
                        Console.WriteLine("Total Guests Who Currently Have a Room Assigned: " + CheckRegisteredGuestsWhoHaveARoomAssigned().Count);
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
