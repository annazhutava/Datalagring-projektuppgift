using DataLayer.Backend;


while (true)
{
    var restaurantTools = new RestaurantBackend();

    Console.WriteLine("Välj ett alternativ:");
    Console.WriteLine("1: Visa alla sålda matlådor för en restaurang");
    Console.WriteLine("2: Lägg till en matlåda för en restaurang");
    Console.WriteLine("3: Visa alla osålda matlådor för en restaurang");
    Console.WriteLine("4: Avsluta");

    var keyInfo = Console.ReadKey();

    Console.Clear();


    if (keyInfo.Key == ConsoleKey.D1)
    {
        Console.WriteLine("Välj en restaurang: ");
        var restaurang = Console.ReadLine();

        restaurantTools.SoldLunchBoxes(restaurang);
    }


    if (keyInfo.Key == ConsoleKey.D2)
    {
        Console.WriteLine("Välj en restaurang:");
        var restaurang = Console.ReadLine();

        Console.WriteLine("Skriv namnet på matlådan: ");
        var matlåda = Console.ReadLine();

        Console.WriteLine("Skriv priset på matlådan: ");
        var pris = Console.ReadLine();

        Console.WriteLine("Skriv kategori: ");
        var kategori = Console.ReadLine();


        restaurantTools.AddLunchbox(matlåda, pris, kategori, restaurang);
    }


    if (keyInfo.Key == ConsoleKey.D3)
    {
        Console.WriteLine("Välj en restaurang: ");
        var restaurang = Console.ReadLine();

        restaurantTools.AvailableLunchBoxes(restaurang);
    }


    if (keyInfo.Key == ConsoleKey.D4)
    {
        return;
    }
}