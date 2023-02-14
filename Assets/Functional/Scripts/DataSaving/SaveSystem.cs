using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static void SavePlayer (PlayerControlls player)
    {
        string path = Application.persistentDataPath + "/Save Data/player.bfsf";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        PlayerData data = new PlayerData(player);
        File.WriteAllText(path,JsonUtility.ToJson(data));
    }

    public static PlayerData LoadPlayer(PlayerControlls player)
    {
        string path = Application.persistentDataPath + "/Save Data/player.bfsf";

        if(File.Exists(path))
        {
            PlayerData data = JsonUtility.FromJson<PlayerData>(File.ReadAllText(path));
            return data;
        }
        else
        {
            SavePlayer(player);
            return null;
        }
    }

    public static void SaveWorld(WorldManager world)
    {
        string path = Application.persistentDataPath + "/Save Data/world.bfsf";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        WorldData data = new WorldData(world);
        File.WriteAllText(path, JsonUtility.ToJson(data));
    }

    public static WorldData LoadWorld(WorldManager world)
    {
        string path = Application.persistentDataPath + "/Save Data/world.bfsf";
        if (File.Exists(path))
        {
            WorldData data = JsonUtility.FromJson<WorldData>(File.ReadAllText(path));
            return data;
        }
        else
        {
            SaveWorld(world);
            return null;
        }
    }
}
