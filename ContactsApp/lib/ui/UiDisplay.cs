using ContactsApp.lib.models;
using Spectre.Console;

namespace ContactsApp.lib.ui;

public class UiDisplay
{

    public static void Contacts(List<ContactItem> contacts)
    {
        if (contacts.Count == 0)
        {
            AnsiConsole.Write(new Panel(
                new Align(
                    new Text("Oh no you have no contacts"),
                    HorizontalAlignment.Center
                    )
            ).Expand());
            return;
        }
        var table = new Table().Expand()
            .AddColumn("Id")
            .AddColumn("Name")
            .AddColumn("Phone number");

        for (int i = 0; i < contacts.Count; i++)
        {
            var item = contacts[i];
            table.AddRow(i.ToString(), $"🧍 {item.Name}", $"📞 {item.PhoneNumber}");
        }

        AnsiConsole.Write(table);
    }

    public static void Error(string error)
    {
        AnsiConsole.Write(new Markup($"[bold red]{error}[/]\n"));
    }
}