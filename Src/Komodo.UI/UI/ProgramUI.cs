using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class ProgramUI
    {
        private readonly DevRepo _dRepo = new DevRepo();
        private readonly DevTeamRepo _dtRepo = new DevTeamRepo();
        public void Run()
        {
            SeedData();
            RunApplication();
        }
        private void SeedData()
        {
            Developer adam = new Developer("Adam", "Adamson", false, false);
            Developer ben = new Developer("Ben", "Benson", true, false);
            Developer carla = new Developer("Carla", "Carson", true, true);
            Developer diana = new Developer("Diana", "Driver", false, false);
            Developer eric = new Developer("Eric", "Ericson", true, false);
            Developer frieda = new Developer("Frieda", "Fields", true, true);
            Developer greg = new Developer("Greg", "Gardener", false, false);
            Developer harry = new Developer("Harry", "Harrison", true, false);
            Developer iva = new Developer("Iva", "Iverson", true, true);
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
            _dtRepo.AddTeamToDir(alpha);
            _dtRepo.AddTeamToDir(beta);
            _dtRepo.AddTeamToDir(gamma);
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
                +"2. View All Developers \n"
                +"3. View a Developer \n"
                +"4. View Developers with PluralSight License \n"
                +"````````````````````````` \n"
                +"---Developer Team Directory--- \n"
                +"5. Add Team \n"
                +"6. View a Team \n"
                +"7. View All Teams \n"
                +"8. Update Team \n"
                +"9. Add Developers to a Team \n"
                +"10. Remove Developers from a Team \n"
                +"11. Delete Team \n"
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
                        ViewAllDevelopers();
                        break;
                    case "3":
                    case "three":
                        ViewDeveloperByID();
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
                        AddDevToTeam();
                        break;
                    case "10":
                    case "ten":
                        RemoveDevFromTeam();
                        break;
                    case "11":
                    case "eleven":
                        DeleteTeam();
                        break;
                    case "x":    
                        isRunning = CloseApplication();
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }
    //NOTE case 1
        private void AddDeveloperToDirectory() 
        {
            Console.Clear();
            var newDeveloper = new Developer();
            System.Console.WriteLine("=== New Developer Form === \n");
            System.Console.WriteLine("Please enter the Developer's first name: \n");
            newDeveloper.FirstName = Console.ReadLine();
            System.Console.WriteLine("Please enter the Developer's last name: \n");
            newDeveloper.LastName = Console.ReadLine();
            System.Console.WriteLine("Does this Developer have access to Pluralsight? y/n \n");
            string inp = Console.ReadLine().ToLower();
            if(inp == "y")
            {
                newDeveloper.Pluralsight = true;
            }
            else
            {
                newDeveloper.Pluralsight = false;
            }
            System.Console.WriteLine("Does this Developer have a Pluralsight license? y/n \n");
            string inpu = Console.ReadLine().ToLower();
            if(inpu == "y")
            {
                newDeveloper.PluralsightLicense = true;
            }
            else
            {
                newDeveloper.PluralsightLicense = false;
            }
            bool isSuccessful = _dRepo.AddDeveloperToDirectory(newDeveloper);
            if(isSuccessful)
            {
                System.Console.WriteLine($"{newDeveloper.FirstName} {newDeveloper.LastName} was successfully added to the directory. \n");
            }
            else
            {
                System.Console.WriteLine("Invalid Input. \n");
            }
            PressAnyKey();
        }
            //NOTE case 2
        public void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> developersInDir = _dRepo.GetAllDevelopers();
            if(developersInDir.Count > 0)
            {
                foreach (Developer d in developersInDir)
                {
                    System.Console.WriteLine($"ID: {d.ID} Name: {d.FirstName} {d.LastName} \n");
                }
            }
            else
            {
                System.Console.WriteLine("No developers exist.");
            }
            PressAnyKey();
        }
    //NOTE case 3
        public void ViewDeveloperByID()
        {
            Console.Clear();
            System.Console.WriteLine("=== Developer Info === \n");
            ViewAllDevelopers();
            System.Console.WriteLine("Please enter the developer ID: \n");
            int inputDeveloperID = int.Parse(Console.ReadLine());
            Developer developer = _dRepo.GetDeveloperByID(inputDeveloperID);
            if(developer != null)
            {
                System.Console.WriteLine($"ID: {developer.ID} Name: {developer.FirstName} {developer.LastName} \n");
            }
            else
            {
                System.Console.WriteLine($"The developer with the ID: {inputDeveloperID} does not exist.");
            }
            PressAnyKey();
        }

    // NOTE Case 4
    public void ViewAllPluralsightLicenses()
    {
        Console.Clear();
        var repo = _dRepo.GetAllDevelopers();
        System.Console.WriteLine("These Developers still need their pluralsight license. \n");
        foreach(Developer d in repo)
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
        PressAnyKey();
    }
    // NOTE Case 5
    public void AddTeamToDirectory()
    {
        Console.Clear();
        DevTeam newDevTeam = new DevTeam();
        var currentDevelopers = _dRepo.GetAllDevelopers();
        System.Console.WriteLine("Please enter a team name:");
        newDevTeam.TeamName = Console.ReadLine();
        // Add New Developers
        bool hasAssignedDeveloper = false;
        while(!hasAssignedDeveloper)
        {
            ViewAllDevelopers();
            System.Console.WriteLine("Are there any developers? y/n");
            string hasDeveloper = Console.ReadLine().ToLower();
            if(hasDeveloper == "y")
            {
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
        System.Console.WriteLine($"DevTeam ID: {devTeam.ID} \n DevTeam Name: {devTeam.TeamName}\n");
    }
    private void ViewTeamByID()
    {
        Console.Clear();
        System.Console.WriteLine("===DevTeam Details===");
        var devTeams = _dtRepo.GetAllTeams(); 
        foreach(DevTeam d in devTeams)
        {
            DisplayDevTeamListing(d);
        }
        try
        {
            System.Console.WriteLine("Please select a Development Team by ID: \n" );
            int userInput = int.Parse(Console.ReadLine());
            var selectedDevTeam = _dtRepo.GetTeamByID(userInput);

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

        var devteamInDB = _dtRepo.GetAllTeams();

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
        var availDevTeams = _dtRepo.GetAllTeams();
        foreach (var d in availDevTeams)
        {
            DisplayDevTeamListing(d);
        }
        System.Console.WriteLine("Please enter a valid Developer Team ID: \n");
        int userInput = int.Parse(Console.ReadLine());
        var selectedDevTeam = _dtRepo.GetTeamByID(userInput);
        if(selectedDevTeam !=null)
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();
            var currentDevelopers = _dRepo.GetAllDevelopers();
            System.Console.WriteLine("What is the Team Name? \n");
            newDevTeam.TeamName = Console.ReadLine();
            bool hasAssignedDevelopers = false;
            while(!hasAssignedDevelopers)
            {
                System.Console.WriteLine("Do you have any develpers? y/n \n");
                string developerInput = Console.ReadLine().ToLower();
                if(developerInput == "y")
                {
                    foreach(var d in currentDevelopers)
                    {
                        System.Console.WriteLine($"{d.ID} {d.FirstName} {d.LastName}");
                    }
                    System.Console.WriteLine("Please select devloper by ID: \n");
                    int developerSelected = int.Parse(Console.ReadLine());
                    var selectedDeveloper = _dRepo.GetDeveloperByID(developerSelected);
                    if(selectedDeveloper != null)
                    {
                        newDevTeam.Developers.Add(selectedDeveloper);
                        currentDevelopers.Remove(selectedDeveloper);
                    }
                    else
                    {
                    System.Console.WriteLine("Sorry, no developer.");
                    }
                }
                else
                {
                    hasAssignedDevelopers = true;
                }
            }
        }
    }    
// NOTE case 10
    private void RemoveDevFromTeam()
    {
    Console.Clear();
	ViewAllDevTeams();
	Console.WriteLine("Please enter the team ID.");
	int id = int.Parse(Console.ReadLine());
	var aTeam = _dtRepo.GetTeamByID(id);
	foreach(Developer d in aTeam.Developers)
	{
		System.Console.WriteLine($"{d.ID} {d.FirstName} {d.LastName} \n");
	}
	try
    {
		Console.WriteLine("Enter ID of the developer you wish to remove.");
		int developerID = int.Parse(Console.ReadLine());
		var developer = _dRepo.GetDeveloperByID(developerID);
		bool isRemoved = _dtRepo.RemoveTeamByID(userSelectedDevTeam);
		if(isRemoved)
		{
			System.Console.WriteLine("Developer was removed.");
		}
		else
		{
			System.Console.WriteLine("Pre-K, pause something went wrong try again.");
		}
			aTeam.Developers.Remove(developer);
    }
	catch
		{
			System.Console.WriteLine("Sorry, invalid selection.");
		}	
		PressAnyKey();
	}   
    //NOTE: case 11 Delete
    private void DeleteTeam()
    {
	Console.Clear();
	System.Console.WriteLine("===Team Removal===");
	var DevTeams = _dtRepo.GetAllTeams();
	foreach(DevTeam d in DevTeams)
	{
		DisplayDevTeamListing(d);
	}
	try
	{
		System.Console.WriteLine("Please select a team by ID: \n");
		int userSelectedDevTeam = int.Parse(Console.ReadLine());
		bool isSuccessful = _dtRepo.RemoveTeamByID(userSelectedDevTeam);
		if(isSuccessful)
		{
			System.Console.WriteLine("Team was removed.");
		}
		else
		{
			System.Console.WriteLine("Team could not be removed.");
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
    private void AddDevToTeam()
    {
        Console.Clear();
        ViewAllDevTeams();
        System.Console.WriteLine("Please enter a Valid team ID");
        int id = int.Parse(Console.ReadLine());
        var team = _dtRepo.GetTeamByID(id);
        var devs = _dRepo.GetAllDevelopers();
        bool more = true;
        while(more)
        {
            Console.Clear();
            foreach (Developer d in devs)
            {
                System.Console.WriteLine($"ID: {d.ID} Name {d.FirstName} {d.LastName}");
            } 
            try
            {
            System.Console.WriteLine("please enter the ID of the developer you wish to add. Enter x when done");
            string put = Console.ReadLine().ToLower();
            int Did = int.Parse(put);
            var dev = _dRepo.GetDeveloperByID(Did);
            bool sucess = team.Developers.Add(dev);
            }
            catch
            {
                System.Console.WriteLine(" Invalid Selction ");
            }
            if(ParamArrayAttribute == "x")
            {
                PressAnyKey();
                break;
            }
        }
    }
    }
    