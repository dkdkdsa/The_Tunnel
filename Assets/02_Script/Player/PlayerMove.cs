using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private Rigidbody rigid;
    private JumpBox jumpBox;
    private CinemachineBasicMultiChannelPerlin cbmcp;
    private float shackLerpSpeed = 15;

    public bool moveAble { get; set; } = true;
    public bool isMove { get; private set; }

    private void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        jumpBox = transform.Find("JumpBox").GetComponent<JumpBox>();
        cbmcp = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }


    private void Update()
    {

        if (!moveAble)
        {

            isMove = false;
            SetCbmcp(0, 0);

            return;

        }

        if (isMove)
        {

            SetCbmcp(2f, 2);

        }
        else
        {

            SetCbmcp(0, 0);

        }

        Jump();

    }

    private void FixedUpdate()
    {

        if (!moveAble)
        {

            isMove = false;

            return;

        }

        Move();

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

    private void SetCbmcp(float amplitudeGain, float frequencyGain)
    {

        cbmcp.m_AmplitudeGain = Mathf.Lerp(cbmcp.m_AmplitudeGain, amplitudeGain, shackLerpSpeed * Time.deltaTime);
        cbmcp.m_FrequencyGain = Mathf.Lerp(cbmcp.m_FrequencyGain, frequencyGain, shackLerpSpeed * Time.deltaTime);

    }

    private void Jump()
    {

        if(Input.GetKeyDown(KeyCode.Space) && jumpBox.isGround)
        {

            rigid.velocity += new Vector3(0, jumpPower, 0);

        }

    }

    public void SetSpeed(float value)
    {

        speed = value;

    }


    public float GetSpeed()
    {

        return speed;

    }
}
