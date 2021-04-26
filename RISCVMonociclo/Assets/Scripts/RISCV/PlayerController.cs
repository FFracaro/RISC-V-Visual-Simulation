using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float zoomSpeed;
    public float orthographicSizeMin;
    public float orthographicSizeMax;
    public float sensitivityX;
    public float sensitivityY;

    private Camera myCamera;
    public CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ClickToMove();
        ZoomCamera();
    }

    void ZoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            vcam.m_Lens.OrthographicSize += zoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            vcam.m_Lens.OrthographicSize -= zoomSpeed;
        }
        vcam.m_Lens.OrthographicSize = Mathf.Clamp(vcam.m_Lens.OrthographicSize, orthographicSizeMin, orthographicSizeMax);  
    }

    void ClickToMove()
    {
        if (Input.GetMouseButton(0))
        {
            vcam.transform.position += vcam.transform.right * Input.GetAxis("Mouse X") * -sensitivityX;
            vcam.transform.position += vcam.transform.up * Input.GetAxis("Mouse Y") * -sensitivityY;
        }
    }
}
