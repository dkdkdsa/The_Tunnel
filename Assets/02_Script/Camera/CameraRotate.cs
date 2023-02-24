using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    [SerializeField] private float sensitive = 100;
    [SerializeField] private Transform cameraRootObj;
    [SerializeField] private List<GameObject> rotateObj;

    private float rotateX;
    private float rotateY;

    public bool rotateAble { get; set; } = true;

    private void Update()
    {

        if (!rotateAble) return;

        Rotate();

    }

    private void Rotate()
    {

        rotateX += Input.GetAxis("Mouse X") * sensitive * Time.deltaTime;
        rotateY += Input.GetAxis("Mouse Y") * sensitive * Time.deltaTime;

        rotateY = Mathf.Clamp(rotateY, -80, 80);

        rotateObj.ForEach(x =>
        {

            x.transform.eulerAngles = new Vector3(-rotateY, rotateX, 0);

        });

        cameraRootObj.eulerAngles = new Vector3(-rotateY, rotateX, 0);
        transform.eulerAngles = new Vector3(0, rotateX, 0);

    }

}