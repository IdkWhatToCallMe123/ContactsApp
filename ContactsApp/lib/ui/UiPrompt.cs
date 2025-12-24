using ContactsApp.lib.models;
using Spectre.Console;
using ContactsApp.lib.ui;

namespace ContactsApp.lib.ui;

public class UiPrompt
{
    public static ActionType ActionMenu(bool listEmpty)
    {
        string response;
        if (!listEmpty)
        {
            response = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What do you want to do")
            .AddChoices([
                "Add contact",
                "Remove contact",
                "Update contact",
                "Sort contacts",
                "Search contacts",
                "Exit app",
                    ]));
        }
        else
        {
            response = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What do you want to do")
            .AddChoices([
                "Add contact",
                "Exit app",
   ]));
        }

        return response switch
        {
            "Add contact" => ActionType.AddContact,
            "Remove contact" => ActionType.RemoveContact,
            "Update contact" => ActionType.UpdateContact,
            "Sort contacts" => ActionType.SortContacts,
            "Search contacts" => ActionType.SearchContacts,
            "Exit app" => ActionType.ExitApp,
            _ => ActionType.AddContact,
        };
    }
    public static ContactItem Contact()
    {
        String name;
        String phoneNumber;

        name = AnsiConsole.Prompt(
            new TextPrompt<string>("What's the name?")
                .Validate(v => v.Length switch
                {
                    < 3 => ValidationResult.Error("Too short"),
                    >= 3 => ValidationResult.Success(),
                }));

        phoneNumber = AnsiConsole.Prompt(
            new TextPrompt<string>("What's the phone number?")
                .Validate(v => v.Length switch
                {
                    < 3 => ValidationResult.Error("Too short"),
                    >= 3 => ValidationResult.Success(),
                }));

        return new ContactItem(
            name: name,
            phoneNumber: phoneNumber
        );
    }
    public static int ContactId()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<int>("Enter the contact id:"));
    }

    public static string FilterQuery()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your search query:"));
    }
}