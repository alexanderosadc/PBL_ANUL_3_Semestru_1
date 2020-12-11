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

        public string Get3DmodelBytes() {

            byte[] byteStr = System.IO.File.ReadAllBytes(@"3DModel\office_1");

            string text = BitConverter.ToString(byteStr);

            return text;
        }
    }
}
