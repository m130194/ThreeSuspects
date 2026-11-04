using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ThreeSuspects
{
    public class Game
    {

        private List<string> _cluesCollected = new();

        public void AddClue(string clue)
        {
            _cluesCollected.Add(clue);
        }
        private bool _isCulpritCaught = false;

        private int _playerSteps = 0;

        private int _timeInGame
        {
            get
            {
                return 1 + _playerSteps;
            }
        }



        public void Play()
        {
            while (_playerSteps < 11 || !_isCulpritCaught)
            {
                GetPlayerMenuChoice();
            }
            if (_isCulpritCaught)
            {
                Console.WriteLine("Congratulations! You have caught the culprit and retrieved the stolen document!");
            }
            else
            {
                Console.WriteLine("You have run out of time! The culprit has escaped with the stolen document!");
            }

        }

        /// <summary>
        /// Gets the player's menu choice.
        /// </summary>
        /// <returns>The player's menu choice.</returns>
        public string GetPlayerMenuChoice()
        {
            
            while (true)
            {
                Console.WriteLine($"The time is now {_timeInGame}:00 PM");
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
                        ReadNewspaper();
                        break;
                    case "D":
                        ViewDirectory();
                        break;
                    case "M":
                        ViewMap();
                        break;
                    case "T":
                        ViewTrainSchedule();
                        break;
                    case "P":
                        ReadPoliceReports();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        

        public void VisitMarket()
        {
            Console.WriteLine("You have arrived at the Market.");
            if (_cluesCollected.Contains("SB"))
            {
                Console.WriteLine("You see a small boy running through the crowd carrying a yellow handbag.");
                Console.WriteLine("He knocks into people and seems to be in a hurry.");
                Console.WriteLine("You can try to follow him or ask around for more information.");
            }
            else
            {
                Console.WriteLine("The market is bustling with activity. You see various stalls selling fruits, vegetables, and other goods.");
                Console.WriteLine("You can ask around for information or try to find clues about the stolen document.");
            }
            _playerSteps++;
        }

        public void ViewMap()
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
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "E":
                    Console.WriteLine("You have arrived at Euston Station.");

                    break;
                case "B":
                    Console.WriteLine("You have arrived at the British Museum.");

                    break;
                case "W":
                    Console.WriteLine("You have arrived at Waldenboch Florists.");

                    break;
                case "P":
                    Console.WriteLine("You have arrived at Plumber Scampie & Sons.");

                    break;
                case "D":
                    Console.WriteLine("You have arrived at the Diogenes Club.");

                    break;
                case "G":
                    Console.WriteLine("You have arrived at the German Embassy. It is closed for the day due to plumbing issues causing a flood overnight.");

                    break;
                case "S":
                    Console.WriteLine("You have arrived at St James's Park. There are lots of people around.");

                    break;
                case "C":
                    Console.WriteLine("You have arrived at Charing Cross Station.");

                    break;
                case "V":
                    Console.WriteLine("You have arrived at Villiers St Hotel.");

                    break;
                case "M":
                    VisitMarket();

                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ViewMap();
                    return;
            }
            _playerSteps++;

        }

        public void ReadPoliceReports()
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
                    AddClue("OC");
                    break;
                case "C":
                    Console.WriteLine("Carlton House Terrace: The constable reports that a lady with a bright blue hat and yellow handbag was seen outside at the corner of the Diogenes Club walking towards St. James's Park at 12:48pm.");
                    Console.WriteLine("A big man with overalls with a large bag of tools turned down Carlton House Terrace at 12:26pm.");
                    AddClue("BL");
                    AddClue("OM");
                    break;
                case "S":
                    Console.WriteLine("St James's Park: The constable reports that the park was busy, but no suspicious activity was observed.");
                    break;
                case "CC":
                    Console.WriteLine("Charing Cross Station: The constable reports that a small boy ran off with a lady's yellow handbag. She told the constable not to worry about the bag as she was late catching her train. She was wearing a bright blue hat.");
                    AddClue("YH");
                    break;
                case "V":
                    Console.WriteLine("Villiers St Hotel: The constable reports that an old lady trying to get into a cab outside the hotel was pushed roughly aside by a tall bearded gentleman. The old lady fell to the ground and the constable rushed over to help her but when he looked up, the cab and the tall bearded gentleman were gone.");
                    AddClue("TB");
                    break;
                case "M":
                    Console.WriteLine("Market: The constable reports that a small boy carrying a yellow handbag was running through the crowd knocking into people.");
                    AddClue("SB");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ReadPoliceReports();
                    return;
            }

        }

        public void ViewTrainSchedule()
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

        }

        public void ReadNewspaper()
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

        }

        public void ViewDirectory()
        {
            Console.WriteLine("Select a company to contact for more information:");
            Console.WriteLine("C - Central Carriage Station (for movements of suspects)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "C":
                    ContactCentralCarriageStation();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ViewDirectory();
                    return;
            }
        }

        public void ContactCentralCarriageStation()
        {
            Console.WriteLine("You have contacted the Central Carriage Station.");
            
            if (_cluesCollected.Contains("OC"))
            {
                Console.WriteLine("A cab driver informs you that a man in an orange cravat and carrying a briefcase caught a cab outside the Diogenes Club to the British Museum and stopped at the Waldenboch Florists on the way.");
            }
            if (_cluesCollected.Contains("BL"))
            {
                Console.WriteLine("A cab driver informs you that a lady with a bright blue hat and yellow handbag was picked up at St James' Park and dropped off outside the Villiers St Hotel. He thinks she walked in the direction of Charing Cross Station, but he is not sure because he had another passenger jump into his cab in a hurry.");
            }
            else
            {
                Console.WriteLine("A cab driver informs you that a man in an orange cravat and carrying a briefcase was seen catching a cab at 12:46pm.");
                Console.WriteLine("He also mentions that a lady with a bright blue hat and yellow handbag was seen outside the Diogenes Club walking towards St. James's Park at 12:48pm.");
                AddClue("OC");
                AddClue("BL");
            }
            
        }
    }
}
