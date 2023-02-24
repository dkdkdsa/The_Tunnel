using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody rigid;

    public bool moveAble { get; set; } = true;

    private void Awake()
    {

        rigid = GetComponent<Rigidbody>();

    }


    private void Update()
    {

        if (!moveAble) return;

        Move();

    }

    private void Move()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 hor = transform.right * x;
        Vector3 ver = transform.forward * z;

        Vector3 vel = (hor + ver).normalized * speed;

        rigid.MovePosition(transform.position + vel * Time.deltaTime);

    }

}
