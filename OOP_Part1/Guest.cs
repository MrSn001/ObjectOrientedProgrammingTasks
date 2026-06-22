using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Part1
{
    public class Guest
    {
        public string guestId { get; set; }
        public string guestName { get; set; }
        public string roomNumber { get; set; }
        public string checkInDate { get; set; }
        public int totalNights { get; set; }

        public Guest(string id, string name, string roomNum, string checkIn, int totalNights)
        {
            guestId = id;
            guestName = name;
            roomNumber = roomNum;
            checkInDate = checkIn;
            this.totalNights = totalNights;
        }

        public void DisplayGuest()
        {
            Console.WriteLine($"""
                Guest ID: {guestId}
                Guest Name: {guestName}
                Room Number: {roomNumber}
                Check-In Date: {checkInDate}
                Total Nights Booked: {totalNights}
                """);
        }

        public double CalculateTotalCost(List<Room> roomsList)
        {
            Room matchingRoom = roomsList.Find(r => r.roomNumber.ToString() == this.roomNumber);
            if (matchingRoom != null)
            {
                return matchingRoom.pricePerNight * this.totalNights;
            }

            return 0.0;
        }
    }
}
