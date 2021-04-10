using Businness.Concrete;
using Core.DataAccess.EntityFramework;
using Core.Utilities;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Today;
            DateTime arg = new DateTime(2021, 4, 09);
            int result = DateTime.Compare(arg, today);
            Console.WriteLine(result+" "+ today+" "+arg);
        }

        
    }
}
