﻿using ConsoleTools;
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
                Console.Write("Enter Game Name: ");
                string name = Console.ReadLine();
                rest.Post(new Game() { GameName = name }, "game");
            }
            if (entity == "Player")
            {
                Console.Write("Enter Player Name: ");
                string name = Console.ReadLine();
                rest.Post(new Player() { IngameName = name }, "player");
            }
            if (entity == "Team")
            {
                Console.Write("Enter Team Name: ");
                string name = Console.ReadLine();
                rest.Post(new Team() { TeamName = name }, "team");
            }
        }
        static void List(string entity)
        {
            if (entity == "Game")
            {
                List<Game> games = rest.Get<Game>("game");
                foreach (var item in games)
                {
                    Console.WriteLine(item.Id + ": " + item.GameName);
                }
            }
            if (entity == "Player")
            {
                List<Player> players = rest.Get<Player>("player");
                foreach (var item in players)
                {
                    Console.WriteLine(item.Id+":"+item.IngameName);
                }
            }
            if (entity == "Team")
            {
                List<Team> teams = rest.Get<Team>("team");
                foreach (var item in teams)
                {
                    Console.WriteLine(item.Id + ":" + item.TeamName);
                }
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter Games's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Game one = rest.Get<Game>(id, "game");
                Console.Write($"New name [old: {one.GameName}]: ");
                string name = Console.ReadLine();
                one.GameName = name;
                rest.Put(one, "game");
            }
            if (entity == "Player")
            {
                Console.Write("Enter Player's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Player one = rest.Get<Player>(id, "player");
                Console.Write($"New name [old: {one.IngameName}]: ");
                string name = Console.ReadLine();
                one.IngameName = name;
                rest.Put(one, "player");
            }
            if (entity == "Team")
            {
                Console.Write("Enter Team's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Team one = rest.Get<Team>(id, "team");
                Console.Write($"New name [old: {one.TeamName}]: ");
                string name = Console.ReadLine();
                one.TeamName = name;
                rest.Put(one, "team");
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
            if (entity == "Player")
            {
                Console.Write("Enter Player's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "player");
            }
            if (entity == "Team")
            {
                Console.Write("Enter Team's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "team");
            }
           
        }
        static void NonCrudOut(string entity)
        {
            if (entity=="Most")
            {
                string view = rest.GetSingle<string>("gamestat/mostplayersinagame");
                Console.WriteLine(view);
                
            }
            if (entity == "ChineseExp")
            {
                List<string> chineseExpList = rest.Get<string>("GameStat/ChinesePlayersWithExp").ToList();

                foreach (var exp in chineseExpList)
                {
                    Console.WriteLine(exp);
                }
            }
            if (entity == "ChineseTeams")
            {
                string view = rest.GetSingle<string>("GameStat/GameWithMostChineseTeams");
                Console.WriteLine(view);

            }
            if (entity == "LeagueChamps")
            {
                string view = rest.GetSingle<string>("GameStat/GameWithMostLeagueChampions");
                Console.WriteLine(view);

            }
            if (entity == "LolPlayers")
            {
                string view = rest.GetSingle<string>("/TeamStat/TeamWithMostLoLPlayers");
                Console.WriteLine(view);

            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:22837/", "game");
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
            var noncrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("MostPlayersInAGame", () => NonCrudOut("Most"))
                .Add("ChinesePlayersWithExp", () => NonCrudOut("ChineseExp"))
                .Add("GameWithMostChineseTeams", () => NonCrudOut("ChineseTeams"))
                .Add("GameWithMostLeagueChampions", () => NonCrudOut("LeagueChamps"))
                .Add("TeamWithMostLolPlayers", () => NonCrudOut("LolPlayers"))
                .Add("Exit", ConsoleMenu.Close);
            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Games", () => gameSubMenu.Show())
                .Add("Players", () => playerSubMenu.Show())
                .Add("Teams", () => teamSubMenu.Show())
                .Add("NonCruds", () => noncrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
