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
                //TO DO rajouter les trésors au users;
                fileManager.map.mapSimulationPath();
                fileManager.createOutputFile();
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
