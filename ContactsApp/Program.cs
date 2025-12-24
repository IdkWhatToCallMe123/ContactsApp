
using ContactsApp.lib.models;
using ContactsApp.lib.state;
using ContactsApp.lib.ui;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ContactsApp;

class Program
{
    public static void Main(string[] args)
    {
        List<ContactItem> contacts = [
            new ContactItem(
                name: "zack",
                phoneNumber: "wowowow"
            ),
            new ContactItem(
                name: "billy",
                phoneNumber: "142015938"
            ),
            new ContactItem(
                name: "adam",
                phoneNumber: "50139852984"
            ),
            new ContactItem(
                name: "chris",
                phoneNumber: "1-48091432"
            ),
        ];

        var contactsState = new ContactsState(initialData: contacts);

        var continueLoop = true;

        while (continueLoop)
        {
            UiUtils.Clear();
            UiDisplay.Contacts(contactsState.Contacts);
            ActionType userResponse = UiPrompt.ActionMenu(contactsState.Contacts.Count == 0);

            switch (userResponse)
            {
                case ActionType.AddContact:
                    contactsState.AddContact(UiPrompt.Contact());
                    break;
                case ActionType.UpdateContact:
                    var id = UiPrompt.ContactId();
                    contactsState.UpdateContact(id, UiPrompt.Contact());
                    break;
                case ActionType.RemoveContact:
                    contactsState.RemoveContact(UiPrompt.ContactId());
                    break;
                case ActionType.SortContacts:
                    contactsState.SortContacts();
                    break;
                case ActionType.SearchContacts:
                    UiUtils.Clear();
                    UiDisplay.Contacts(contactsState.Filtered(UiPrompt.FilterQuery()));
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                case ActionType.ExitApp:
                    continueLoop = false;
                    break;
            }

        }

    }
}