namespace Tommeplan.Domene
{
    public class Address
    {
        public Address(string road, string city, int id)
        {
            Road = road;
            City = city;
            Id = id;
        }

        public string Road { get; set; }
        public int Id { get; set; }
        public string City { get; set; }
    }
}
