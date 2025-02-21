public class ContactRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }

    public ContactRequest() { }

    public ContactRequest(string name, string email, string phone, string message)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Message = message;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Email: {Email}, Phone: {Phone}, Message: {Message}";
    }
}
