using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScroll : MonoBehaviour
{
    public Camera cam;
    private float camFOV;
    public float zoomSpeed = 35f;

    private float mouseScrollInput;

    public InputAction scrollAction;

    private void Awake()
    {
        scrollAction.performed += ctx => OnScrollWheel();
    }
        
    // Start is called before the first frame update
    void Start()
    {
        camFOV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        //mouseScrollInput = Input.GetAxis("Mouse ScrollWheel");

        //camFOV -= mouseScrollInput * zoomSpeed;
        camFOV = Mathf.Clamp(camFOV, 30, 60);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, camFOV, zoomSpeed);
    }

    private void OnScrollWheel()
    {
        Debug.Log("scrolling");
        var value = scrollAction.ReadValue<float>();
        Debug.Log(value);
    }
    
}
