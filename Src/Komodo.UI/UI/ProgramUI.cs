using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class ProgramUI
    {
        private readonly Dev_Repository _dRepo = new Dev_Repository();
        private readonly DevTeam_Repositpory _dtRepo = new DevTeam_Repositpory();
        public void Run()
        {
            SeedData();
            RunApplication();
        }
        private void SeedData()
        {
            Developer adam = new Developer("Adam", "Adamson");
            Developer ben = new Developer("Ben", "Benson");
            Developer carla = new Developer("Carla", "Carson");
            Developer diana = new Developer("Diana", "Driver");
            Developer eric = new Developer("Eric", "Ericson");
            Developer frieda = new Developer("Frieda", "Fields");
            Developer greg = new Developer("Greg", "Gardener");
            Developer harry = new Developer("Harry", "Harrison");
            Developer iva = new Developer("Iva", "Iverson");
            _dRepo.AddDeveloperToDirectory(adam);
            _dRepo.AddDeveloperToDirectory(ben);
            _dRepo.AddDeveloperToDirectory(carla);
            _dRepo.AddDeveloperToDirectory(diana);
            _dRepo.AddDeveloperToDirectory(eric);
            _dRepo.AddDeveloperToDirectory(frieda);
            _dRepo.AddDeveloperToDirectory(greg);
            _dRepo.AddDeveloperToDirectory(harry);
            _dRepo.AddDeveloperToDirectory(iva);
            DevTeam alpha = new DevTeam("Alpha Team");
            DevTeam beta = new DevTeam("Beta Team");
            DevTeam gamma = new DevTeam("Gamma Team");
            _dtRepo.AddTeamToDirectory(alpha);
            _dtRepo.AddTeamToDirectory(beta);
            _dtRepo.AddTeamToDirectory(gamma);
        }
        public void RunApplication()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                System.Console.WriteLine(
                "===Welcome to the Komodo Insurance Directory===\n"
                +"Select from the options below: \n"
                +"---Developer Directory--- \n"
                +"1. Add Developer \n"
                +"2. View a Developer \n"
                +"3. View All Developers \n"
                +"4. View Developers with PluralSight License \n"
                +"````````````````````````` \n"
                +"---Developer Team Directory--- \n"
                +"5. Add Team \n"
                +"6. View a Team \n"
                +"7. View All Teams \n"
                +"8. Update Team \n"
                +"9. Delete Team \n"
                +"````````````````````````` \n"
                +"X. Close Application \n"
                );
                string userInput = Console.ReadLine().ToLower();
                switch(userInput)
                {
                    case "1":
                    case "one":
                        AddDeveloperToDirectory();
                        break;
                    case "2":
                    case "two":
                        ViewDeveloperByID();
                        break;
                    case "3":
                    case "three":
                        ViewAllDevelopers();
                        break;
                    case "4":
                    case "four":
                        ViewAllPluralsightLicenses();
                        break;
                    case "5":
                    case "five":
                        AddTeamToDirectory();
                        break;
                    case "6":
                    case "six":
                        ViewTeamByID();
                        break;
                    case "7":
                    case "seven":
                        ViewAllDevTeams();
                        break;
                    case "8":
                    case "eight":
                        UpdateTeam();
                        break;
                    case "9":
                    case "nine":
                        DeleteTeam();
                        break;
                    case "x":    
                        isRunning = CloseApplication();
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection. Please enter a valid number 1-9.");
                        break;
                }
            }
        }
    //NOTE case 1
        private void AddDeveloperToDirectory() 
        {
            Console.Clear();
            var newDeveloper = new Developer();
            System.Console.WriteLine("=== New Developer Form ===");
            System.Console.WriteLine("Please enter the Developer's first name: ");
            newDeveloper.FirstName = Console.ReadLine();
            System.Console.WriteLine("Please enter the Developer's last name: ");
            newDeveloper.LastName = Console.ReadLine();
            bool isSuccessful = _dRepo.AddDeveloperToDirectory(newDeveloper);
            if(isSuccessful)
            {
                System.Console.WriteLine($"{newDeveloper.FirstName} {newDeveloper.LastNmae} was successfully added to the directory.");
            }
            PressAnyKey();
        }
    //NOTE case 2
        public void ViewDeveloperByID()
        {
            Console.Clear();
            System.Console.WriteLine("=== Developer Info === \n");
            System.Console.WriteLine("Please enter the developer ID: \n");
            int inputDeveloperID = int.Parse(Console.ReadLine());
            Developer developer = _dRepo.GetDeveloperByID(inputDeveloperID);
            if(developer != null)
            {
                DisplayDeveloperInfo(developer);
            }
            else
            {
                System.Console.WriteLine($"The developer with the ID: {inputDeveloperID} does not exist.");
            }
            PressAnyKey();
        }
    //NOTE case 3
        public void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> developersInDir = _dRepo.GetAllDevelopers();
            if(developersInDir.Count > 0)
            {
                foreach (Developer d in developersInDir)
                {
                    DisplayDeveloperInfo(d);
                }
            }
            else
            {
                System.Console.WriteLine("No developers exist.");
            }
            PressAnyKey();
        }
    // NOTE Case 4
    public void ViewAllPluralsightLicenses()
    {
        Console.Clear();
        System.Console.WriteLine("These Developers still need their pluralsight license. \n");
        foreach (Developer d in _dRepo)
        {
            if(d.PluralsightLicense == false)
            {
                System.Console.WriteLine($"ID: {d.ID} Name: {d.FirstName} {d.LastName} \n");
                if(d.Pluralsight == false)
                {
                    System.Console.WriteLine("This develpoer does not have access to Pluralsight \n");
                }   
            }
        }
    }
    // NOTE Case 5
    public void AddTeamToDirectory(DevTeam newDevTeam)
    {
        Console.Clear();
        var currentDevelopers = _dRepo.GetAllDevelopers();
        System.Console.WriteLine("Please enter a team name:");
        newDevTeam.Name = Console.ReadLine();
        // Add New Developers
        bool hasAssignedDeveloper = false;
        while(!hasAssignedDeveloper)
        {
            System.Console.WriteLine("Are there any employees? y/n");
            string hasDeveloper = Console.ReadLine().ToLower();
            if(hasDeveloper == "y")
            {
                foreach(var d in currentDevelopers)
                {
                    System.Console.WriteLine($"ID {d.ID}: {d.FirstName} {d.LastName}");
                }

                System.Console.WriteLine("Please select an employee ID number \n");
                int developerSelection = int.Parse(Console.ReadLine());
                Developer selectedDeveloper = _dRepo.GetDeveloperByID(developerSelection);
                if(selectedDeveloper != null)
                {
                    newDevTeam.Developers.Add(selectedDeveloper);
                    currentDevelopers.Remove(selectedDeveloper);
                }
                else
                {
                    System.Console.WriteLine($"Sorry, the developer with ID: {developerSelection}");
                }
            }
        else
        {
        hasAssignedDeveloper = true;
        }
        }
    }
     // NOTE Case 6-View All Dev Team
    // ! Helper Method
    private void DisplayDevTeamListing(DevTeam devTeam)
    {
        System.Console.WriteLine($"DevTeam ID: {devTeam.ID} \n DevTeam Name: {devTeam.Neam}\n");
    }
    private void ViewTeamByID()
    {
        Console.Clear();

        System.Console.WriteLine("===DevTeam Details===");
        var devTeams = _dtRepo.GetAllTeams(); 

        foreach(DevTeam d in teams)
        {
            DisplayDevTeamListing(d);
        }
        try
        {
            System.Console.WriteLine("Please select a Development Team by ID: \n" );
            int userInput = int.Parse(Console.ReadLine());
            var selectedDevTeam = _dRepo.GetDevTeamByID(userInput);

        if(selectedDevTeam != null)
        {
            DisplayDevTeamListing(selectedDevTeam);
        }
        else
        {
            System.Console.WriteLine($"Sorry, the development team with the ID: {userInput} doesn't exist");
        }
        }

        catch (System.Exception)
        {
            throw;
        }
        PressAnyKey();
    }
    // NOTE Case 7
    private void ViewAllDevTeams()
    {
        Console.Clear();

        System.Console.WriteLine("===Developer Team===");

        var devteamInDB = _dRepo.GetAllTeams();

        foreach(DevTeam d in devteamInDB)
        {
            DisplayDevTeamListing(d);
        }
        PressAnyKey();
    }
    // NOTE Case 8 Update-Team
    private void UpdateTeam()
    {
        Console.Clear();
        var availDevTeams = _dRepo.GetAllTeams();
        foreach (var d in availDevTeams)
        {
            DisplayDevTeamListing(d);
        }
        System.Console.WriteLine("Please enter a valid Developer Team ID: \n");
        int userInput = int.Parse(Console.ReadLine());
        if(selectedDevTeam !=null)
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();
            var currentDevelopers = _eRepo.GetAllDevelopers;
            newDevTeam.Name = Console.ReadLine();
            bool hasAssignedDeveloper = false;
            while(!hasAssignedDevelopers)
            {
                System.Console.WriteLine("Do you have any develpers? y/n \n");
                newDevTeam.Name = Console.ReadLine().ToLower();
                if(developerInput == "y")
                {
                    foreach(var d in currentDevelopers)
                    {
                        System.Console.WriteLine($"{e.ID} {e.FirstName} {e.LastName}");
                    }
                    System.Console.WriteLine("Please select employee by ID: \n");
                    int developerSelected = int.Parse(Console.ReadLine());
                    var selectedDeveloper = _dRepo.GetDeveloperByID(developerSelected);
                    if(selectedDeveloper != null)
                    {
                        newDevTeam.Developer.Add(selectedDeveloper);
                        currentDeveloper.Remove(selectedDeveloper);
                    }
                    else
                    {
                    System.Console.WriteLine("Sorry, no employee.");
                    }
                }
            }
            hasAssignedDevelopers = true;
        }
        }
    //NOTE: case 9 Delete
    private void DeleteTeam()
{
	Console.Clear();
	System.Console.WriteLine("===Store Removal===");
	var DevTeams = _dRepo.GetAllDevTeam();
	foreach(DevTeam d in devteam)
	{
		DisplayDevTeamListing(d);
	}
	try
	{
		System.Console.WriteLine("Please select astore by ID: \n");
		int userSelectedDevTeam = int.Parse(Console.ReadLine());
		bool isSuccessful = _dRepo.RemoveDevTeamFromDatabase(userSelectedDevTeam);
		if(isSuccessful)
		{
			System.Console.WriteLine("Store was removed.");
		}
		else
		{
			System.Console.WriteLine("Store could not be removed.");
		}
    }
	catch
		{
			System.Console.WriteLine("Sorry, invalid selection.");
		}
		PressAnyKey();
    }
//NOTE Close App
private bool CloseApplication()
{
	Console.Clear();
	System.Console.WriteLine("Bye, Felicia");
	PressAnyKey();
	return false;
}
private void PressAnyKey()
{
	System.Console.WriteLine("Press ANY KEY to continue...");
	Console.ReadKey();
}
}