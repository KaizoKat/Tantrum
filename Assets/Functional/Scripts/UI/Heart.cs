using UnityEngine;

public class Heart : MonoBehaviour
{
    public byte state = 3;
    [SerializeField] GameObject[] heart;

    void Update()
    {
        if(state == 4)
        {
            heart[3].SetActive(true);
            heart[2].SetActive(false);
            heart[1].SetActive(false);
            heart[0].SetActive(false);
        }
        else if (state == 3)
        {
            heart[3].SetActive(false);
            heart[2].SetActive(true);
            heart[1].SetActive(false);
            heart[0].SetActive(false);
        }
        else if (state == 2)
        {
            heart[3].SetActive(false);
            heart[2].SetActive(false);
            heart[1].SetActive(true);
            heart[0].SetActive(false);
        }
        else if (state == 1)
        {
            heart[3].SetActive(false);
            heart[2].SetActive(false);
            heart[1].SetActive(false);
            heart[0].SetActive(true);
        }
    }

}
