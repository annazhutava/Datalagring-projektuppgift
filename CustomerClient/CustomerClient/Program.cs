// See https://aka.ms/new-console-template for more information
using DataLayer.Backend;


while (true)
{
    var customertools = new UserBackend();
    Console.WriteLine("1: Visa oköpta matlådor");
    Console.WriteLine("2: Köp en matlåda");
    Console.WriteLine("3: Visa dina köpta matlådor");

    var keyInfo = Console.ReadKey();
    if (keyInfo.Key == ConsoleKey.D1)
    {
        Console.Clear();
        Console.WriteLine("Kött, Fisk eller Veg");
        var typ = Console.ReadLine();
        customertools.AvailableLunchboxesType(typ);
    }
    if (keyInfo.Key == ConsoleKey.D2)
    {
        Console.Clear();
        customertools.AvailableLunchboxes();
        Console.WriteLine("Matlåda:");
        var lunch = Console.ReadLine();
        Console.WriteLine("Email:");
        var user = Console.ReadLine();
        var lunchbox = Convert.ToInt32(lunch);

        customertools.BuyLunchbox(user, lunchbox);
    }
    if (keyInfo.Key == ConsoleKey.D3)
    {
        Console.Clear();
        Console.WriteLine("Email:");
        var email = Console.ReadLine();
        customertools.SoldLunchboxes(email);
    }
}