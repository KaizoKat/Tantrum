using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] Transform camHolderPos;

    void Update()
    {
        transform.position = camHolderPos.position;
    }
}
