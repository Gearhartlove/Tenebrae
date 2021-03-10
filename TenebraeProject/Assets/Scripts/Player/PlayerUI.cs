using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Texture2D basicCursor;
    [SerializeField] Texture2D combatCursor;
    [SerializeField] Texture2D interactionCursor;
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Player.PlayerVariables.PlayerGameObject.transform.position;
    }
}
