using System.Runtime.CompilerServices;
using ContactsApp.lib.models;
using ContactsApp.lib.ui;
using Spectre.Console;

namespace ContactsApp.lib.state;

interface IContactsState
{
    List<ContactItem> Contacts { get; }
    public void AddContact(ContactItem contact);
    public void UpdateContact(int id, ContactItem contact);
    public void RemoveContact(int id);
    public void SortContacts();
    List<ContactItem> Filtered(string query);
}

public class ContactsState : IContactsState
{
    public List<ContactItem> Contacts { get; private set; } = [];
    public ContactsState(List<ContactItem>? initialData = null)
    {
        if (initialData != null)
        {
            Contacts = initialData;
        }
    }

    public void AddContact(ContactItem contact)
    {
        Contacts.Add(contact);
    }

    public void UpdateContact(int id, ContactItem contact)
    {
        Contacts[id] = contact;
    }

    public void RemoveContact(int id)
    {
        Contacts.RemoveAt(id);
    }

    public void SortContacts()
    {
        var items = Contacts;

        for (int i = 1; i < items.Count; i++)
        {
            for (int j = 0; j < items.Count - 1; j++)
            {
                // Sort alphabetically with the first letter of the contact name
                if (items[j].Name.ToLower()[0] > items[j + 1].Name.ToLower()[0])
                {
                    // swap items:
                    (items[j + 1], items[j]) = (items[j], items[j + 1]);
                }
            }
        }

        Contacts = items;
    }

    public List<ContactItem> Filtered(string query)
    {
        var filteredItems = new List<ContactItem> { };
        foreach (var item in Contacts)
        {
            if (item.Name.Contains(query)) filteredItems.Add(item);
        }
        return filteredItems;
    }
}