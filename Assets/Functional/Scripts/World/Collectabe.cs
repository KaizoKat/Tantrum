using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectabe : MonoBehaviour
{

    [SerializeField] Overseer seer;
    [SerializeField] private string ID;

    [ContextMenu("Generate new ID")] private void GenerateID(){ID = System.Guid.NewGuid().ToString();}
    bool colected = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!colected)
        {
            colected = true;
            gameObject.SetActive(false);
        }
    }
}
