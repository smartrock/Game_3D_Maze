using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons
{
    WeaponType type;

    public WeaponType Type { get => type; }

    public Weapons(WeaponType type)
    {
        this.type = type;
    }

    public override string ToString()
    {
        return "Weapon: " + type.ToString();
    }
}

public enum WeaponType
{
    Pipe, 
    Dagger, 
    Revolver, 
    Rope, 
    Wrench, 
    Candlestick
}

