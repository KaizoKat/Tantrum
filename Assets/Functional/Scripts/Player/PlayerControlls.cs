using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    float movnemtSpeed = 11;
    [HideInInspector] public bool CanMove = true;
    [SerializeField] private KeyCode sprint;

    [HideInInspector] 
    public Vector3 moveDir = Vector3.zero;
    private Vector3 slopeDirection = Vector3.zero;

    Rigidbody rig;

    void Start()
    {
        rig = GetComponent<Rigidbody>();

        PlayerData data = SaveSystem.LoadPlayer(this);
        if (data != null)
            transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        else
            Debug.Log("Created new player data save file");
    }
    
    void Update()
    {
        if(CanMove)
            Move();
    }
    RaycastHit slopeHit;
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 2.0f))
        {
            if (slopeHit.normal != Vector3.up)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    private void Move()
    {
        moveDir = Vector3.Normalize(new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")));
        slopeDirection = Vector3.ProjectOnPlane(moveDir, slopeHit.normal);

        if (!OnSlope())
        {
            if (Input.GetKey(sprint))
                rig.velocity = moveDir.normalized * movnemtSpeed * 2;
            else
                rig.velocity = moveDir * movnemtSpeed;
        }
        else
        {
            if (Input.GetKey(sprint))
                rig.velocity = slopeDirection.normalized * movnemtSpeed * 2;
            else
                rig.velocity = slopeDirection * movnemtSpeed;
        }

        if (moveDir == Vector3.zero)
            rig.isKinematic = true;
        else
            rig.isKinematic = false;
    }
}
