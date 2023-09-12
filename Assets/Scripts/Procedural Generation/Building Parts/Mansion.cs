using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mansion
{
    Rooms[] rooms;
    Hallways[] hallways;

    public Rooms[] Rooms { get { return rooms; } }
    public Hallways[] Hallways { get { return hallways; } }

    public Mansion(Rooms[] rooms , Hallways[] hallways)
    {
        this.rooms = rooms;
        this.hallways = hallways;
    }

    public override string ToString()
    {
        string mnsn = "Mansion:(" + rooms.Length + ")\n";
        foreach (Rooms r in rooms)
        {
            mnsn += r.ToString() + "\n";
        }
        foreach (Hallways h in hallways)
        {
            mnsn += "\t" + h.ToString() + "\n";
        }
        return mnsn;
    }
}
