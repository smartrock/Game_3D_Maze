using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Theme
{
    ThemeType type;

    public ThemeType Type { get => type; }

    public Theme(ThemeType type)
    {
        this.type = type;
    }

    public override string ToString()
    {
        return "Theme: " + type.ToString();
    }
}
public enum ThemeType
{
    Ballroom,
    Bathroom,
    Bedroom,
    Cellar,
    Conservatory,
    Dining,
    Games,
    Garage,
    Kitchen,
    Library,
    Lounge,
    Studio,
    Study
}
