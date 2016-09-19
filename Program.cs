using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolibri;

namespace Quick_Access_Junction_Tool
{
    class jForm
    {
        /// <summary>
        /// This is the tools main sequence.
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            // The title of the console window.
            Console.Title = "Quick Access Junction Tool";
            // The destination where I keep all junction points relative to Quick Access stored.
            string qAccess = "E:\\Desktop\\Quick Access Shortcuts\\";
            string jLink;
            string dLink;
            string errorMessage = "Seems like an error occurred... Sorry about that.";

            // The prompt that requests what you'd like to name the junction point.
            Console.WriteLine("Please enter the desired name of your Junction Point.");
            Spacer();
            jLink = qAccess + Console.ReadLine();
            Spacer();

            // The prompt that requests the path to the folder that the junction will point towards.
            Console.WriteLine("Please enter the path of the folder that the Junction will point towards.");
            Spacer();
            dLink = Console.ReadLine();
            Spacer();

            try
            {
                Console.WriteLine("Here's the command to create your junction point. This has also been copied to your clipboard.");
                Spacer();
                Console.WriteLine(Final(jLink, dLink));
                Spacer();

                // Copies the final outcome to the clipboard to allow for easy entry in the command prompt.
                Clippy.PushUnicodeStringToClipboard(Final(jLink, dLink));
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                Console.WriteLine(errorMessage);
                Spacer();
            }

            Toggle();
                
        }

        /// <summary>
        /// Simple one-line spacer for entry points. This can also be used to enhance readability.
        /// If there's a better way to do this, please, by all means, let me know!
        /// </summary>
        static void Spacer()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Joins the junction link and the destination into one string that can be displayed, as well as copied to the clipboard.
        /// </summary>
        /// <param name="jLink"></param>
        /// <param name="dLink"></param>
        /// <returns></returns>
        static string Final(string jLink, string dLink)
        {
            string outcome = $"mklink /J \"{jLink}\" \"{dLink}\"";
            return outcome;
        }

        /// <summary>
        /// The method that determines whether the program should be terminated, or whether it should continue.
        /// </summary>
        /// <param name="closeSolution"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        static void Toggle()
        {
            Console.WriteLine("To create another junction point, type \"true\".");
            Console.WriteLine("To exit this program, type \"false\".");
            Spacer();
            /* 
                        Depending on user input, the program will preform one of three actions. 
                        1.) true = Start the junction creation process over again.
                        2.) false = End the program.
                        3.) default = Asks the user to retype their previous entry as it didn't fit the proper criteria.
            */
            string input = (Console.ReadLine());
            Spacer();
            switch (input.ToLower())
            {
                case "true":
                {
                    Main();
                    break;
                }
                case "false":
                {
                    Ending();
                    break;
                }
                default:
                {
                    ColoredGuidance();
                    Spacer();
                    Toggle();
                    break;
                }
            }
        }

        #region ColoredIntro() Storage
        /// <summary>
        /// A simple string that was turned into a garbled mess once I added colors into the fray. To help readability, I simply moved it into a method.
        /// </summary>
        static void ColoredIntro()
        {
            Console.Write("To create another junction point, type \"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("true");
            Console.ResetColor();
            Console.WriteLine("\".");

            Console.Write("To exit this program, type \"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("false");
            Console.ResetColor();
            Console.WriteLine("\".");

            Spacer();
        }
        #endregion

        /// <summary>
        /// A simple string that was turned into a garbled mess once I added colors into the fray. To help readability, I simply moved it into a method.
        /// </summary>
        static void ColoredGuidance()
        {
            Console.Write("The input must either be \"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("true");
            Console.ResetColor();
            Console.Write("\" or \"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("false");
            Console.ResetColor();
            Console.Write("\".");

            Spacer();
        }

        /// <summary>
        /// Closing Sequence.
        /// </summary>
        static void Ending()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
