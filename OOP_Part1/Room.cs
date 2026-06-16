using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Part1
{
    public class Room
    {
        public int roomNumber;
        public string roomType;
        public double pricePerNight;
        public bool isAvailable;

        public Room(int roomNum, string Type, double price, bool availability)
        {
            roomNumber = roomNum;
            roomType = Type;
            pricePerNight = price;
            isAvailable = availability;
        }

        public void DisplayRoom()
        {
            Console.WriteLine($"""
                Room Number: {roomNumber}
                Room Type: {roomType}
                Price Per Night: {pricePerNight}
                Status: {isAvailable}
                """);
        }
    }
}
