using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
 public int stars;
 public bool moonRock, Diamonds, snow, water,firstnote;
public string[] notes;
 public GameData()
 {
    this.stars = 0;
    this.moonRock = false;
    this.Diamonds = false;
    this.snow = false;
    this.water = false;
    this.notes = new string[100];
    this.firstnote = false;

 }


    
}
