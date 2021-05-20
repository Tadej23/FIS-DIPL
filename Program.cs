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
            string[] csvLinesPublications = System.IO.File.ReadAllLines("D:/CSV/publications.csv");


            /*
            // Test prebiranja datoteke z izpisov v konzolo
            for (int i = 0; i < csvLinesAuthPub.Length; i++)
            {
                Console.WriteLine(csvLinesAuthPub[i]);
            }
            */

            var authors = new List<Author>();
            var publications = new List<Publication>();

            // Read csv, skip first line
            for (int i = 1; i < csvLinesAuth.Length; i++)
            {
                Author aut = new Author(csvLinesAuth[i]);
                authors.Add(aut);
            }

            for (int i = 1; i < csvLinesPublications.Length; i++)
            {
                Publication pub = new Publication(csvLinesPublications[i]);
                publications.Add(pub);
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
 
            // add publications to authors
            for (int i = 0; i < authors.Count; i++)
            {
                for (int j = 1; j < csvLinesAuthPub.Length; j++)
                {
                    if (authors[i].CobissID == authorsList[j]) { authors[i].sezPub.Add(pubs[j]); }
                }

            }

            // add publications to authors
            for (int i = 0; i < publications.Count; i++)
            {
                for (int j = 1; j < csvLinesAuthPub.Length; j++)
                {
                    if (publications[i].CobissID == pubs[j]) { publications[i].sezAuth.Add(pubs[j]); }
                }

            }




            // Izpis avtorjev
            for (int i = 0; i < 5; i++)
            {
                //Console.WriteLine(authors[i].CobissID  +  " " + authors[i].SicrisID + " " + authors[i].sezPub[0]);
                Console.WriteLine(JsonConvert.SerializeObject(authors[i], Formatting.Indented));
                
            }


            // Izpis publikacij
            for (int i = 0; i < 50; i++)
            {

                Console.WriteLine(JsonConvert.SerializeObject(publications[i], Formatting.Indented));

            }



            Console.WriteLine("Število avtorjev je : " + authors.Count + ".");

            Console.ReadKey();
        }
    }
}
