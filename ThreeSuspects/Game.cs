using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ThreeSuspects
{
    public class Game
    {

        private List<string> _cluesCollected = new();

        private List<string> _inventory = new();

        public void AddClue(string clue)
        {
            _cluesCollected.Add(clue);
        }

        public void AddToInventory(string item)
        {
            _inventory.Add(item);
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

        //private int _money
        //{
        //    if (_money <= 0)
        //    {
        //        Console.WriteLine("You have run out of money! You cannot continue your investigation.");
        //        _isCulpritCaught = false;
        //        _playerSteps = 11;
        //    }
        //    else)
        //    {
        //        return _money;
        //    }

        //} = 10;

        private int _money = 10;
        private void UseWallet(int amount)
        {
            if (_money - amount < 0)
            {
                Console.WriteLine("You do not have enough money to make this purchase.");
            }
            else
            {
                _money -= amount;
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
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($"The time is now {_timeInGame}:00 PM");
                Console.WriteLine($"Your wallet contains ${_money}");
                Console.WriteLine("");
                Console.WriteLine("Choose a resource:");
                Console.WriteLine("N - Newspaper");
                Console.WriteLine("D - Directory");
                Console.WriteLine("M - Map");
                Console.WriteLine("T - Train schedule");
                Console.WriteLine("P - Police reports");
                Console.WriteLine("");
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
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at the Market.");

            if (_cluesCollected.Contains("YellowHandbag") && !_inventory.Contains("YellowHandbag"))
            {
                Console.WriteLine("You see a yellow handbag being sold by a small boy in the corner stall with other second hand goods.");
                Console.WriteLine("You ask the small boy about the handbag and his face turns sulky and red. \"None of your business\", he says.");
            }
            else
            {
                Console.WriteLine("The market is bustling with activity. You see various stalls selling fruits, vegetables, and second hand goods.");
                Console.WriteLine("You see a small boy selling an assortment of second hand bags at a corner stall.");
            }
            BuyHandbag();
            Console.WriteLine("You ask around for information about the stolen document, but no one knows about it.");
            
        }

        public void BuyHandbag()
        {
            Console.WriteLine("He asks if you're interested in buying a briefcase or handbag from him (Y/N)?");
            string choice = Console.ReadLine();
            if (choice == "Y")
            {
                Console.WriteLine("");
                Console.WriteLine("The small boy shows you:");
                Console.WriteLine("R - Red briefcase");
                Console.WriteLine("G - Green briefcase");
                Console.WriteLine("Y - Yellow handbag");
                Console.WriteLine("Which one would you like to buy (R/G/Y)?");
                string itemChoice = Console.ReadLine();
                if (itemChoice == "R")
                {
                    Console.WriteLine("You purchase the red briefcase. It is empty but the perfect size to hold the stolen document.");
                    AddToInventory("RedBriefcase");
                    UseWallet(3);
                }
                else if (itemChoice == "G")
                {
                    Console.WriteLine("You purchase the green briefcase. It is empty but the perfect size to hold the stolen document.");
                    AddToInventory("GreenBriefcase");
                    UseWallet(3);
                }
                else if (itemChoice == "Y")
                {
                    Console.WriteLine("You purchase the yellow handbag. It is empty but the perfect size to hold the stolen document.");
                    AddToInventory("YellowHandbag");
                    UseWallet(3);
                }
            }
        }

        public void VisitHotel()
        {
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at the Villiers St Hotel.");
            Console.WriteLine("The hotel lobby is busy with guests checking in and out.");
            if (_cluesCollected.Contains("TallBeardedMan"))
            {
                Console.WriteLine("You ask the porter about the tall bearded gentleman as the one who pushed an old lady aside outside the hotel earlier today.");
                Console.WriteLine("\"Oh, you must mean Mr Bernard Falour? Yes, I remember him. He stayed here last night.\" says the porter. \"I dropped his briefcase while I was trying to help him as he was leaving the hotel. Luckily it was empty.");
            }
            if (!_cluesCollected.Contains("TallBeardedMan"))
            {
                Console.WriteLine("No one seems of particular interest to you.");
            }
            Console.WriteLine("You decide to leave the hotel and continue your investigation.");
        }

        public void VisitCharingCrossStation()
        {
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at Charing Cross Station. The platforms are bustling with passengers.");
            if (_cluesCollected.Contains("BlueHatLady"))
            {
                Console.WriteLine("You ask the station master about the lady with the bright blue hat and yellow handbag. He says he saw her running to catch a train to Cheltenham.");
            }
            if (!_cluesCollected.Contains("BlueHatLady"))
            {
                Console.WriteLine("No one seems of particular interest to you.");
            }
            CatchTrain("Cheltenham");
            Console.WriteLine("You decide to leave the station and continue your investigation.");
        }

        public void CatchTrain(string destination)
        {
            Console.WriteLine($"A round trip train journey to {destination} will cost 3 pounds and take up 2 hours. Do you want to catch the train to {destination}? (Y/N)");
            string choice = Console.ReadLine();
            if (choice.ToUpper() == "Y")
            {
                _playerSteps += 2;
                UseWallet(3);
                Console.WriteLine($"You catch the train to {destination}.");
                if (destination == "Cheltenham")
                {
                    Console.WriteLine("As soon as you alight the train, you see a lady with a bright blue hat order tea at the cafe opposite Cheltenham station. She is not carrying any luggage nor a handbag. She sits alone at a corner table.");
                    Console.WriteLine("You ask her about the stolen document and she tells you that she saw a man in an orange cravat and carrying a red briefcase running towards the Diogenes Club earlier today.");
                    AddClue("OrangeCravat");
                    Console.WriteLine("No one else in Cheltenham knows about the stolen document. You return back to London.");
                }
            }
            else
            {
                Console.WriteLine("You decide not to catch the train.");
            }
        }

        public void ViewMap()
        {
            Console.WriteLine("Select a location to visit by typing in the letter. Each visit will take up 1 hour and the clock will advance an hour.");
            Console.WriteLine("MAP OF LONDON");
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
            Console.WriteLine("X - Back to main menu");
            Console.WriteLine("");
            Console.WriteLine("Enter your choice:");
            string choice = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("");
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
                case "X":
                    Console.WriteLine("Back to main menu.");
                    return;
                    
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ViewMap();
                    return;
            }
            

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
                    Console.WriteLine("Diogenes Club: The constable reports that a man in an orange cravat and carrying a red briefcase was seen catching a cab upon leaving the club at 12:46pm.");
                    AddClue("OrangeCravat");
                    break;
                case "C":
                    Console.WriteLine("Carlton House Terrace: The constable reports that a lady with a bright blue hat and yellow handbag was seen outside at the corner of the Diogenes Club walking towards St. James's Park at 12:48pm.");
                    Console.WriteLine("A big man with overalls with a large bag of tools turned down Carlton House Terrace at 12:26pm.");
                    AddClue("BlueHatLady");
                    AddClue("OverallsMan");
                    break;
                case "S":
                    Console.WriteLine("St James's Park: The constable reports that the park was busy at lunchtime as the weather was particularly pleasant today, but no suspicious activity was observed.");
                    break;
                case "CC":
                    Console.WriteLine("Charing Cross Station: The constable reports that a small boy ran off with a lady's yellow handbag. She told the constable not to worry about the bag as she was late catching her train. She was wearing a bright blue hat.");
                    AddClue("YellowHandbag");
                    break;
                case "V":
                    Console.WriteLine("Villiers St Hotel: The constable reports that an old lady trying to get into a cab outside the hotel was pushed roughly aside by a tall bearded gentleman. The old lady fell to the ground and the constable rushed over to help her but when he looked up, the cab and the tall bearded gentleman were gone.");
                    AddClue("TallBeardedMan");
                    break;
                case "M":
                    Console.WriteLine("Market: The constable reports that the grocer complained about a small boy running through the crowd knocked over the grocer's display of apples. While the grocer stumbled over the rolling apples on the ground, the boy had disappeared into the crowd.");
                    AddClue("SmallBoy");
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
            
            if (_cluesCollected.Contains("OrangeCravat"))
            {
                Console.WriteLine("You ask about the man in the orange cravat.");
                Console.WriteLine("A cab driver informs you that a man in an orange cravat and carrying a briefcase caught a cab outside the Diogenes Club to the British Museum and stopped at the Waldenboch Florists on the way.");
            }
            if (_cluesCollected.Contains("BlueHatLady"))
            {
                Console.WriteLine("You ask about the lady with the bright blue hat.");
                Console.WriteLine("A cab driver informs you that a lady with a bright blue hat and yellow handbag was picked up at St James' Park and dropped off outside the Villiers St Hotel. He thinks she walked in the direction of Charing Cross Station, but he is not sure because he had another passenger jump into his cab in a hurry.");
            }
            else
            {
                Console.WriteLine("A cab driver says he can help you track the suspects if you come back with a description of them.");
            }
            
        }
    }
}
