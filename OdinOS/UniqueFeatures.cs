using System;
using System.Threading;

namespace OdinOS
{
    public class UniqueFeatures
    {
        // Preparing info for rock, paper and scissors game
        public static bool gameLoop = true;
        public static int userPoints = 0;
        public static int computerPoints = 0;

        // Bonus features of Group 1 OS
        public static void rockpaperscissorsvsbot()
        {
            // Basic
            while (gameLoop)
            {
                Console.WriteLine(" Welcome to Rock, Paper, Scissors! ");
                Console.WriteLine(" Please enter a number below for your choice (+ Enter):");
                Console.WriteLine(" 1.Rock");
                Console.WriteLine(" 2.Paper");
                Console.WriteLine(" 3.Scissors");
                Console.Write(" Choice: ");
                string userChoice = Console.ReadLine();

                Random randomChoice = new Random();
                int computerChoice = randomChoice.Next(1, 4);

                switch (computerChoice)
                {
                    case 1:
                        if (userChoice == "1")
                        {
                            // This is a tie
                            Console.WriteLine(" User has chosen Rock - Computer chosen Rock");
                            Console.WriteLine(" It is a tie. :O");
                        }
                        else if (userChoice == "2")
                        {
                            Console.WriteLine(" User chose Paper - Computer chose Rock");
                            Console.WriteLine(" User wins! :)");
                            userPoints++;
                        }
                        else if (userChoice == "3")
                        {
                            Console.WriteLine(" User chose Scissors - Computer chose Rock");
                            Console.WriteLine(" Computer wins! :(");
                            computerPoints++;
                        }
                        break;
                    case 2:
                        if (userChoice == "1")
                        {
                            //This is a tie
                            Console.WriteLine(" User chose Rock - Computer chose Rock");
                            Console.WriteLine(" It is a tie. :O");
                        }
                        else if (userChoice == "2")
                        {
                            Console.WriteLine(" User chose Paper - Computer chose Rock");
                            Console.WriteLine(" User wins! :)");
                            userPoints++;
                        }
                        else if (userChoice == "3")
                        {
                            Console.WriteLine(" User chose Scissors - Computer chose Rock");
                            Console.WriteLine(" Computer wins! :(");
                            computerPoints++;
                        }
                        break;
                    case 3: //Computer chose scissors
                        if (userChoice == "1")
                        {
                            //This is a tie
                            Console.WriteLine(" User chose Rock - Computer chose Scissors");
                            Console.WriteLine(" User wins! :)");
                            userPoints++;
                        }

                        else if (userChoice == "2")
                        {
                            Console.WriteLine(" User chose Paper - Computer chose Scissors");
                            Console.WriteLine(" Computer wins! :(");
                            computerPoints++;
                        }
                        else if (userChoice == "3")
                        {
                            Console.WriteLine(" User chose Scissors - Computer chose Scissors");
                            Console.WriteLine(" It is a tie. :O");
                        }
                        break;
                }

                Console.WriteLine(" Do you wish to play again?");
                Console.Write(" Enter Y for Yes or N for no - Play?: ");

                string playAgain = Console.ReadLine();
                if (playAgain == "N" || playAgain == "n" || playAgain == "no" || playAgain == "NO" || playAgain == "No" || playAgain == "nO")
                {
                    gameLoop = false;
                    Console.WriteLine($" User has {userPoints} points - Computer has {computerPoints} points");
                    Console.WriteLine($" See ya again, User! ");
                    Console.WriteLine("     _______    ");
                    Console.WriteLine("    |.-----.|   ");
                    Console.WriteLine("    || x  x||   ");
                    Console.WriteLine("    ||_.-._||   ");
                    Console.WriteLine("    `--)-(--`   ");
                    Console.WriteLine("   __[=== o]__  ");
                    Console.WriteLine("  |:::::::::::| ");
                    Console.WriteLine("  `-=========-` ");
                    Thread.Sleep(3000);
                }
            }
        }

        public static void coinflip()
        {
            // Basic coin flip 
            string[] coin = { "heads", "tails" };
            int user;
            int heads = 0;
            int tails = 0;
            var rand = new Random();
            const int faces = 2;


            Console.WriteLine(" Enter 1 to flip a coin, or 2 to leave: ");
            Console.Write(" Coin Flip?: ");
            user = Convert.ToInt32(Console.ReadLine());

            while (user == 1)
            {
                int second = rand.Next(faces);
                if (second == 1)
                {
                    Console.WriteLine(" Coin landed on heads!");
                    heads += 1;
                    Console.WriteLine($" You have landed on heads: {heads} time(s)!");
                    Console.WriteLine($" You have landed on tails: {tails} time(s)!");
                }
                else
                {
                    Console.WriteLine(" Coin landed on tails!");
                    tails += 1;
                    Console.WriteLine($" You have landed on heads: {heads} time(s)");
                    Console.WriteLine($" You have landed on tails: {tails} time(s)");
                }

                Console.WriteLine(" Enter 1 to flip again or 2 to leave: ");
                Console.Write(" Flip Again?: ");
                user = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(" See ya again, buckaroo!");
            Console.WriteLine("               _,.                               ");
            Console.WriteLine("           , ''   `.     __....__                ");
            Console.WriteLine("         , '        >.-''        ``-.__,)        ");
            Console.WriteLine("       , '      _,''           _____ _,'         ");
            Console.WriteLine("      /      ,'           _.:':::_`:-._          ");
            Console.WriteLine("     :     , '       _..-''  l`'.;.`-:::`:.      ");
            Console.WriteLine("     ;    /       ,'  ,::'.l,'`.`. `l::)`        ");
            Console.WriteLine("    /    /      ,'        l   `. '  )  )/        ");
            Console.WriteLine("   /    /      /:`.     `--`'   l     '`         ");
            Console.WriteLine("   `-._ /      /::::)             )              ");
            Console.WriteLine("      /      /,-.:(   , _   `.-'                 ");    
            Console.WriteLine("     ;      :(,`.`-' ',`.     ;                  ");
            Console.WriteLine("    :       |:l`' )      `-.._l _                ");
            Console.WriteLine("    |         `:-(             `)``-._           ");
            Console.WriteLine("    |           `.`.        /``'      ``:-.-__,  ");    
            Console.WriteLine("    :           / `:l .     :            ` l`-   ");
            Console.WriteLine("     (        , '   '}  `.   |                   ");
            Console.WriteLine("  _..-`.    ,'`-.   }   |`-'                     ");
            Console.WriteLine(", '__    `-'' -.`.'._|   |                       ");
            Console.WriteLine("    ```--..,.__.(_|.|   |::._                    ");
            Console.WriteLine("      __..','/ ,' :  `-.|::)_`.                  ");
            //Console.WriteLine("      `..__..-'   |`.      __,'                  ");
            //Console.WriteLine("                  :  `-._ `  ;                   ");
            //Console.WriteLine("                   l l   )  /                    ");
            //Console.WriteLine("                   .l `.   /                     ");
            //Console.WriteLine("                    ::    /                      ");
            //Console.WriteLine("                    :|  ,'                       ");
            //Console.WriteLine("                    :;,'                         ");
            //Console.WriteLine("                    `'                           ");
            Thread.Sleep(3000);
        }
    }
}
