using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSlider : MonoBehaviour
{
    float RotateValuez = -2f; //small adjustment removing slight slant
  
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0f, 180f, RotateValuez);
    }
}
