using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScroll : MonoBehaviour
{
    public Camera myCamera;
    private float camFOV;
    public float zoomSpeed = 10f;

    public float scrollValue = 0f;
    public float scrollMin = -1.0f;
    public float scrollMax = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        camFOV = myCamera.fieldOfView;
    }

    // Update is called once per frame
    public void AdjustFOV(float f)
    {
        camFOV -= scrollValue * zoomSpeed;
        camFOV = Mathf.Clamp(camFOV, 30, 60);

        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, camFOV, zoomSpeed);
    }
}
