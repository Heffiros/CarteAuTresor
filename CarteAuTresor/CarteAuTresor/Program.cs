using System;
using System.IO;

namespace CarteAuTresor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) {
                Console.WriteLine("You need to set a pathfile");
            } else {
                FileManager fileManager = new FileManager(args[0]);
                fileManager.readFileMap();
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
