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
                System.Console.WriteLine("===Welcome to the Komodo Insurance Directory===");
                System.Console.WriteLine("Select from the options below: \n"
                + "---Developer Directory--- \n"
                + "1. Add Developer \n"
                + "2. View a Developer \n"
                + "3. View All Developers \n"
                + "````````````````````````` \n"
                + "---Developer Team Directory--- \n"
                + "4. Add Team \n"
                + "5. View a Team \n"
                + "6. View All Teams \n"
                + "7. Update Team \n"
                + "8. Delete Team \n"
                + "````````````````````````` \n"
                + "9. Close Application \n"
                );

                string userInput = Console.ReadLine();

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
                        AddTeamToDirectory();
                        break;
                    case "5":
                    case "five":
                        ViewTeamByID();
                        break;
                    case "6":
                    case "six":
                        ViewAllDevTeams();
                        break;
                    case "7":
                    case "seven":
                        UpdateTeam();
                        break;
                    case "8":
                    case "eight":
                        DeleteTeam();
                        break;
                    case "9":
                    case "nine":
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
    }
