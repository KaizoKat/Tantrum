

using UnityEngine;

public class Overseer
{

    private static PlayerControlls GetPlayerControlls()
    {
        return Object.FindObjectOfType<PlayerControlls>();
    }

    public static PlayerAnimationHandler GetAnimationHandler()
    {
        return Object.FindObjectOfType<PlayerAnimationHandler>();
    }

    public static HP GetPlayerHP()
    {
        return Object.FindObjectOfType<HP>();
    }

    public static WorldManager GetWorldManager()
    {
        return Object.FindObjectOfType<WorldManager>();
    }

    public DebugMenu GetDebugMenu()
    {
        return Object.FindObjectOfType<DebugMenu>();
    }

    public static Collectabe[] GetCollectabes()
    {
        return Object.FindObjectsOfType<Collectabe>();
    }

    public static Laptop[] GetLaptops()
    {
        return Object.FindObjectsOfType<Laptop>();
    }

    public static AI_Behavior[] GetAI_s()
    {
        return Object.FindObjectsOfType<AI_Behavior>();
    }
}
