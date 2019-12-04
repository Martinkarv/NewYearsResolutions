using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace NewYearsResolutions
{
    class Program
    {
        static void Main(string[] args)
        {

            /* kodutöö - New Years Resolutions(OOP approach)
            1.Create an empty .txt file
            2.Ask the user to add a New Years Resolution(at first, the user might add it in one line separated by a comma)
            3.Write resolutions to the file
            5.Create a new Class Resolution.The class has got only one property public string Description
            4. Read the resolutions from the file and use the data that has been read from the file to create the instances(objects) of the Resolution class.
            5. Add the objects to the list of New Years Resolutions.
            6. Display the items from the list of New Years Resolutions.
            7. Let the user add a new resolution.Display the result.Write it to the file.
            8. Let the user delete a resolution from the list.Display the result.Write it to the file. */


            string userAnswer;
            Console.WriteLine("Add your New Year's resolutions and separate them with commas.");
            userAnswer = Console.ReadLine();

            string[] Resolution = userAnswer.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> resolutionsList = Resolution.ToList();



            Start:
            string filePath = @"C:\demo\resolutions.txt";
            File.WriteAllLines(filePath, resolutionsList);
            List<Resolution> descriptionList = new List<Resolution>();
                
           
            foreach (string line in resolutionsList)
            {
                Resolution newResolution = new Resolution(line);
                descriptionList.Add(newResolution);
                File.WriteAllLines(filePath, resolutionsList);
                
            }
           
            foreach (Resolution resolution in descriptionList)
            {
                Console.WriteLine($"Resolution in your resolutions list is to {resolution.description}.");
                
            }
            

            
            
                Console.WriteLine($"Do you want to ADD or REMOVE something or just QUIT?");
            string userChoice = Console.ReadLine();
          
                if (userChoice.ToUpper() == "ADD")
                {
                    Console.WriteLine("Write a resolution you want to add");
                    string newResolution = Console.ReadLine();
                    resolutionsList.Add(newResolution);

                Console.Clear();
                goto Start;



                }

                else if (userChoice.ToUpper() == "REMOVE")
                {
                    Console.WriteLine("Write a resolution you want to remove");
                    string newResolution = Console.ReadLine();
                    resolutionsList.Remove(newResolution);

                Console.Clear();

                goto Start;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Closing the program.");

                int m = 1;

                foreach (Resolution resolution in descriptionList)
                {
                    Console.WriteLine($"Resolution {m} in your resolutions list is to {resolution.description}.");
                    m++;
                }

            }

            Console.ReadLine();

        }
    }
}
