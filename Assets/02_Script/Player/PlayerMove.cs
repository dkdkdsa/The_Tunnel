using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private Rigidbody rigid;
    private JumpBox jumpBox;

    public bool moveAble { get; set; } = true;
    public bool isMove { get; private set; }

    private void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        jumpBox = transform.Find("JumpBox").GetComponent<JumpBox>(); 

    }


    private void Update()
    {

        if (!moveAble)
        {

            isMove = false;

            return;

        }

        Move();
        Jump();

    }

    private void Move()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 hor = transform.right * x;
        Vector3 ver = transform.forward * z;

        Vector3 vel = (hor + ver).normalized * speed;

        if(vel == Vector3.zero)
        {

            isMove = false;

        }
        else
        {

            isMove = true;

        }

        rigid.MovePosition(transform.position + vel * Time.deltaTime);

    }

    private void Jump()
    {

        if(Input.GetKeyDown(KeyCode.Space) && jumpBox.isGround)
        {

            rigid.velocity += new Vector3(0, jumpPower, 0);

        }

    }

}
