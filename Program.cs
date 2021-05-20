using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace Cobiss
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] csvLinesAuth = System.IO.File.ReadAllLines("D:/CSV/authors.csv");
            string[] csvLinesAuthPub = System.IO.File.ReadAllLines("D:/CSV/authorsPub.csv");


            /*
            // Test prebiranja datoteke z izpisov v konzolo
            for (int i = 0; i < csvLinesAuthPub.Length; i++)
            {
                Console.WriteLine(csvLinesAuthPub[i]);
            }
            */
            

            
            var authors = new List<Author>();

            // Read csv, skip first line
            for (int i = 1; i < csvLinesAuth.Length; i++)
            {
                Author aut = new Author(csvLinesAuth[i]);
                authors.Add(aut);
            }

            // initialize new List of strings

           

            string[] pubs = new string[csvLinesAuthPub.Length];
            string[] authorsList = new string[csvLinesAuthPub.Length];



            // Csv to pubs array and author array
            for (int i = 1; i < csvLinesAuthPub.Length; i++)
            {
                string[] lines = csvLinesAuthPub[i].Split(';');
               
                
                pubs[i] = lines[0];
                authorsList[i] = lines[1];
             }
 
            for (int i = 0; i < authors.Count; i++)
            {
                for (int j = 1; j < csvLinesAuthPub.Length; j++)
                {
                    if (authors[i].CobissID == authorsList[j]) { authors[i].sezPub.Add(pubs[j]); }
                }

            }


            // Izpis avtorjev
            for (int i = 0; i < authors.Count; i++)
            {
                //Console.WriteLine(authors[i].CobissID  +  " " + authors[i].SicrisID + " " + authors[i].sezPub[0]);
                Console.WriteLine(JsonConvert.SerializeObject(authors[i], Formatting.Indented));
                

            }

            
            
            Console.WriteLine("Število avtorjev je : " + authors.Count + ".");

            Console.ReadKey();
        }
    }
}
