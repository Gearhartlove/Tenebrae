using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeInventory2 : MonoBehaviour
{
    private Canvas playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.Find("PlayerInventoryCanvas").GetComponent<Canvas>();
        Debug.Log(playerInventory.GetType());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressingTab() //turn on and off the UI
    {
        if (playerInventory.enabled) { playerInventory.enabled = false; }
        else { playerInventory.enabled = true; }
    }
}
