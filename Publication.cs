using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobiss
{
    public class Publication
    {
        public string CobissID, year, type;
        

        public  List<string> sezAuth = new List<string>();

        public Publication(string rowData)
        {
            string[] data = rowData.Split(';');

            this.CobissID = data[0];
            this.year = data[1];
            this.type = data[3];

        }

    }
}
