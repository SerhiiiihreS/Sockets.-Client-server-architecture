using System;
using System.IO;
using System.Text;
using System.Linq;

namespace MyApp
{
    class ServerApp
    {
        private static bool isServerOn = false;
        private static Random random = new Random();
        private const string SafeFileNameChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";

        static void Main()
        {
            while (true)
            {
                DisplayMenu();
                string input = Console.ReadLine();
                Console.WriteLine($"* > {input}");

                if (isServerOn)
                {
                    ProcessServerOnInput(input);
                }
                else
                {
                    ProcessServerOffInput(input);
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine(isServerOn ? "* > Server ON" : "* > Server OFF");
            if (isServerOn)
            {
                Console.WriteLine("* > 2 - Stop");
                Console.WriteLine("* > 'RND-FILE' [length]");
                Console.WriteLine("* > 'RND-UINT' [max_value]");
            }
            else
            {
                Console.WriteLine("* > 1 - Start");
            }
            Console.WriteLine("* > 0 - Exit");
            Console.Write("* > ");
        }

        static void ProcessServerOffInput(string input)
        {
            switch (input)
            {
                case "1":
                    isServerOn = true;
                    Console.WriteLine("Server Started");
                    break;
                case "0":
                    Console.WriteLine("Server Stopped. Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown command. Use 1 or 0.");
                    break;
            }
        }

        static void ProcessServerOnInput(string input)
        {
            string[] parts = input.Split(' ');
            string command = parts[0].ToUpper();
            string payload = parts.Length > 1 ? parts[1] : null;

            switch (command)
            {
                case "2":
                    isServerOn = false;
                    Console.WriteLine("Server Stopped");
                    break;
                case "0":
                    Console.WriteLine("Server Stopped. Exiting...");
                    Environment.Exit(0);
                    break;
                case "RND-FILE":
                    if (payload != null && int.TryParse(payload, out int fileLength))
                    {
                        string randomFileName = GenerateRandomFileName(fileLength);
                        Console.WriteLine($"Generated RND-FILE: {randomFileName}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid payload for RND-FILE. Usage: RND-FILE [length]");
                    }
                    break;
                case "RND-UINT":
                    if (payload != null && uint.TryParse(payload, out uint maxValue))
                    {
                        if (maxValue <= int.MaxValue)
                        {
                            int randomUint = random.Next(0, (int)maxValue + 1); 
                            Console.WriteLine($"Generated RND-UINT (0-{maxValue}): {randomUint}");
                        }
                        else
                        {
                            Console.WriteLine("Payload for RND-UINT is too large for current implementation (max int allowed).");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid payload for RND-UINT. Usage: RND-UINT [max_value]");
                    }
                    break;
                default:
                    Console.WriteLine("Unknown command. Use 2, 0, RND-FILE, or RND-UINT.");
                    break;
            }
        }

        static string GenerateRandomFileName(int length)
        {
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(SafeFileNameChars[random.Next(SafeFileNameChars.Length)]);
            }
            return result.ToString();
        }
    }
}

