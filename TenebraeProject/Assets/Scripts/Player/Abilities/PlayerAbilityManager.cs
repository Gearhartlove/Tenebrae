using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    PlayerHealthUI p_ui;

    //Q
    GameObject Q;
    CooldownProgress Qcdprog;
    Qability q_ability;
    public float Qcd = 0;

    //W
    GameObject W;
    CooldownProgress Wcdprog;
    Wability w_ability;
    public float Wcd = 0;

    //E
    GameObject E;
    CooldownProgress Ecdprog;
    Eability e_ability;
    public float Ecd = 0;
    public float thrust = 0;

    // Start is called before the first frame update
    void Start()
    {
        //general
        p_ui = Player.PlayerVariables.PlayerHealth_UI;

        //Q ability
        Q = p_ui.gameObject.transform.Find("Q").gameObject;
        Qcdprog = Q.GetComponent<CooldownProgress>();

        //W ability
        W = p_ui.gameObject.transform.Find("W").gameObject;
        Wcdprog = W.GetComponent<CooldownProgress>();

        //E ability
        E = p_ui.gameObject.transform.Find("E").gameObject;
        Ecdprog = E.GetComponent<CooldownProgress>();
        
      
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
