using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldData
{
    public bool[] i_worlds;

    public WorldData(WorldManager worlds)
    {
        i_worlds = new bool[worlds.o_worlds.Length];
        i_worlds = worlds.o_worlds;
    }
}
