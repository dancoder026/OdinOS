using System;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.Core;

namespace OdinOS
{
    public class Kernel : Sys.Kernel
    {
        //For there to only have one menu/viewadddelete/bonusfeature shown & for network
        public static Boolean checkMenu = false;
        public static Boolean checkViewAddDelete = false;
        public static Boolean useNetwork = false;
        public static Boolean checkBonusFeatures = false;
        //Kernel version as of 12-13-2023
        public static string kernelVersion = "v1.0";
        //
        private Sys.FileSystem.CosmosVFS filesystem;

        protected override void BeforeRun()
        {
            filesystem = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(filesystem);

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
  
            Console.WriteLine("|---------------------------------------------------------|");
            Console.WriteLine("|  ..|''||        '||   ||            ..|''||    .|'''.|  |");
            Console.WriteLine("| .|'    ||     .. ||  ...  .. ...   .|'    ||   ||..  '  |");
            Console.WriteLine("| ||      ||  .'  '||   ||   ||  ||  ||      ||   ''|||.  |");
            Console.WriteLine("| '|.     ||  |.   ||   ||   ||  ||  '|.     || .     '|| |");
            Console.WriteLine("|  ''|...|'   '|..'||. .||. .||. ||.  ''|...|'  |'....|'  |");
            Console.WriteLine("|---------------------------------------------------------|");
            Console.ResetColor();

            Console.WriteLine("Created by Group 1 - Atencia, Espejo, Jao, Maza, Salazar & Santos");
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
            Console.Write("");
            Console.Clear();
        }

        protected override void Run()
        {
            setupfileSys();
            backtomenu();
        }

        public static void setupfileSys()
        {
            //These are for setting up the files system
            string[] filePaths = Directory.GetFiles(@"0:\");
        }

        public static void view_add_delete_files()
        {
            //For viewing, adding and deleting text files

            if (checkViewAddDelete == false)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("|------------------------------------------------------------|");
                Console.WriteLine("|                     View/Add/Delete                        |");
                Console.WriteLine("|------------------------------------------------------------|");
                Console.WriteLine("| Type 1 (+ Enter) to view text file list                    |");
                Console.WriteLine("| Type 2 (+ Enter) to add text file                          |");
                Console.WriteLine("| Type 3 (+ Enter) to delete text file                       |");
                Console.WriteLine("| Type 4 (+ Enter) to view contents of a text file           |");
                Console.WriteLine("| Type 5 (+ Enter) to go back to main menu                   |");
                Console.WriteLine("|------------------------------------------------------------|");
                Console.ResetColor();
                checkViewAddDelete = true;
            }
            else
            {
                Console.Write("");
            }
            
            Console.Write(" View/add/delete: ");
            var actionFiles = Console.ReadLine();
            if (actionFiles == "1")
            {
                Files.fileContents();
                view_add_delete_files();
                return;
            }
            else if (actionFiles == "2")
            {
                Files.addtextfile();
                view_add_delete_files();
                return;
            }
            else if (actionFiles == "3")
            {
                Files.deletetextfile();
                view_add_delete_files();
                return;
            }
            else if (actionFiles == "4")
            {
                Files.viewtextfile();
                view_add_delete_files();
                return;
            }
            else if (actionFiles == "5")
            {
                clear_screen();
                backtomenu();
            }
            else
            {
                Console.WriteLine(" Invalid input for view/add/delete. Please choose from the choices above.");
                return;
            }

        }

        public static void clear_screen()
        {
            //For clearing the screen
            Console.Clear();
            checkMenu = false;
            checkBonusFeatures = false;
            checkViewAddDelete = false;
        }

        public static void backtomenu()
        {
            // This is for going back to menu and ensuring there is only one menu (at the top)
            if (checkMenu == false)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("|------------------------------------------------------------|");
                Console.WriteLine("|                          Main Menu                         |");
                Console.WriteLine("|------------------------------------------------------------|");
                Console.WriteLine("|Type 1 (+ Enter) to shut down                               |");
                Console.WriteLine("|Type 2 (+ Enter) to reboot                                  |");
                Console.WriteLine("|Type 3 (+ Enter) to show kernel version                     |");
                Console.WriteLine("|Type 4 (+ Enter) to show current date and time              |");
                Console.WriteLine("|Type 5 (+ Enter) to show IP address                         |");
                Console.WriteLine("|Type 6 (+ Enter) to display system info                     |");
                Console.WriteLine("|Type 7 (+ Enter) to clear screen and show main menu         |");
                Console.WriteLine("|Type 8 (+ Enter) to view/add/delete text file/s             |");
                Console.WriteLine("|Type 9 (+ Enter) to bonus features                          |");
                Console.WriteLine("|------------------------------------------------------------|");
                Console.ResetColor();
                checkMenu = true;
            }
            else
            {
                Console.Write("");
            }

            Console.Write(" Input: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // Confirmation and Shutdown
                    Console.WriteLine(" Confirm shutdown?");
                    Console.WriteLine(" Y/N? Type Y if Yes and N if No");
                    Console.Write(" Proceed?: ");
                    var confirmShutdown = Console.ReadLine();
                    switch (confirmShutdown)
                    {
                        case "Y":
                        case "y":
                        case "Yes":
                        case "yes":
                        case "YES":
                            Cosmos.System.Power.Shutdown();
                            break;
                        default:
                            Console.WriteLine(" Shutdown cancelled.");
                            backtomenu();
                            break;
                    }
                    break;

                case "2":
                    // Confirmation and Reboot
                    Console.WriteLine(" Confirm reboot?");
                    Console.WriteLine(" Y/N? Type Y if Yes and N if No");
                    Console.Write(" Proceed?: ");
                    var confirmReboot = Console.ReadLine();
                    switch (confirmReboot)
                    {
                        case "Y":
                        case "y":
                        case "Yes":
                        case "yes":
                        case "YES":
                            Cosmos.System.Power.Reboot();
                            break;
                        default:
                            Console.WriteLine(" Reboot cancelled.");
                            backtomenu();
                            break;
                    }
                    break;

                case "3":
                    // Show kernel version - as of 12-13-2023
                    Console.WriteLine(" Kernel version: " + kernelVersion);
                    break;

                case "4":
                    // Show current date and time
                    DateTime date_and_time = DateTime.Now;
                    Console.WriteLine(" Current date and time: " + date_and_time);
                    break;

                case "5":
                    // Show IP Address
                    string networkInfo = Net.GetInfo();
                    Console.WriteLine(networkInfo);
                    break;

                case "6":
                    // Preparing for system info
                    
                    var drive = new DriveInfo("0");
                    string[] filePaths = Directory.GetFiles(@"0:\");
                    string CPUCompany = $" Brand of processor: {CPU.GetCPUVendorName()}";
                    string CPUBrand = $" Processor model: {CPU.GetCPUBrandString()}";

                    // Get information about the CPU and RAM using Cosmos.Core
                    uint totalRAM = CPU.GetAmountOfRAM();
                    uint reservedRAM = totalRAM - (uint)GCImplementation.GetAvailableRAM();
                    double usedRAM = (GCImplementation.GetUsedRAM() / (1024.0 * 1024.0)) + reservedRAM;

                    // Show system information
                    Console.WriteLine(" System Info: ");
                    Console.WriteLine(" RAM: " + usedRAM.ToString("0.00") + "/" + totalRAM.ToString("0.00") + " MB (" + (int)((usedRAM / totalRAM) * 100) + "%)");
                    Console.WriteLine(CPUCompany);
                    Console.WriteLine(CPUBrand);
                    Console.WriteLine($" Total size of drive/disk: {drive.TotalSize / (1024 * 1024)} MB");
                    Console.WriteLine($" Free space of drive/disk: {drive.AvailableFreeSpace / (1024 * 1024)} MB free");
                    break;

                case "7":
                    // Clear screen and go back to main menu
                    clear_screen();
                    backtomenu();
                    break;

                case "8":
                    // Show file system contents
                    view_add_delete_files();
                    backtomenu();
                    break;
                case "9":
                    // Unique feature/s
                    checkBonusFeatures = false;
                    UniqueFeature();
                    break;
                default:
                    Console.WriteLine(" Invalid input in main menu. Please choose from the choices above.");
                    backtomenu();
                    break;
            }
        }

        public static void UniqueFeature()
        {
            if (checkBonusFeatures==false)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("|------------------------------------------------------------|");
                Console.WriteLine("|                      Bonus Features                        |");
                Console.WriteLine("|------------------------------------------------------------|");
                Console.WriteLine("| Type RPS (+ Enter) for rock, paper, scissors               |");
                Console.WriteLine("| Type CF (+ Enter) for coin flip                            |");
                Console.WriteLine("| Type clear (+ Enter) to go clear the screen                |");
                Console.WriteLine("| Type menu (+ Enter) to go back to main menu                |");
                Console.WriteLine("|------------------------------------------------------------|");
                Console.ResetColor();
                checkBonusFeatures = true;
            }
            else 
            {
                Console.Write("");
            }

            Console.Write(" Feature chosen: ");
            string featureChosen = Console.ReadLine();

            switch (featureChosen)
            {
                case "RPS":
                case "Rps":
                case "rps":
                case "rPs":
                case "rpS":
                case "RPs":
                case "RpS":
                case "rPS":
                    UniqueFeatures.rockpaperscissorsvsbot();
                    UniqueFeature();
                    break;
                case "CF":
                case "cf":
                case "Cf":
                case "cF":
                    UniqueFeatures.coinflip();
                    UniqueFeature();
                    break;
                case "clear":
                case "CLEAR":
                case "Clear":
                    clear_screen();
                    UniqueFeature();
                    break;
                case "menu":
                case "MENU":
                case "Menu":
                    clear_screen();
                    backtomenu();
                    break;
                default:
                    Console.WriteLine(" Invalid choice. Please choose from the choices above.");
                    UniqueFeature();
                    break;
            }
        }
    }
}
