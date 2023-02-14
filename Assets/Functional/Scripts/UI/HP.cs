using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    [SerializeField] Heart[] containers;
    public bool hit = false;
    public int dammage;
    public int hp;
    public int MaxHp;

    private void Start()
    {
        for (int i = 0; i < containers.Length; i++)
            containers[i].gameObject.SetActive(false);
    }

    void Update()
    {
        for (int i = 0; i < MaxHp / 2; i++)
            containers[i].gameObject.SetActive(true);

        if(hit == true)
        {
            hit = false;
            StartCoroutine(PlayHitAnimation());
        }

        if (hp <= 0)
            EndGame();
    }

    void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator PlayHitAnimation()
    {
        for(int i = 0; i < containers.Length; i++)
            containers[i].state = 4;
            yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < containers.Length; i++)
            containers[i].state = 1;
            yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < containers.Length; i++)
            containers[i].state = 4;
            yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < containers.Length; i++)
            containers[i].state = 1;

        yield return new WaitForSeconds(0.1f);
        hp -= dammage;

        for (int i = 0; i < hp / 2; i++)
            containers[i].state = 3;

        if (hp % 2 == 0)
            containers[hp / 2].state = 1;
        else
            containers[hp / 2].state = 2;
    }

}
