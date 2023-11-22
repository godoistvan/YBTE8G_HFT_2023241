using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using YBTE8G_HFT_2023241.Client;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter Actor Name: ");
                string name = Console.ReadLine();
                rest.Post(new Game() { GameName = name }, "game");
            }
        }
        static void List(string entity)
        {
            if (entity == "Actor")
            {
                List<Game> actors = rest.Get<Game>("game");
                foreach (var item in actors)
                {
                    Console.WriteLine(item.Id + ": " + item.GameName);
                }
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter Actor's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Game one = rest.Get<Game>(id, "game");
                Console.Write($"New name [old: {one.GameName}]: ");
                string name = Console.ReadLine();
                one.GameName = name;
                rest.Put(one, "game");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter Game's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "game");
            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:22837/", "esport");
            var gameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Game"))
                .Add("Create", () => Create("Game"))
                .Add("Delete", () => Delete("Game"))
                .Add("Update", () => Update("Game"))
                .Add("Exit", ConsoleMenu.Close);

            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Exit", ConsoleMenu.Close);

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Movies", () => gameSubMenu.Show())
                .Add("Actors", () => playerSubMenu.Show())
                .Add("Roles", () => teamSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            Console.WriteLine("Hello World!");
        }
    }
}
