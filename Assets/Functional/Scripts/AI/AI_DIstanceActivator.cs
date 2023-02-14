using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AI_DIstanceActivator : MonoBehaviour
{

    private void Update()
    {
        if (Vector3.Distance(transform.position, Overseer.GetPlayerControlls().transform.position) <= 50)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            gameObject.GetComponent<AI_Behavior>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<AI_Behavior>().enabled = false;
        }
    }

}
