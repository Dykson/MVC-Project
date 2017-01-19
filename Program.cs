using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCProject.Controller;

namespace MVCProject
{
    class Program
    {
        static void Main(string[] args)
        {
            AppController appController = AppController.Instantiate();
            appController.Loop();
        }
    }
}
