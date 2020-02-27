using System;
using System.Collections.Generic;
using Grow.Models;

namespace Grow
{
  class Program
  {
    public static Plant plant = new Plant();
    public static bool gameOver = false;

    public static void Main()
    {
      Console.WriteLine("===== Grow Your Plant =====");
      Console.WriteLine("Keep your plant alive by");
      Console.WriteLine("not letting the levels go");
      Console.WriteLine("too high or low.");
      while (!gameOver)
      {
        plant.CheckFeed();
        DisplayStats();
        MainMenu();
        plant.EndTurn();
        CheckGameOver();
      }
    }

    public static void DisplayStats()
    {
      Console.WriteLine("===========================");
      Console.WriteLine("==== Your Plant Stats =====");
      Console.WriteLine($"Water Level: {plant.WaterLevel}/5");
      Console.WriteLine($"Sun Level: {plant.SunLevel}/5");
      Console.WriteLine($"Feed Available: {plant.FeedAvailable}");
      Console.WriteLine("===========================");
    }

    public static void MainMenu()
    {
      Console.WriteLine("Choose an action: (Water/Sun/Feed/Nothing/Quit)");
      string input = Console.ReadLine().ToLower();
      if (input == "water")
      {
        plant.Water();
      } 
      else if (input == "sun")
      {
        plant.GiveSunshine();
      } 
      else if (input == "feed")
      {
        if (plant.FeedAvailable)
        {
          plant.Feed();
        }
        else
        {
          Console.WriteLine("Feed not available yet! Try again later.");
          MainMenu();
        }
      } 
      else if (input == "nothing")
      {
        Console.WriteLine("Nothing done this turn.");
      }
      else if (input == "quit")
      {
        Environment.Exit(0);
      } 
      else 
      {
        Console.WriteLine("Command not found. Please Try Again.");
        MainMenu();
      }
    }

    public static void CheckGameOver()
    {
      if (plant.PlantHealth == 1)
      {
        Console.WriteLine("Plant is dying! Watch your stats!");
        gameOver = false;
      } 
      else if (plant.PlantHealth == 0)
      {
        Console.WriteLine("Plant has died! Game Over!");
        gameOver = true;
      }
      else
      {
        gameOver = false;
      }
    }
  }
}
