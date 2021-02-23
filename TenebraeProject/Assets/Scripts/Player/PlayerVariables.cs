using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerVariables : MonoBehaviour
    {
        public static GameObject PlayerGameObject;
        public static NavMeshAgent Agent;
        public static CameraScroll CameraScrollObject;
        public static PlayerCombat PlayerCombatObject;
        public static PlayerMovement PlayerMovementObject;
        public static string PlayerFocus;

        private void Awake()
        {
            PlayerGameObject = gameObject;
            Agent = gameObject.GetComponent<NavMeshAgent>();
            PlayerCombatObject = GetComponentInChildren<PlayerCombat>();
            CameraScrollObject = GameObject.Find("Main Camera").GetComponent<CameraScroll>();
            PlayerMovementObject = GetComponentInChildren<PlayerMovement>();
        }


    }
}