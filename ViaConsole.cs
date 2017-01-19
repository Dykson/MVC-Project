using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCProject.Controller;

namespace MVCProject.View
{
    static class ViaConsole
    {
        public static string ReadCommand()
        {
            return Console.ReadLine();
        }

        public static void WriteResponse(string response, bool enableLine)
        {
            if (enableLine)
            {
                Console.Write(response);
            }
            else Console.WriteLine(response);
        }
        
    }
}
