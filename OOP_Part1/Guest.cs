using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Part1
{
    public class Guest
    {
        public string guestId { get; set; }
        public string guestName { get; set; }
        public int roomNumber { get; set; }
        public DateOnly checkInDate { get; set; }
        public int totalNights { get; set; }

        public Guest(int id, string name, int roomNum, DateOnly checkIn, int totalNights)
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
                Check-In Date: {checkInDate.ToString("dd-MMM-yyyy")}
                Total Nights Booked: {totalNights}
                """);
        }

        public double CalculateTotalCost(double pricePerNight)
        {
            return pricePerNight * totalNights;
        }
    }
}
