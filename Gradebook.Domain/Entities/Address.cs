namespace Gradebook.Domain.Entities;

public class Address : Entity
{
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}
