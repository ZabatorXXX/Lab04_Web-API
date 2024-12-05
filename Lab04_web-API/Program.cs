using System.Net.Http;
using GitHub_Api;
using Zippopotamus_Api;


HttpClient client = new HttpClient();

Console.WriteLine("Choose an option:");
Console.WriteLine("1. Fetch GitHub Repository Information");
Console.WriteLine("2. Fetch ZIP Code Information");
Console.Write("Enter your choice (1/2): ");
string? choice = Console.ReadLine();
Console.WriteLine(" ");

if (choice == "1")
{
    var gitHubHandler = new GitHubApiHandler(client);
    var repositories = await gitHubHandler.GetRepositoriesAsync();
    gitHubHandler.DisplayRepositories(repositories);
}


else if (choice == "2")
{
    var zippopotamusHandler = new ZippopotamusApiHandler(client);

    var zipCode = await zippopotamusHandler.GetZipCodeAsync("07645");

    if (zipCode != null)
    {
        zippopotamusHandler.DisplayZipCodeDetails(zipCode);
    }
    else
    {
        Console.WriteLine("Unable to fetch ZIP code details.");
    }

}

else
{
    Console.WriteLine("Invalid choice. Exiting.");
}

Console.Write("\n\nPress any key to close the application...");
Console.ReadKey();
