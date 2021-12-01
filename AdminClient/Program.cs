using DataLayer;
using DataLayer.Backend;
using DataLayer.Data;

AdminBackend adminBackend = new AdminBackend();
int input;
bool keepRunning = true;
while (keepRunning)
{
    Console.WriteLine("Welcome Admin!");
    Console.WriteLine("Please type your username:");
    var username = Console.ReadLine();
    Console.WriteLine("Please type your password:");
    var password = Console.ReadLine();
    Console.Clear();

    var loginManager = new LoginManager();
    var admin = loginManager.TryLoginAdmin(username, password);
    if (admin != null)
    {
        Console.WriteLine("Welcome " + admin.UserName);
        while (keepRunning)
        {
            Console.WriteLine("Press 1 and 'enter' If you want to create and seed the database");
            Console.WriteLine("Press 2 and 'enter' If you want to see all customers");
            Console.WriteLine("Press 3 and 'enter' If you want to remove a customer");
            Console.WriteLine("Press 4 and 'enter' If you want to see all restaurants");
            Console.WriteLine("Press 5 and 'enter' If you want to add a new restaurant");
            Console.WriteLine("Press 0 and 'enter' To exit");
            
            if (int.TryParse(Console.ReadLine(), out input))
            {
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Database initialized!");
                        adminBackend.PrepDatabase();
                        break;
                    case 2:
                        Console.WriteLine("All customers:");
                        adminBackend.ShowUsers();
                        break;
                    case 3:
                        adminBackend.ShowUsers();
                        Console.WriteLine("What customer Id do you want to delete?");
                        if (int.TryParse(Console.ReadLine(), out input))
                        {
                            adminBackend.DeleteUsers(input);
                        }
                        break;
                    case 4:
                        Console.WriteLine("All restaurants:");
                        adminBackend.ShowRestaurants();
                        break;
                    case 5:
                        Console.WriteLine("Add new restaurant:");
                        Console.WriteLine("Name of restaurant: ");
                        string restaurantName = Console.ReadLine();
                        Console.WriteLine("City of restaurant: ");
                        string restaurantCity = Console.ReadLine();
                        Console.WriteLine("Streetname:");
                        string restaurantStreet = Console.ReadLine();
                        Console.WriteLine("Phone-number of restaurant: ");
                        string restaurantPhoneNumber = Console.ReadLine();
                        
                        adminBackend.AddRestaurant(restaurantName, restaurantCity, restaurantStreet, restaurantPhoneNumber);
                        break;
                    case 0:
                        Console.WriteLine("Bye bye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input, try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wrong input, try again.");
            }

        }
    }
    else
    {
        Console.WriteLine("Login failed, please check username and password!");
    }
}
