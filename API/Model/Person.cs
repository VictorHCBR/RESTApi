namespace API.Model;

public class Person
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Address Address { get; set; } = new Address();
    public string Gender { get; set; } = string.Empty;
}
