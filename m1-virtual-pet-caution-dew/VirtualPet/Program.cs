using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using VirtualPet;

namespace VirtualPet

{

    class Program
    {

        public static Shelter MyShelter = new Shelter();
        public static Pet myPet;

        private static Timer _timer;
        static void Main(string[] args)
        {
            //PlayThemeSong();
            //RunAnimatedMenu();


            Console.WriteLine("Welcome to your animal shelter!");
            Console.WriteLine("What is the name of your shelter?");
            string shelterName = Console.ReadLine();
            Console.Clear();

            MyShelter.Name = shelterName;

            myPet = CreatePet();
            MyShelter.AddPet(myPet);   

           _timer = new Timer(Tick, null, 0, 15000);
          

            bool keepPlaying = true;
            


            while (keepPlaying)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ");

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Your active pet is currently: " + myPet.Name);

                string petType = myPet is Ironper ? "robot" : "pet";

                Console.WriteLine($"1. Check your {petType} status.");
                Console.WriteLine($"2. Feed your {petType}.");
                Console.WriteLine($"3. Play with your {petType}.");
                if (myPet is Ironper)
                    Console.WriteLine("4. Hook/Unhook your robot from charger.");
                else Console.WriteLine("4. Take your pet to the doctor.");
                Console.WriteLine("5. Choose a new active pet.");
                Console.WriteLine("6. Create a new pet.");
                Console.WriteLine($"7. Manage {MyShelter.Name}.");
                
                Console.WriteLine("   Press Q to exit the game.");

                //myPet = MyShelter.SelectedPet();
                //myPet.CheckStatus();

                string userInput = Console.ReadLine().ToLower();
               
                switch (userInput)
                {
                    case "1":
                        //myPet = MyShelter.SelectPet();
                        myPet.CheckStatus();
                         Console.ReadKey();
                        break;
                    case "2":
                        myPet.Feed();
                        myPet.CheckStatus();
                        break;
                    case "3":
                        myPet.Play();
                        myPet.CheckStatus();
                        break;
                    case "4":
                        myPet.SeeDoctor();
                        myPet.CheckStatus();
                        Console.ReadKey();
                        break;
                    case "5":
                        myPet = MyShelter.PickAPet();
                        break;
                    case "6":
                        myPet = CreatePet();
                        MyShelter.AddPet(myPet);
                        break;
                    case "7":
                        ManageShelter();
                        break;
                    case "q":
                        keepPlaying = false;
                        break;
                   
                    
                    default:
                        
                        
                        break;



                        // create "go to/manage shelter" option on menu
                        // ?need nested loop to access shelter options?
                        // multi pet interactions?
                }
            }
        }
            public static void PlayThemeSong()
            {

                Console.Beep(262, 250); //C
                Console.Beep(294, 250); //D
                Console.Beep(330, 250); //E
                Console.Beep(294, 500); //D
                Console.Beep(262, 500); //C
                Console.Beep(392, 750); //G
            }

            public static void RunAnimatedMenu()
            {
                Console.WriteLine("\n\n\n\n\n\t\t\t\t\tHello! Welcome to CyberPets! =^.u.^=\n\n\n\n\n");
                Console.WriteLine("\t\t\t\t\tPress any key to continue.");
                Console.ReadKey();
                Console.Clear();

                for (int i = 5; i > 0; i--)
                {
                    for (int j = i; j > 0; j--)
                    {
                        Console.Write("\n");
                    }
                    Console.WriteLine("\t\t\t\t\tHello! Welcome to CyberPets! =^.u.^=\n\n\n\n\n");
                    Console.WriteLine("\t\t\t\t\tPress any key to continue.");
                    System.Threading.Thread.Sleep(250);
                    Console.Clear();
                }

                for (int k = 5; k > 0; k--)
                {
                    for (int l = k; l > 0; l--)
                    {
                        Console.Write("\n");
                    }
                    Console.WriteLine("\t\t\t\t\tPress any key to continue.");
                    System.Threading.Thread.Sleep(250);
                    Console.Clear();
                }
            }

        public static Pet CreatePet()
        {
          
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"On your way to {MyShelter.Name} you come across a small bundle. It's an...animal or robot?");
            Console.WriteLine("Press 1 for animal, 2 for robot.");
            
            
            string petType = Console.ReadLine();

            Console.WriteLine("What kind of animal is it?\n Enter its species:");
            string petSpecies = Console.ReadLine();
            /*      // myPet.SetSpecies(petSpecies);
                   Console.WriteLine($"The {petSpecies} looks cold and tired. You take it back to {MyShelter.Name}.");
                   Console.WriteLine($"When you arrive, you set the {petSpecies} up in an appropriate cage, and give it a name.");
                   Console.WriteLine($"What is the {petSpecies}'s name?");
                   string petName = Console.ReadLine();
                   // myPet.SetName(petName);
                   Console.WriteLine("Press any key to continue!");
                   Console.Read();
            */
          
            Pet myPet;
          //  string petType = Console.ReadLine();
            Console.WriteLine(" pet name please");

            string petName = Console.ReadLine();
            //ADD ERROR CATCHING LOOP HERE
            if (petType == "1")
            {
                myPet = new Pet();
                myPet.Name = petName;
                myPet.Species = petSpecies;
                Console.WriteLine("The animal looks up at you!");
                return myPet;
            }
            else // if (petType == "2")
            {
                myPet = new Ironper();
                myPet.Name = petName;
                myPet.Species = petSpecies;
                Console.WriteLine("The robot looks up at you!");
                return myPet;
            }
            /* else
             {
                 Console.WriteLine("Oops! Try again.");
             }*/

        }

        public static void ManageShelter()
        {
            bool keepPlaying = true;

            // MyShelter.ListPets();
            //string userInput = Console.ReadLine().ToLower();
            
            while (keepPlaying)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"You survey the pets assembled in {MyShelter.Name}.");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Adopt a pet out of your shelter.");
                Console.WriteLine("2. See all pets in your shelter.");
                Console.WriteLine("3. Check status of all pets.");
                Console.WriteLine("4. Interact with all pets at once.");
                //Console.WriteLine("5.  TIMER START");
                Console.WriteLine("   Press Q to quit.");
                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "1":
                        myPet = MyShelter.PickAPet();
                        MyShelter.Adopt(myPet);
                        break;
                    case "2":
                        MyShelter.ListPets();
                       
                        break;
                    case "3":
                        MyShelter.CheckAllStats();
                        break;

                    case "4":
                        MyShelter.InteractWithAll();
                        break;
                    //case "5":
                    //    ///////////////////////////////////////////////////////////////////////////timer start
                    //   _timer = new Timer(Tick, null, 0, 7000);

                    //    break;
                    case "q":
                        keepPlaying = false;
                        break;
                    default:
                        // userInput = Console.ReadLine().ToLower();
                        Console.WriteLine("I don't understand that input. Try again!");
                        Console.Read();
                        // Console.Clear();

                        break;
                }
                //Console.Clear();

            }
        }

        public static void Tick(Object o)
        {
            //Pet pet = new Pet();              
           // myPet.Tick();  //will +5 Hunger/ +5 Boredom/ -5 Health
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

           // MyShelter.ListPets();

            int  index = 0;

            if (MyShelter.ListOfPets.Any()){


                foreach (Pet myPet in MyShelter.ListOfPets)
                {
                    //  Console.WriteLine($"{index}: {pet1.GetName()}, {pet1.GetSpecies()}"+" before  hunger  "+ pet1.Hunger+" helth  "+pet1.Health  );

                    myPet.Tick();



                    //  Console.WriteLine($"{index}: {pet1.GetName()}, {pet1.GetSpecies()}"+ "  after   hunger  " + pet1.Hunger + " helth  " + pet1.Health );


                    index++;

                }
            }
            else
            {
                Console.WriteLine("You do not have any pets");
            }

           // Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            // put methods/updates that change the pet in some way
        }

    }
}

