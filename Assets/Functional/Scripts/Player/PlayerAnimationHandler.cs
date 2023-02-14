using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator anima;

    [HideInInspector] public Vector2 dir = Vector2.zero;
    byte prevDir = 0;

    bool plCanMove;

    private void Start()
    {
        anima = GetComponent<Animator>();
        plCanMove = Overseer.GetPlayerControlls().CanMove;
    }

    private void Update()
    {
        dir = Vector3.Normalize(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f));
        if (plCanMove)
        {
            GetDirection();

            if (dir != Vector2.zero)
            {
                anima.SetBool("Walking", true);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anima.SetBool("Running", true);
                }
                else
                {
                    anima.SetBool("Running", false);
                }
            }
            else
            {
                anima.SetBool("Walking", false);
                anima.SetBool("Running", false);
            }
        }
        else
        {
            GetDirection();
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetDirection();
            anima.SetBool("Attacking", true);
        }
    }

    private void GetDirection()
    {
        if (dir.x == -1)
            prevDir = 1;

        if (dir.y == -1)
            prevDir = 0;

        if (dir.x == 1)
            prevDir = 3;

        if (dir.y == 1)
            prevDir = 2;

        if (prevDir == 0)
            anima.SetInteger("PrevDir", 0);

        if (prevDir == 1)
            anima.SetInteger("PrevDir", 1);

        if (prevDir == 2)
            anima.SetInteger("PrevDir", 2);

        if (prevDir == 3)
            anima.SetInteger("PrevDir", 3);
    }

    private void ResetAttack()
    {
        anima.SetBool("Attacking", false);
    }
}
