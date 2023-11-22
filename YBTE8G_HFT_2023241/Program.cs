using System;
using System.Linq;
using YBTE8G_HFT_2023241.Client;

namespace YBTE8G_HFT_2023241
{
    internal class Program
    {
        static RestService rest;
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:22837/", "esport");
            Console.WriteLine("Hello World!");
        }
    }
}
