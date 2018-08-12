using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarteAuTresor
{
    class FileManager
    {
        private string pathToFile;
        private string pathToOutFile;

        public FileManager(string pathToFile)
        {
            //Check if the path send in param exist realy
            if (File.Exists(pathToFile)) {
                this.pathToFile = pathToFile;
            } else {
                throw new Exception("file doesn't exist");
            }
           
        }


        public void readFileMap()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(this.pathToFile);
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                counter++;
            }
            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
        }


    }
}
