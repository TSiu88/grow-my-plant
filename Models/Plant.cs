using System;
using System.Collections.Generic;

namespace Grow.Models
{
  public class Plant
  {
    public int FeedTurnNumber {get; set;}
    public int WaterLevel {get; set;}
    public int SunLevel {get; set;}
    public int PlantHealth {get; set;}
    public bool FeedAvailable {get; set;}

    public Plant()
    {
      FeedTurnNumber = 0;
      WaterLevel = 3;
      SunLevel = 3;
      PlantHealth = 2;
      FeedAvailable = false;
    }

    public void Water()
    {
      WaterLevel += 2;
    }

    public void Feed()
    {
      Random random = new Random();
      int element = random.Next(2);
      int increaseLevel = random.Next(1, 4);
      if (element == 0)
      {
        WaterLevel += increaseLevel;
        SunLevel++;
      } 
      else 
      {
        WaterLevel++;
        SunLevel += increaseLevel;
      }
      FeedAvailable = false;
      FeedTurnNumber = 0;
    }

    public void GiveSunshine()
    {
      SunLevel += 2;
    }

    public void CheckFeed()
    {
      if (FeedTurnNumber >= 3) 
      {
        FeedAvailable = true;
      } 
      else 
      {
        FeedAvailable = false;
      }
    }

    public void EndTurn()
    {
      WaterLevel--;
      SunLevel--;
      if (WaterLevel <= 0 || WaterLevel >= 5 || SunLevel <= 0 || SunLevel >= 5)
      {
        PlantHealth--;
      }
      else
      {
        PlantHealth = 2;
      }
      FeedTurnNumber++;
    }
  }
}