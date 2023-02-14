using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHouse : MonoBehaviour
{
    [SerializeField] private bool Enter_Exit = false;
    [SerializeField] private GameObject Deactivated;
    [SerializeField] private GameObject Activated;
    [SerializeField] private Transform ExitPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
            StartCoroutine(TeleportationSequenceIn(other.gameObject));
    }

    IEnumerator TeleportationSequenceIn(GameObject other)
    {
        if(Enter_Exit)
            other.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 5f);
        else
            other.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -5f);

        other.transform.position = new Vector3(transform.position.x, other.transform.position.y, other.transform.position.z);
        other.GetComponent<Collider>().isTrigger = true;
        other.GetComponent<PlayerControlls>().CanMove = false;

        if (Enter_Exit)
            Overseer.GetAnimationHandler().dir.y = 1;
        else
            Overseer.GetAnimationHandler().dir.y = -1;

        yield return new WaitForSeconds(0.7f);

        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.transform.position = ExitPos.position;
        other.GetComponent<Collider>().isTrigger = false;
        other.GetComponent<PlayerControlls>().CanMove = true;

        Deactivated.SetActive(false);
        Activated.SetActive(true);
    }
}
