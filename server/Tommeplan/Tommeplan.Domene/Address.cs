﻿namespace Tommeplan.Domene
{
    public class Address
    {
        public Address(string road, string city, string id)
        {
            Road = road;
            City = city;
            Id = id;
        }

        public Address(string city, string id)
            : this(string.Empty, city, id)
        {
        }

        public string Road { get; set; }
        public string Id { get; set; }
        public string City { get; set; }
    }
}
