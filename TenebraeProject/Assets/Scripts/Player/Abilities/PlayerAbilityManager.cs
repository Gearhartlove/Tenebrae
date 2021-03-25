using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    //Q
    GameObject Q;
    CooldownProgress Qcdprog;
    Qability q_ability;
    public float Qcd;

    //W
    GameObject W;
    CooldownProgress Wcdprog;
    Wability w_ability;
    public float Wcd;

    //E
    GameObject E;
    CooldownProgress Ecdprog;
    Eability e_ability;
    public float Ecd;
    public float thrust = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Q ability
        Q = gameObject.transform.Find("Q").gameObject;
        Qcdprog = Q.GetComponentInChildren<CooldownProgress>();

        //W ability
        W = gameObject.transform.Find("W").gameObject;
        Wcdprog = W.GetComponentInChildren<CooldownProgress>();

        //E ability
        E = gameObject.transform.Find("E").gameObject;
        Ecdprog = E.GetComponentInChildren<CooldownProgress>();
        
      
    }

    public void PressQ()
    {
        if (Qcdprog.Check())
        {
            
        }

    }

    public void PressW()
    {
        if (Wcdprog.Check())
        {

        }
    }

    public void PressE()
    {
        Eability.thrust = thrust; // for testing
        if (Ecdprog.Check())
        {
            Eability.Roll();
        }
    }
}
