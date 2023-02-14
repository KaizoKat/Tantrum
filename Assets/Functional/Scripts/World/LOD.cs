using UnityEngine;


public class LOD : MonoBehaviour
{
    [SerializeField] float lodDistance;
    [SerializeField] float maxDrawDistance;
    [SerializeField] GameObject main;
    [SerializeField] GameObject distant;
    Transform plPos;

    private void Start()
    {
        plPos = Overseer.GetPlayerControlls().transform;
    }

    private void LateUpdate()
    {
        byte state = 0;
        float distance = Vector3.Distance(plPos.position, transform.position);
        if (distance <= lodDistance)
            state = 1;

        if (HCompare.Inside(distance, lodDistance, maxDrawDistance))
            state = 2;

        if(distance > maxDrawDistance)
            state = 3;

        switch (state)
        {
            case 1:
                main.SetActive(true);
                distant.SetActive(false);
                break;

            case 2:
                main.SetActive(false);
                distant.SetActive(true);
                break;

            case 3:
                main.SetActive(false);
                distant.SetActive(false);
                break;
        }

    }
}
