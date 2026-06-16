using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Part1
{
    public class Guest
    {
        public int guestId;
        public string guestName;
        public int roomNumber;
        public DateOnly checkInDate;
        public int totalNights;

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
