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

        private int _money = 10;
        private void UseWallet(int amount)
        {
            if (_money - amount < 0)
            {
                Console.WriteLine("You do not have enough money to make this purchase.");
                //add a line here to break out of the current loop?
            }
            else
            {
                _money -= amount;
            }
            return;
        }

        //this needs to stop the game once _playerSteps > 11
        public void Play()
        {
            while (_playerSteps < 11 && !_isCulpritCaught)
            {
                GetPlayerMenuChoice();
            }
            if (_playerSteps < 11 && _isCulpritCaught)
            {
                Console.WriteLine("Congratulations! You have caught the culprit and retrieved the stolen document!");
                return;
            }
            else
            {
                Console.WriteLine("You have run out of time! The culprit has escaped with the stolen document!");
                return;
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
            if (_money >= 3)
            {
                BuyHandbag();
            }
            Console.WriteLine("You ask around for information about the stolen document, but no one knows about it.");
            
        }

        public void BuyHandbag()
        {
            Console.WriteLine("He asks if you're interested in buying a briefcase or handbag from him for 3 pounds (Y/N)?");
            string choice = Console.ReadLine();
            Console.WriteLine("");
            if (choice == "Y")
            {
                Console.WriteLine("");
                Console.WriteLine("The small boy shows you:");
                Console.WriteLine("R - Red briefcase");
                Console.WriteLine("G - Green briefcase");
                Console.WriteLine("Y - Yellow handbag");
                Console.WriteLine("Which one would you like to buy (R/G/Y)?");
                string itemChoice = Console.ReadLine();
                Console.WriteLine("");
                switch (itemChoice)
                {
                    case "R":
                        UseWallet(3);
                        Console.WriteLine("You purchase the red briefcase. It is empty but the perfect size to hold the stolen document.");
                        AddToInventory("RedBriefcase");
                        break;
                    case "G":
                        UseWallet(3);
                        Console.WriteLine("You purchase the green briefcase. It is empty but the perfect size to hold the stolen document.");
                        AddToInventory("GreenBriefcase");
                        break;
                    case "Y":
                        UseWallet(3);
                        Console.WriteLine("You purchase the yellow handbag. It is empty but the perfect size to hold the stolen document.");
                        AddToInventory("YellowHandbag");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        return;
                }
                //if (itemChoice == "R")
                //{
                //    UseWallet(3);
                //    Console.WriteLine("You purchase the red briefcase. It is empty but the perfect size to hold the stolen document.");
                //    AddToInventory("RedBriefcase");

                //}
                //else if (itemChoice == "G")
                //{
                //    UseWallet(3);
                //    Console.WriteLine("You purchase the green briefcase. It is empty but the perfect size to hold the stolen document.");
                //    AddToInventory("GreenBriefcase");

                //}
                //else if (itemChoice == "Y")
                //{
                //    UseWallet(3);
                //    Console.WriteLine("You purchase the yellow handbag. It is empty but the perfect size to hold the stolen document.");
                //    AddToInventory("YellowHandbag");
                //}
            }
            else
            {
                return;
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
                Console.WriteLine("\"Oh, you must mean Mr Bernard Falour of Cambridge? Yes, I remember him. He stayed here last night.\" says the porter.");
                Console.WriteLine("\"I dropped his green briefcase while I was trying to help him as he was leaving the hotel. Luckily it was empty.\"");
                AddClue("GreenBriefcase");
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
            Console.WriteLine("You ask the station master if there has been any suspicious incidents today.");
            Console.WriteLine("He says a boy stole a handbag from a passenger and ran off in the direction of the markets.");
            AddClue("SmallBoy");
            AddClue("YellowHandbag");
            if (_cluesCollected.Contains("BlueHatLady"))
            {
                Console.WriteLine("You ask the station master about the lady with the bright blue hat. He says, \"That's the passenger who had her handbag stolen! I saw her running to catch a train to Cheltenham.\"");
            }
            CatchTrain("Cheltenham");
            Console.WriteLine("You decide to leave the station and continue your investigation.");
        }

        public void CatchTrain(string destination)
        {
            if (_money < 3)
            {
                Console.WriteLine("You do not have enough money to catch the train.");
                return;
            }
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
                if (destination == "Manchester")
                {
                    
                    if (_cluesCollected.Contains("PinkDressGirl"))
                    {
                        
                        if (!_inventory.Contains("Flowers"))
                        {
                            Console.WriteLine("The girl in pink dress throws her bouquet into a garbage bin before boarding the train. You pick up the bouquet from the garbage bin and find nothing but flowers inside.");
                        }

                    }
                    
                    else
                    {
                        Console.WriteLine("No one aboard knows anything about a stolen document.");
                    }
                    Console.WriteLine("No one else in Manchester knows about the stolen document. You return back to London.");
                }
            }
            else
            {
                Console.WriteLine("You decide not to catch the train.");
            }
        }

        public void VisitPark()
        {
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at St James's Park. The park is full of police questioning passersby about the theft at the Diogenes Club.");
            if (_cluesCollected.Contains("BlueHatLady"))
            {
                Console.WriteLine("You look around for the lady with the bright blue hat. She is nowhere to be seen in the park.");
            }
            if (_cluesCollected.Contains("OverallsMan"))
            {
                Console.WriteLine("You see the big man with overalls sitting under a tree eating his lunch. You sit next to him and make friendly conversation.");
                Console.WriteLine("While he is distracted, you look into his bag but all you find are plumbing tools.");
            }
            else
            {
                Console.WriteLine("No one seems of particular interest to you.");
            }
        }

        public void VisitEmbassy()
        {
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at the German Embassy.");
            if (_cluesCollected.Contains("OverallsMan"))
            {
                Console.WriteLine("You ask the security guard about the big man with overalls. He says the man with overalls is a plumber who was called in to fix the plumbing issues.");
                Console.WriteLine("\"I watched him like a hawk the entire time he was working,\" says the security guard. \"Can't be too careful with thefts happening at the Diogenes Club next door.");
                Console.WriteLine("I even checked his bag of tools to make sure he didn't steal any important papers from our office.");
                Console.WriteLine("The only thing he had in his bag other than tools was a receipt from the Baldwin Card Club. I just saw him walk out to the park to have his lunch.\"");
            }
            else
            {
                Console.WriteLine("The embassy is closed for the day due to plumbing issues causing a flood overnight. No one is there except a stern looking security guard eyeing you suspiciously.");
            }
        }

        public void VisitDiogenesClub()
        {
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at the Diogenes Club. The club is quiet and members are engaged in their activities.");
            if (_cluesCollected.Contains("OrangeCravat"))
            {
                Console.WriteLine("You ask the club's doorman about the man in the orange cravat. He says the man's name is Lionel Mabry and that Lional was inquiring about club membership.");
                Console.WriteLine(" Lionel left in a hurry carrying a red briefcase. You ask the doorman if he knows where the man went, but he says he doesn't know.");
            }
            else
            {
                Console.WriteLine("No one seems of particular interest to you.");
            }
        }

        public void VisitPlumbers()
        {
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at Plumber Scampie & Sons. The shop is busy with customers.");
            if (_cluesCollected.Contains("OverallsMan"))
            {
                Console.WriteLine("You ask about the big man with overalls. \"That's Jim, my eldest,\" says Mr. Scampie.");
                Console.WriteLine("\"He's not here at the moment. We got a call from the German embassy at 12:15pm. Seems like they had trouble finding a plumber to come out at such short notice. Jim left straight away to fix the plumbing issues at the German Embassy.\"");
            }
            else
            {
                Console.WriteLine("No one seems of particular interest to you.");
            }
        }

        public void VisitFlorists()
        {
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at Waldenboch Florists. The shop is filled with the scent of fresh flowers.");
            if (_cluesCollected.Contains("OrangeCravat"))
            {
                Console.WriteLine("You ask the florist about the man in the orange cravat. \"The man bought the largest bouquet of flowers and left in a hurry,\" says the florist.");
                Console.WriteLine("\"He was in such a hurry, he even left his red briefcase behind. I checked inside to see if there was a name or an address but it was empty.\"");
            }
            else
            {
                Console.WriteLine("No one seems of particular interest to you.");
            }
            if (_money >= 2)
            {
                BuyFlowers();
                return;
            }
            Console.WriteLine("You thank the florist and leave.");
        }

        public void BuyFlowers()
        {
            Console.WriteLine("The florist asks if you would like to buy a large bouquet of flowers for 2 pounds (Y/N)?");
            string choice = Console.ReadLine();
            Console.WriteLine("");
            if (choice == "Y")
            {
                Console.WriteLine("You purchase a large bouquet of flowers.");
                UseWallet(2);
                AddToInventory("Flowers");
            }
        }

        public void VisitMuseum()
        {
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at the British Museum. The museum is filled with visitors admiring the exhibits.");
            if (_cluesCollected.Contains("OrangeCravat"))
            {
                Console.WriteLine("You ask the museum staff about the man in the orange cravat. They say he was here earlier today and met up with a girl in a pink dress.");
                Console.WriteLine("The girl looked quite upset and mentioned something about Manchester.");
                Console.WriteLine("He gave the girl a large bouquet of flowers and she took them but stormed angrily out of the museum in tears.");
                Console.WriteLine("\"The man asked me if I had seen his lost red briefcase,\" the staff member says.");
                Console.WriteLine("\"He has been sitting alone at the museum cafe since then,\" the staff member points out.");
                Console.WriteLine("You see the dejected-looking man with an orange cravat without a briefcase and decide to leave him alone.");
                AddClue("PinkDressGirl");
            }
            else
            {
                Console.WriteLine("No one seems of particular interest to you.");
            }
            
        }

        public void VisitEustonStation()
        {
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at Euston Station");
            if (_cluesCollected.Contains("PinkDressGirl"))
            {
                Console.WriteLine("It is easy to spot the girl in the pink dress carrying a large bouquet of flowers on the platform of the train to Manchester. You notice she is not carrying anything else.");
                
                if (_inventory.Contains("Flowers"))
                {
                    Console.WriteLine("You pretend to bump into her by accident and causing her to drop her flowers on the ground. The flowers scatter on the platform. You offer your bouquet as a replacement.");

                }
                if (_cluesCollected.Contains("OrangeCravat"))
                {
                    Console.WriteLine("You ask her about the man in the orange cravat. \"That's Lionel, my boyfriend.\" she says, her face darkening.");
                    Console.WriteLine("\"I discovered a bouquet of roses in my sister's room with a card signed by him.\"");
                }
            }
            else
            {
                Console.WriteLine("No one seems of particular interest to you.");
            }
            CatchTrain("Manchester");
        }

        public void VisitVictoriaStation()
        {
            _playerSteps++;
            Console.WriteLine("");
            Console.WriteLine($"Player Step: {_playerSteps}");
            Console.WriteLine("");
            Console.WriteLine("You have arrived at Victoria Station. The platforms are bustling with passengers.");
            if (_cluesCollected.Contains("TallBeardedMan") && _cluesCollected.Contains("GreenBriefcase"))
            {
                Console.WriteLine("You see the tall bearded man with a green briefcase waiting for a train to Cambridge.");
                Console.WriteLine("You ask if his name is Mr Falour. \"I have no idea what you're talking about,\" he says, with a face of stone.");
                if (_inventory.Contains("GreenBriefcase"))
                {
                    Console.WriteLine("You distract him by asking the time, and as he is looking at his watch, you swap his green briefcase for yours and run.");
                    Console.WriteLine("He gives chase but you manage to escape and hide behind a bookseller's stall. Opening the briefcase, you find the stolen document.");
                    _isCulpritCaught = true;
                }
            }
            else
            {
                Console.WriteLine("No one seems of particular interest to you.");
            }
        }

        public void ViewMap()
        {
            Console.WriteLine("Select a location to visit by typing in the letter. Each visit will take up to 1 hour and the clock will advance an hour.");
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
            Console.WriteLine("VS - Victoria Station");
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
                    VisitEustonStation();

                    break;
                case "B":
                    VisitMuseum();

                    break;
                case "W":
                    VisitFlorists();

                    break;
                case "P":
                    VisitPlumbers();

                    break;
                case "D":
                    VisitDiogenesClub();

                    break;
                case "G":
                    VisitEmbassy();

                    break;
                case "S":
                    VisitPark();

                    break;
                case "C":
                    VisitCharingCrossStation();

                    break;
                case "V":
                    VisitHotel();

                    break;
                case "M":
                    VisitMarket();

                    break;
                case "VS":
                    VisitVictoriaStation();
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
                    Console.WriteLine("St James's Park: The constable reports that the park was filled with police questioning passersby about the theft at the Diogenes Club.");
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
                Console.WriteLine("A cab driver informs you that a lady with a bright blue hat and yellow handbag was picked up at St James' Park and dropped off outside the Villiers St Hotel.");
                Console.WriteLine("He thinks she walked in the direction of Charing Cross Station, but he is not sure because he heard a commotion outside his cab and had another passenger jump into his cab in a hurry.");
            }
            if (_cluesCollected.Contains("TallBeardedMan"))
            {
                Console.WriteLine("You ask about the tall bearded man.");
                Console.WriteLine("A cab driver informs you he was picked up Villiers St Hotel and driven to Victoria Station with his green briefcase.");
                AddClue("GreenBriefcase");
            }
            else
            {
                Console.WriteLine("A cab driver says he can help you only track suspects who took a cab and if you come back with a description of them.");
            }
            
        }
    }
}
