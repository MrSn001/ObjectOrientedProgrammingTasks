using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Part1
{
    public class Guest
    {
        public int guestId { get; set; }
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
    }
}
