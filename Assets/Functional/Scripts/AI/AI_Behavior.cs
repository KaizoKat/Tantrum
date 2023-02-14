using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AI_Behavior : MonoBehaviour
{
    private enum PatrolType
    {
        Random,
        Area,
        Static
    };

    private enum EnemyType
    {
        Default
    };
    
    [Header("Settings")]
    [SerializeField] private PatrolType patrolType;
    [SerializeField] private LayerMask ground, player;
    [SerializeField] private float walkPointRange, patrollArea, timeB_Attacks, sightR, attackR, attackDmg;

    private NavMeshAgent agent;
    
    private Vector3 startPos, walkPoint;
    private bool is_insideSightR, is_insideAttackR, is_atPoint, is_attacked;
    private byte counter;

    private bool PlayedCoroutine;
    private Transform plPos;

    private void Start()
    {
        startPos = transform.position;
        agent = gameObject.GetComponent<NavMeshAgent>();
        plPos = Overseer.GetPlayerControlls().transform;
    }

    private void Update()
    {
        DO_IT();
    }

    private void DO_IT()
    {
        is_insideSightR = Physics.CheckSphere(transform.position, sightR, player);
        is_insideAttackR = Physics.CheckSphere(transform.position, attackR, player);


        if (!is_insideSightR && !is_insideAttackR && patrolType == PatrolType.Random)
        {
            if (PlayedCoroutine == false)
            {
                PlayedCoroutine = true;
                StartCoroutine(RandomPatroll());
            }
                
        }
        else if (!is_insideSightR && !is_insideAttackR && patrolType == PatrolType.Area)
        {
            if (PlayedCoroutine == false)
            {
                PlayedCoroutine = true;
                StartCoroutine(AreaPatroll());
            }
        }
        else if (!is_insideSightR && !is_insideAttackR && patrolType == PatrolType.Static)
        {
            if (PlayedCoroutine == false)
            {
                PlayedCoroutine = true;
                StartCoroutine(StaticPatrol());
            }
        }
        else if (is_insideSightR && !is_insideAttackR)
            Chase();
        else if (is_insideSightR && is_insideAttackR)
            Attack();
    }

    private void Attack()
    {
        agent.SetDestination(transform.position);

        if (!is_attacked)
        {
            Overseer.GetPlayerHP().hit = true;
            Overseer.GetPlayerHP().dammage = (int)attackDmg;
            is_attacked = true;
            Invoke(nameof(ResetAttack), timeB_Attacks);
        }

    }

    private IEnumerator AreaPatroll()
    {
        if (Vector3.Distance(startPos, transform.position) < patrollArea)
        {
            if (is_atPoint == false)
            {
                is_atPoint = true;
                counter = 0;
                walkPoint = NewWalkPoint();
            }

            if (is_atPoint == true)
            {
                agent.SetDestination(walkPoint);
                counter++;
            }

            if (Vector3.Distance(transform.position, walkPoint) <= 1)
            {
                is_atPoint = false;
                yield return new WaitForSeconds(Random.Range(1,3));
            }
            else if (Vector3.Distance(transform.position, walkPoint) > 1 && counter == 100)
            {
                is_atPoint = false;
                counter = 0;
            }

            PlayedCoroutine = false;
        }
        else if(Vector3.Distance(startPos, transform.position) >= patrollArea)
        {
            agent.SetDestination(startPos);

            yield return new WaitForSeconds(HUtils.WaintForVector3(transform.position, startPos));
            PlayedCoroutine = false;
        }
    }

    private IEnumerator StaticPatrol()
    {
        if(transform.position != startPos)
            agent.SetDestination(startPos);

        yield return new WaitForSeconds(HUtils.WaintForVector3(transform.position,startPos));
        PlayedCoroutine = false;
    }

    private IEnumerator RandomPatroll()
    {
        if (is_atPoint == false)
        {
            is_atPoint = true;
            counter = 0;
            walkPoint = NewWalkPoint();
        }
        else
        {
            agent.SetDestination(walkPoint);
            counter++;
        }

        if (Vector3.Distance(transform.position, walkPoint) <= 1)
        {
            is_atPoint = false;
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
        else if(Vector3.Distance(transform.position, walkPoint) > 1 && counter == 100)
        {
            is_atPoint = false;
            counter = 0;
        }

        PlayedCoroutine = false;
    }

    private Vector3 NewWalkPoint()
    {
        Vector3 walkPoint = new Vector3(transform.position.x + Random.Range(-walkPointRange, walkPointRange), transform.position.y, transform.position.z + Random.Range(-walkPointRange, walkPointRange));
        return walkPoint;
    }
    
    private void Chase()
    {
        agent.SetDestination(plPos.position);
    }

    private void ResetAttack()
    {
        is_attacked = false;
    }
}
