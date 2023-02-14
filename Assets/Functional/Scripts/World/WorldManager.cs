using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject[] Worlds;
    [HideInInspector] public bool[] o_worlds;

    private void Start()
    {
        for (int i = 0; i < Worlds.Length; i++)
            o_worlds[i] = Worlds[i].activeInHierarchy;

        WorldData data = SaveSystem.LoadWorld(this);

        if (data != null)
        {
            o_worlds= data.i_worlds;
        }
        else
        {
            for (int i = 0; i < Worlds.Length; i++)
                o_worlds[i] = Worlds[i].activeInHierarchy;

            Debug.Log("Created new world data save file");
        }

        for (int i = 0; i < Worlds.Length; i++)
            Worlds[i].SetActive(o_worlds[i]);
    }

    private void Update()
    {
        for (int i = 0; i < Worlds.Length; i++)
            o_worlds[i] = Worlds[i].activeInHierarchy;
    }
}
