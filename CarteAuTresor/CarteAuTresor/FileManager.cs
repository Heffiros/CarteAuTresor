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
        private string listOfcellOption = "CMTA";
        private Map map;

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
                //We check if the first line of the text is the definition of the map
                if (counter == 0 &&  line[0] != 'C') {
                    throw new Exception("First Line has to be the definition of the map and begin by the C");
                }

                //Check if the param in the file is correct and we create the cell on the map
                if (listOfcellOption.Contains(line[0].ToString()))
                {
                    //The first line create the map
                    if (counter == 0)
                    {
                        map = new Map(line);
                    } else
                    {
                        map.generateCell(line);
                    }
                }
                counter++;
            }
            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
        }


    }
}
