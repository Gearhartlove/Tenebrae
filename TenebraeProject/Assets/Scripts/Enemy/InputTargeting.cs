using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Enemy
{
    public class InputTargeting : MonoBehaviour
    {
        public GameObject selectedHero;
        public bool heroPlayer;
        RaycastHit hit;
        // Start is called before the first frame update
        void Start()
        {
            selectedHero = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}