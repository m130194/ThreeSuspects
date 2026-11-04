namespace ThreeSuspects
{
    internal class Program
    {

        static void Main()
        {
            Console.WriteLine("A top secret document has been stolen from Mycroft!");
            Console.WriteLine("It was stolen by one of three suspects through an open window at the Diogenes Club");
            Console.WriteLine("Track the thief and retrieve the document before midnight!");
            Game game = new Game();
            game.Play();
        }

        


    }
}