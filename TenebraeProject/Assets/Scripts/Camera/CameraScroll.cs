using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScroll : MonoBehaviour
{
    public Camera myCamera;
    private float camFOV, minFOV = 30f, maxFOV = 60f;
    public float zoomSpeed = 1f;

    public float scrollValue = 0f;
    public float scrollMin = -1.0f;
    public float scrollMax = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        camFOV = myCamera.fieldOfView;
    }

    // Update is called once per frame
    public void AdjustFOV(float scrollValue)
    {
        this.scrollValue = scrollValue;

        camFOV -= this.scrollValue * zoomSpeed;
        camFOV = Mathf.Clamp(camFOV, minFOV, maxFOV);

        if (camFOV == minFOV || camFOV == maxFOV) { this.scrollValue = 0; }

        myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, camFOV, zoomSpeed);
    }
}
