using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobiss
{
    public class Author
    {
        public string CobissID, SicrisID;
        

        public  List<string> sezPub = new List<string>();

        public Author(string rowData)
        {
            string[] data = rowData.Split(';');

            
            this.SicrisID = data[0];
            this.CobissID = data[1];
            
        }

    }
}
