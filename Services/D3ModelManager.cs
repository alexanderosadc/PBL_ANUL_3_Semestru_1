using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBLSecurity
{
    public class D3ModelManager
    {

        public byte[] Get3DmodelBytes() {

            string text = System.IO.File.ReadAllText(@"C:\Users\MVOLOSEN\Projects\Fun\SecurityPBL\3DModel\office_1");

            byte[] bytes = Encoding.ASCII.GetBytes(text);

            return bytes;
        }
    }
}
