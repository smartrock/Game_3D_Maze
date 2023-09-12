using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Rooms 
{
    RectInt bounds;
    Point[] doorLocations;
    Theme themes;
    Clue[] clues;
    Weapons[] weapons;

    public RectInt Bounds { get => bounds; }
    public Point[] DoorLocations { get => doorLocations; }
    public Theme Themes { get => themes; }
    public Clue[] Clues { get => clues; }
    public Weapons[] GetWeapons { get => weapons; }

    public Rooms(RectInt bounds, Point[] doorLocation, Theme theme, Clue[] clues, Weapons[] weapon)
    {
        this.bounds = bounds;
        this.doorLocations = doorLocation;
        this.themes = theme;
        this.clues = clues;
        this.weapons = weapon;
    }

    public override string ToString()
    {
        string room = "Rooms:(" + bounds.ToString() + "), ";
        room += themes.ToString() + ", ";
        foreach (Clue c in clues)
        {
            room += c.ToString() + ", ";
        }
        foreach (Weapons w in weapons)
        {
            room += w.ToString() + ", ";
        }
        return room;
    }
}
