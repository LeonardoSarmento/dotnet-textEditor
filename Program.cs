class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Text Editor");
        Console.WriteLine("Menu");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1 - Open file");
        Console.WriteLine("2 - Create a new file");
        Console.WriteLine("0 - Exit");

        short option;
        while (true)
        {
            try
            {
                option = short.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Input in the wrong format, please try again");
            }
        }
        switch (option)
        {
            case 0: Exit(); break;
            case 1: Open(); break;
            case 2: Edit(); break;
            default: Menu(); break;
        }
    }
    static void Open()
    {
        Console.Clear();
        Console.WriteLine("Write the file path to open:");
        string path = Console.ReadLine();

        using var file = new StreamReader(path);
        string text = file.ReadToEnd();
        Console.WriteLine(text);

        Console.WriteLine("");
        Console.ReadLine();
        Menu();

    }
    static void Edit()
    {
        Console.Clear();
        Console.WriteLine("Type your text below (Press ESC to exit)");
        Console.WriteLine("-----------------------------------------");

        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        } while (Console.ReadKey().Key != ConsoleKey.Escape);

        Save(text);
    }
    static void Save(string text)
    {
        Console.Clear();
        Console.WriteLine("Which path to save the file?");
        var path = Console.ReadLine();

        using var file = new StreamWriter(path);
        file.Write(text);

        Console.WriteLine($"File saved successfully at {path}");
        Console.ReadLine();
        Menu();
    }
    static void Exit()
    {
        Console.WriteLine("Exiting the Text Editor!");
        System.Environment.Exit(0);
    }
}