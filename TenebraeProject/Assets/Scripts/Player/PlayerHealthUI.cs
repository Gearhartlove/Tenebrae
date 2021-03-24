using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

public class PlayerHealthUI : MonoBehaviour
{
    static int idx = 0; //don't like static here
    public Texture[] tArray;
    float RotateValuez = 0f; //small adjustment removing slight slant
    GameObject player;
    PlayerActions playerActions;
    public RawImage health_sphere;



    private void Start()
    {
        
        player = Player.PlayerVariables.PlayerGameObject;
        playerActions = player.GetComponentInChildren<PlayerActions>();
        health_sphere = transform.GetComponentInChildren<RawImage>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.y = 6.52f;
        transform.position = playerPosition;
        transform.LookAt(Camera.main.transform);
        //transform.rotation = fixedRotation;
        transform.Rotate(0f, 180f, RotateValuez);
        //change the y position
    }

    public void SetHP()
    {
        if (idx == tArray.Length-2)
        {
            idx++;
            health_sphere.texture = tArray[idx];
            playerActions.Death();
        }
        else
        {
            idx++;
            health_sphere.texture = tArray[idx];
        }
    }
}
