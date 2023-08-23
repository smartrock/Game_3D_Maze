using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue 
{
    ClueType type;

    public ClueType Type { get => type; }

    public Clue(ClueType type)
    {
        this.type = type;
    }

    public override string ToString()
    {
        return "Clue: " + type.ToString();
    }
}

public enum ClueType
{
    Blood,
    Corpse, 
    Footprints,
    Scrapemarks, 
    Documents
}
