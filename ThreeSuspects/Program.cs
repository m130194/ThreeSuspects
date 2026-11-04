namespace ThreeSuspects
{
    internal class Program
    {

        static void Main()
        {
            Console.WriteLine("A top secret document has been stolen from Mycroft!");
            Console.WriteLine("It was stolen by one of three suspects through an open window at the Diogenes Club");
            Console.WriteLine("Track the thief and retrieve the document before midnight!");
            GetPlayerMenuChoice();

        }

        
        public static int PlayerSteps = 0;


        public static int HoursPassedInGame
        {
            get
            {
                int hoursPassed = 0;
                for (int i = 0; i < PlayerSteps && i < 12; i++)
                {
                    hoursPassed += PlayerSteps;
                }
                return hoursPassed;

            }
        }

        public static int TimeInGame
        {
            get
            {
                return 12 - HoursPassedInGame;
            }
        }

        /// <summary>
        /// Gets the player's menu choice.
        /// </summary>
        /// <returns>The player's menu choice.</returns>
        public static string GetPlayerMenuChoice()
        {
            Console.WriteLine($"The time is now {TimeInGame}:00 PM");
            while (true)
            {
                Console.WriteLine("Choose a resource:");
                Console.WriteLine("N - Newspaper");
                Console.WriteLine("D - Directory");
                Console.WriteLine("M - Map");
                Console.WriteLine("T - Train schedule");
                Console.WriteLine("P - Police reports");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "N":
                        Newspaper();
                        break;
                    case "D":
                        Directory();
                        break;
                    case "M":
                        ViewMap();
                        break;
                    case "T":
                        TrainSchedule();
                        break;
                    case "P":
                        PoliceReports();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static void ViewMap()
        {
            Console.WriteLine("Select a location to visit by typing in the letter. Each visit will take up 1 player step and the clock will advance an hour.");    
            Console.WriteLine("Map of London");
                Console.WriteLine("-------------");
                Console.WriteLine("E - Euston Station");
                Console.WriteLine("B - British Museum");
                Console.WriteLine("W - Waldenboch Florists");
                Console.WriteLine("P - Plumber Scampie & Sons");
                Console.WriteLine("D - Diogenes Club");
                Console.WriteLine("G - German Embassy");
                Console.WriteLine("S - St James's Park");
                Console.WriteLine("C - Charing Cross Station");
                Console.WriteLine("V - Villiers St Hotel");
                Console.WriteLine("M - Market");
                Console.WriteLine("-------------");
                GetPlayerMenuChoice();
        }

        public static void PoliceReports()
        {
            Console.WriteLine("Select a location to read about the patrolling constable on duty's observations in the area:");
            
            Console.WriteLine("D - Diogenes Club");
            Console.WriteLine("C - Carlton House Terrace");
            Console.WriteLine("S - St James's Park");
            Console.WriteLine("CC - Charing Cross Station");
            Console.WriteLine("V - Villiers St Hotel");
            Console.WriteLine("M - Market");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                
                case "D":
                    Console.WriteLine("Diogenes Club: The constable reports that a man in an orange cravat and carrying a briefcase was seen catching a cab upon leaving the club at 12:46pm.");
                    break;
                case "C":
                    Console.WriteLine("Carlton House Terrace: The constable reports that a lady with a bright blue hat and yellow handbag was seen outside at the corner of the Diogenes Club walking towards St. James's Park at 12:48pm.");
                    Console.WriteLine("A big man with overalls with a large bag of tools turned down Carlton House Terrace at 12:26pm.");
                    break;
                case "S":
                    Console.WriteLine("St James's Park: The constable reports that the park was busy, but no suspicious activity was observed.");
                    break;
                case "CC":
                    Console.WriteLine("Charing Cross Station: The constable reports that a small boy ran off with a lady's yellow handbag. She told the constable not to worry about the bag as she was late catching her train. She was wearing a bright blue hat.");
                    break;
                case "V":
                    Console.WriteLine("Villiers St Hotel: The constable reports that an old lady trying to get into a cab outside the hotel was pushed roughly aside by a tall bearded gentleman. The old lady fell to the ground and the constable rushed over to help her but when he looked up, the cab and the tall bearded gentleman were gone.");
                    break;
                case "M":
                    Console.WriteLine("Market: The constable reports that a small boy carrying a yellow handbag was running through the crowd knocking into people.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    PoliceReports();
                    return;
            }
            GetPlayerMenuChoice();
        }

        public static void TrainSchedule()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("   TRAINS");
            Console.WriteLine("==============");
            Console.WriteLine("EUSTON STATION 4:00PM TO MANCHESTER");
            Console.WriteLine("--------------");
            Console.WriteLine("CHARING CROSS STATION 1:00PM TO CHELTENHAM");
            Console.WriteLine("--------------");
            Console.WriteLine("VICTORIA STATION 10:00PM TO CAMBRIDGE");
            Console.WriteLine("--------------");
            GetPlayerMenuChoice();
        }

        public static void Newspaper()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("ADVERTISEMENTS");
            Console.WriteLine("==============");
            Console.WriteLine("Scampie & Sons available to do plumbing work at short notice.");
            Console.WriteLine("--------------");
            Console.WriteLine("    NEWS");
            Console.WriteLine("==============");
            Console.WriteLine("Pipe bursts overnight at the German Embassy. Services will be closed today.");
            Console.WriteLine("--------------");
            GetPlayerMenuChoice();
        }

        public static void Directory()
        {
            Console.WriteLine("Select a company to contact for more information:");

        }


    }
}