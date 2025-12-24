namespace ContactsApp.lib.models;

public class ContactItem(
    string name,
    string phoneNumber
)
{
    public string Name { get; set; } = name;
    public string PhoneNumber { get; set; } = phoneNumber;
}