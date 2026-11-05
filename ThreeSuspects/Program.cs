namespace ThreeSuspects
{
    internal class Program
    {

        static void Main()
        {
            Console.WriteLine("A top secret document has been stolen from Mycroft!");
            Console.WriteLine("It was stolen by one of three suspects through an open window at the Diogenes Club between 12:40pm and 12:50pm.");
            Console.WriteLine("Track the thief and retrieve the document before midnight!");
            Console.WriteLine("Mycroft has given you 10 pounds to pay for investigation expenses.");
            Game game = new Game();
            game.Play();
        }

        


    }
}