﻿using System;
using System.Linq;
using YBTE8G_HFT_2023241.Logic;

namespace YBTE8G_HFT_2023241
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EsportSystemDbContext dbseed = new EsportSystemDbContext();
            dbseed.Players.ToArray();
            dbseed.Games.ToArray();
            dbseed.Teams.ToArray();
            ;
            Console.WriteLine("Hello World!");
        }
    }
}
