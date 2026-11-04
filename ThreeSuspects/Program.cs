namespace ThreeSuspects
{
    internal class Program
    {

        static void Main()
        {
            Console.WriteLine("A top secret document has been stolen from Mycroft!");
            Console.WriteLine("It was stolen by one of three suspects through an open window at the Diogenes Club");
            Console.WriteLine("Track the thief and retrieve the document before midnight!");


        }

        /// <summary>
        /// Gets the player's menu choice.
        /// </summary>
        /// <returns>The player's menu choice.</returns>
        public string GetPlayerMenuChoice()
        {
            while (true)
            {
                Console.WriteLine("Choose a resource:");
                Console.WriteLine("1. Newspaper");
                Console.WriteLine("2. Cab company");
                Console.WriteLine("3. Map");
                Console.WriteLine("4. Train schedule");
                Console.WriteLine("5. Police report");
                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return "Newspaper";
                    case "2":
                        return "Cab company";
                    case "3":
                        return "Map";
                    case "4":
                        return "Train schedule";
                    case "5":
                        return "Police report";
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }




    }
}