using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    //Q
    GameObject Q;
    CooldownProgress Qcdprog;
    Qability Qability;
    public float Qcd;

    //W
    GameObject W;
    CooldownProgress Wcdprog;
    Qability Wability;
    public float Wcd;

    //E
    GameObject E;
    CooldownProgress Ecdprog;
    Qability Eability;
    public float Ecd;

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
        Qcdprog.Check();
    }

    public void PressW()
    {
        Wcdprog.Check();
    }

    public void PressE()
    {
        Ecdprog.Check();
    }
}
