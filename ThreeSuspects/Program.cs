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


        /// <summary>
        /// Gets the player's menu choice.
        /// </summary>
        /// <returns>The player's menu choice.</returns>
        public static string GetPlayerMenuChoice()
        {
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
                        return "Newspaper";
                    case "D":
                        return "Directory";
                    case "M":
                        return "Map";
                    case "T":
                        return "Train schedule";
                    case "P":
                        return "Police reports";
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }




    }
}