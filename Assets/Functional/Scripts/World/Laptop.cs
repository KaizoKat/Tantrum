using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour
{
    [SerializeField] Material laptopUpMat;

    [SerializeField] Texture OFF;
    [SerializeField] Texture PowerngUp;
    [SerializeField] Texture BlueScreen;
    [SerializeField] Texture GreenScreen;
    byte bp = 0;

    private void Update()
    {
        float ddp = Vector3.Distance(transform.position, Overseer.GetPlayerControlls().transform.position);
        if (ddp <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            if (bp == 0)
            {
                StartCoroutine(BootUpTheLaptop());
            }
            else if(bp ==  2)
            {
                
                SaveSystem.SaveWorld(Overseer.GetWorldManager());
                SaveSystem.SavePlayer(Overseer.GetPlayerControlls());

                StartCoroutine(PowerOffTheLaptop());
            }
        }

        if (ddp > 2 && bp == 3)
        {
            StartCoroutine(PowerOffTheLaptop());
        }
    }

    IEnumerator BootUpTheLaptop()
    {
        bp = 1;
        laptopUpMat.mainTexture = PowerngUp;

        yield return new WaitForSeconds(1);

        if (Random.Range(0, 99) < 3)
        {
            laptopUpMat.mainTexture = BlueScreen;
        }
        else
        {
            laptopUpMat.mainTexture = GreenScreen;
        }

        bp = 2;
    }

    IEnumerator PowerOffTheLaptop()
    {
        laptopUpMat.mainTexture = PowerngUp;

        yield return new WaitForSeconds(2);
        bp = 0;
        laptopUpMat.mainTexture = OFF;
    }
}
