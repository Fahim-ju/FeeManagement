﻿namespace firstApi.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int TotalFine { get; set; }

        public int Paid { get; set; }
        public int Due { get; set; }
    }
}
