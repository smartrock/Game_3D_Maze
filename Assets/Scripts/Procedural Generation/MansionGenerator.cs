using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public static class MansionGenerator
{
    public static Mansion Generate()
    {
        return new Mansion(
            new Rooms[]
            {
                new Rooms(
                    new RectInt(0,0,5,5),
                    new Point[]
                    {
                        new Point(0,0)
                    },
                    new Theme(ThemeType.Study),
                    new Clue[]
                    {
                        new Clue(ClueType.Corpse)
                    },
                    new Weapons[]
                    {
                        new Weapons(WeaponType.Rope)
                    })
            },
            new Hallways[]
            {
                new Hallways(
                    )
            }
            );
    }
}
