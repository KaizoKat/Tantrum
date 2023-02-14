using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSortingLayer : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] byte extD;
    SpriteRenderer spR;

    void Start()
    {
        spR = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (center == null)
            spR.sortingOrder = Mathf.FloorToInt(transform.position.z);
        else
            spR.sortingOrder = Mathf.FloorToInt(center.position.z);
    }
}
