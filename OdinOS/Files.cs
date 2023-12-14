using System;
using System.IO;

namespace OdinOS
{
    internal class Files
    {
        // Prepare Time and Date for File Info & Arrangement
        private static DateTime currentTime = DateTime.Now;
        private static DateTime currentDate = DateTime.Now;

        // Display the contents of the files in the directory
        public static void fileContents()
        {
            string[] filePaths = Directory.GetFiles(@"0:\");
            var drive = new DriveInfo("0");
            Console.WriteLine(" Directory of " + @"0:\");
            // Display the list of file system contents
            listallfiles();
        }

        // Add a new .txt file to directory with inputs from the user
        public static void addtextfile()
        {
            Console.WriteLine(" Note: Please do not include .txt when typing in the file name.");
            Console.WriteLine("  Type '!FINISHED!' when finished typing in the text file.");
            Console.WriteLine("  Type '!CANCEL!' to cancel and return to view/add/delete.");

            Console.Write(" File Name: ");
            var temp_name = Console.ReadLine();

            //Filename validation
            char[] invalidChars = { '\\', '/', ':', '*', '?', '"', '<', '>', '|', '.' };

            foreach (char invalidChar in invalidChars)
            {
                if (temp_name.Contains(invalidChar) || temp_name == "" || temp_name == null)
                {
                    Console.WriteLine(" Invalid file name.");
                    Console.WriteLine(" Avoid using these characters because they can cause errors or bugs:");
                    Console.WriteLine(" (\\ / : * ? \" < > | .)");
                    return;
                }
            }
            // If there is no invalid characters detected, the file name is considered valid and gets the pass
            var name = temp_name;

            //Returns to view/add/delete when user types in '!CANCEL!'
            if (name == "!CANCEL!")
            {
                return;
            }

            Console.WriteLine(" File Contents:");

            bool anotherLine = true;

            int maxLines = 12;
            string[] linesContents = new string[maxLines];
            int i = 0;

            // Allow the user to input multiple lines until they type the word/combination '!FINISHED!'
            while (anotherLine)
            {
                int line_ref = i + 1;
                Console.Write(" - Line " + line_ref + ": ");

                string temp = Console.ReadLine();

                //Used a temporary variable to store the line's input
                //Tempo will go thru input filters before added to array of contents

                if (temp == "!FINISHED!")
                {
                    anotherLine = false;
                }

                // Show warning since maximum no. of line is reached
                if (i == maxLines - 2)
                {
                    Console.WriteLine(" BEWARE! Maximum no. of line is reached. Type '!FINISHED!' or else it won't save and will return to menu.");
                }

                // Not save and return to menu when user attempts to cross maximum no. of line
                if ((i == maxLines - 1 && temp != "!FINISHED!") || temp == "!CANCEL!")
                {
                    
                    return;
                }
                linesContents[i] = temp;
                i++;
            }

            string filePath = $"0:\\{name}.txt";

            // Verify if the file already exists in the directory

            if (File.Exists(filePath))
            {
                Console.WriteLine($" Text file '{name}.txt' already exists at '0:\\'.");
            }
            else
            {
                // Write the contents to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {

                    writer.WriteLine(" Date & Time Created: " + currentDate.ToString("MM-dd-yyyy") + " @" + currentTime.ToString("HH:mm:ss"));
                    writer.WriteLine("");

                    for (int j = 0; j < i - 1; j++)
                    {
                        writer.WriteLine(linesContents[j]);
                    }
                }

                Console.WriteLine($" Text file '{name}.txt' is created successfully at '0:\\'.");
            }
        }

        // Delete a .txt file from the directory
        public static void deletetextfile()
        {
            string[] filePaths = Directory.GetFiles(@"0:\");

            Console.WriteLine(" Note: Please do not include .txt when typing in the file name.");
            Console.WriteLine("      Type '!CANCEL!' to cancel and return to view/add/delete.");

            listallfiles();

            Console.Write(" Name of the text file to be deleted: ");
            var name = Console.ReadLine();

            if (name == "!CANCEL!")
            {
                return;
            }

            string filePath = $"0:\\{name}.txt";

            // Check if the file exists in the list
            if (File.Exists(filePath))
            {
                // Delete the file
                File.Delete(filePath);
                Console.WriteLine($" Text file '{name}.txt' is deleted successfully.");
            }
            else
            {
                Console.WriteLine($" Huh. File '{name}.txt' is not found.");
                return;
            }
        }

        // View the contents of a .txt file from 0:\
        public static void viewtextfile()
        {
            string[] filePaths = Directory.GetFiles(@"0:\");

            Console.WriteLine(" Please refer to file list provided below.");
            Console.WriteLine("      Type '!CANCEL!' to return to view/add/delete");
            Console.WriteLine("      Note: Please do not include .txt in file name");

            listallfiles();
            Console.Write(" Name of file to display: ");
            var name = Console.ReadLine();

            if (name == "!CANCEL!")
            {
                return;
            }

            string filePath = $"0:\\{name}.txt";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read and display the contents of the file
                Console.Clear();
                Console.WriteLine(" View the contents of a .txt file");

                string[] lines = File.ReadAllLines(filePath);
                Console.WriteLine($" Contents of '{name}.txt':\n");

                foreach (string line in lines)
                {
                    Console.WriteLine("  " + line);
                }

            }
            else
            {
                Console.WriteLine($" File '{name}.txt' not found.");
                return;
            }
        }

        public static void listallfiles()
        {
            string[] filePaths = Directory.GetFiles(@"0:\");

            Console.WriteLine(" List of Text Files in the System: ");
            for (int i = 0; i < filePaths.Length; ++i)
            {
                string path = filePaths[i];

                if (System.IO.Path.GetFileName(path) != "set_config.txt")
                {
                    Console.WriteLine("  - " + System.IO.Path.GetFileName(path));
                }
            }
        }
    }
}