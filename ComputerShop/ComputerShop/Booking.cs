﻿using System;

namespace ComputerShop
{
    public class Booking
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ItemId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
    }
}
