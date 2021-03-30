using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownProgress : MonoBehaviour
{
    //fields
    public PlayerAbilityManager a_manager; //Ability Manager
    public TMPro.TextMeshProUGUI cool_text;
    public Image circle_image;
    public float ABILITY_CD;
    public float currentValue = 0; //higher than ABILITY CD by default
                                   //need to set to zero when ability is used > TODO
    public bool IsAvailable; //is ability off cd?

    //Start is called before the first frame update
    void Start()
    {
        cool_text = gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        circle_image = gameObject.GetComponentInChildren<Image>();
        IsAvailable = true;

        //which ability cd to assign
        string s = gameObject.name;
        switch (s)
        {
            case "Q":
                ABILITY_CD = a_manager.Qcd;
                break;
            case "W":
                ABILITY_CD = a_manager.Wcd;
                break;
            case "E":
                ABILITY_CD = a_manager.Ecd;
                break;


        }
    }

    //Update is called once per frame
    void Update()
    {
        //if the player can not cast the ability again, tick down fill
        if (IsAvailable == false)
        {
            //show transparent black background
            circle_image.gameObject.SetActive(true);
            gameObject.SetActive(true);
            circle_image.enabled = true;
            //tick down by time
            currentValue += Time.deltaTime;
            cool_text.text = (ABILITY_CD - (int)currentValue).ToString();
            //change fill on circle  
            circle_image.fillAmount = (1 - (float)currentValue / (float)ABILITY_CD);
            //if fill amount is 0, make ability available
            if (circle_image.fillAmount <= 0) { IsAvailable = true; }
        }
        else 
        {
            //if ability available to be cast, make UI dissapear 
            circle_image.gameObject.SetActive(false);
            circle_image.enabled = false;
            currentValue = 0;
            //set to true
            IsAvailable = true;
        }
    }

    //called every press of Q, changes true in first chunk of update loop
    public bool Check()
    {
        if (IsAvailable == true)
        {
            IsAvailable = false;
            return true;
        }
        return false;
    }
}
