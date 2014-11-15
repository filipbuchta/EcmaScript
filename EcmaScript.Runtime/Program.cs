using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript
{
 



    public static class Program
    {
        public static void Main()
        {

            File.OpenRead(@"C:\Home\Projects\JavaScript\JavaScript.Engine\test.js");
          
            VirtualMachine vm = new VirtualMachine();
            //vm.Run(result);

            //Console.ReadLine();
        }
    }
}
