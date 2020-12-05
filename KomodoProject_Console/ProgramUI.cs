using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoProject_Console
{
    class ProgramUI
    {
        private DeveloperRepo _devsRepo = new DeveloperRepo();

        //This is the method that starts the UI part of the app
        public void Run()
        {
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true; //Keep running*************
            while (keepRunning)
            {

                //Display options
                Console.WriteLine("Select an option:\n" +
                    "1. Add new Developer\n" +
                    "2. View existing Developers\n" +
                    "3. View Developers by name\n" +
                    "4. View Developers by ID number\n" +
                    "5. Update existing Developer profile\n" +
                    "6. Delete existing Developer profile\n" +
                    "7. Exit.");

                //Get user's input
                string input = Console.ReadLine();

                //Act according to user's input, using METHODS
                switch (input)
                {
                    case "1":
                        //Create
                        AddNewDev();
                        break;
                    case "2":
                        //View existing
                        DisplayAllDevs();
                        break;
                    case "3":
                        //View By last name
                        FindByLastName();
                        break;
                    case "4":
                        //View by ID
                        FindDeveloperByID();
                        break;
                    case "5":
                        //Update
                        UpdateExistingDev();
                        break;
                    case "6":
                        //Delete
                        DeleteExistingDev();
                        break;
                    case "7":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a value number (#1-7).");
                        break;
                }

                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        //Display devs who do not have PluralSight access
        private void ShowPluralSightNeeded()
        {
            Console.Clear();
            List<Developer> listOfDevs = _devsRepo.GetDeveloperList();

            foreach (Developer developer in listOfDevs)
            {
                if (false)
                {
                    Console.WriteLine(developer.FirstName, developer.LastName);
                }
            }
        }



        //Add new Dev
        private void AddNewDev()
        {
            Console.Clear();
            Developer newDev = new Developer();

            //FirstName
            Console.WriteLine("Enter Developer's first name.");
            newDev.FirstName = Console.ReadLine();

            //LastName
            Console.WriteLine("Enter Developer's last name.");
            newDev.LastName = Console.ReadLine();

            //HasPluralSight
            Console.WriteLine("Does this developer have PluralSight access? (y/n)");
            string pluralSightString = Console.ReadLine().ToLower();

            if(pluralSightString == "y")
            {
                newDev.HasPluralSight = true;
            }
            else
            {
                newDev.HasPluralSight = false;
            }

            _devsRepo.AddDeveloperToList(newDev);


        }

        //View existing
        private void DisplayAllDevs()
        {
            Console.Clear();
            List<Developer> listOfDevs = _devsRepo.GetDeveloperList();

            foreach (Developer developer in listOfDevs)
            {
                Console.WriteLine($"First Name: {developer.FirstName}\n" +
                    $"Last Name: {developer.LastName}\n" +
                    $"Plural Sight Access {developer.HasPluralSight}");
            }
        }
        //Find by name
        private void FindByLastName()
        {
            Console.Clear();
            //Prompt user
            Console.WriteLine("Enter last name of developer:");

            //Get user's input
            string lastName = Console.ReadLine();

            //Find dev with that last name
            Developer developer = _devsRepo.GetDeveloperByLastName(lastName);

            //Display dev found (if not null)
            if(developer != null)
            {
                Console.WriteLine($"First Name: {developer.FirstName}\n" +
                    $"Last Name: {developer.LastName}\n" +
                    $"Plural Sight Access {developer.HasPluralSight}");
            }
            else
            {
                Console.WriteLine("Could not find developer by that last name!");
            }

        }

        //Find by ID
        private void FindDeveloperByID()
        {
            Console.Clear();
            //Prompt user
            Console.WriteLine("Enter ID number of developer:");

            //Get user's input
            string iDNumber = Console.ReadLine();

            //Find dev with that last name
            Developer developer = _devsRepo.GetDeveloperByID(iDNumber);

            //Display dev found (if not null)
            if (developer != null)
            {
                Console.WriteLine($"First Name: {developer.FirstName}\n" +
                    $"Last Name: {developer.LastName}\n" +
                    $"Plural Sight Access {developer.HasPluralSight}");
            }
            else
            {
                Console.WriteLine("Could not find developer by that last name!");
            }

        }




            //Update existing
            private void UpdateExistingDev()
        {
            //Display all
            DisplayAllDevs();

            //Request name to update
            Console.WriteLine("Enter last name of developer to update.");

            //Find dev by name
            string oldLastName = Console.ReadLine();

            //Build new object
            Developer newDev = new Developer();

            //FirstName
            Console.WriteLine("Enter Developer's first name.");
            newDev.FirstName = Console.ReadLine();

            //LastName
            Console.WriteLine("Enter Developer's last name.");
            newDev.LastName = Console.ReadLine();

            //HasPluralSight
            Console.WriteLine("Does this developer have PluralSight access? (y/n)");
            string pluralSightString = Console.ReadLine().ToLower();

            if (pluralSightString == "y")
            {
                newDev.HasPluralSight = true;
            }
            else
            {
                newDev.HasPluralSight = false;
            }

            //Verify the update worked
            bool wasUpdated = _devsRepo.UpdateExistingDeveloper(oldLastName, newDev);

            if (wasUpdated)
            {
                Console.WriteLine("Developer info was successfully updated.");
            }
            else
            {
                Console.WriteLine("Developer info could not be updated!");
            }
        }

        //Delete existing
        private void DeleteExistingDev()
        {
            DisplayAllDevs();

            //Get last name of dev to delete
            Console.WriteLine("\nEnter last name of developer to delete.");

            string input = Console.ReadLine();

            //Call delete method
            bool wasDeleted = _devsRepo.RemoveDeveloperFromList(input);

            //If it works, tell user it was a success
            if (wasDeleted)
            {
                Console.WriteLine("Developer was successfully removed.");
            }
            else
            {
                Console.WriteLine("Developer could not be removed!");
            }

            //Otherwise, state it could not be deleted
        }

        //Seed method
        public void SeedDevList()
        {
            Developer joshua = new Developer("Joshua", "Wright", true);
            Developer jane = new Developer("Jane", "Sweet", false);
            Developer george = new Developer("George", "Sweet", false);

            _devsRepo.AddDeveloperToList(joshua);
            _devsRepo.AddDeveloperToList(jane);
            _devsRepo.AddDeveloperToList(george);

        }

    }
}
