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
        public Map map;

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
        }

        public bool createOutputFile()
        {
            
            var filename = pathToFile.Split('\\');
            filename[filename.Length - 1] = "result.txt";
            pathToOutFile = string.Join('\\', filename);
            
            if (File.Exists(pathToOutFile))
            {
                File.Delete(pathToOutFile);
            }

            using (StreamWriter sw = File.CreateText(pathToOutFile))
            {
                //Write first line size map
                sw.WriteLine(map.outPutInfo());

                //aff all information
                int rowLength = map.map.GetLength(0);
                int colLength = map.map.GetLength(1);

                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        if (map.map[i, j] != null)
                        {
                            if (map.map[i,j].GetType().Equals("CarteAuTresor.TreasureCell"))
                            {
                                sw.WriteLine(map.map[i, j].affCell() + j + " - " + i);
                            }
                            else
                            {
                                sw.WriteLine("T - " + j + " - " + i + " - " + map.map[i, j].affCell());
                            }
                            
                        }
                        
                    }
                    
                }


                //Write information of all adventurer
                foreach (AdventurerCell adventurer in map.AdventureCell)
                {
                    sw.WriteLine(adventurer.affCell());
                }


            }

            return true;
        }

    }
}
