using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetParts_stat : MonoBehaviour {


    [SerializeField] float maxSensitivity = 100;
    public float sensitivitySpeed = 3;
    float currentSensitivity;

    [SerializeField] float maxTotalBlood = 100;
    [SerializeField] float maxBloodperDrain = 100;
    float currentBloodDrain;
    [SerializeField] float cumulatedBloodDrain;
    int iterationNo = 1;


    target_stat targetStat;



    public bool isDrainable = true;
    
    Transform mosq;

    // Use this for initialization
    void Start () {
        mosq = GameObject.FindGameObjectWithTag("Player").transform; //find the player mosquito //through tag
        targetStat = GetComponentInParent<target_stat>();

    }
	
	// Update is called once per frame
	void Update () {

        if (isDrainable == true)
        {
            //if all blood is drained, cannot be drained anymore
            if (cumulatedBloodDrain >= maxTotalBlood)
            {
                isDrainable = false;
            }

            //if current blood drained reached max blood per drain, changes to temporary undrainable
            else if (cumulatedBloodDrain >= iterationNo * maxBloodperDrain)
            {
                isDrainable = false;

                // 
                // send signal to targetstat for action
                // 

                Debug.Log("reached temp max");
                targetStat.AggroToNextLevel() ;

                iterationNo++;

                isDrainable = true;
                
            }
        }


        //blood drained is calculated through interaction between the mosquito
        //done in suck

        //mostquito will increase the sensitivity of the body parts

    }

    public float CumulatedBloodDrain
    {
        get
        {
            return cumulatedBloodDrain;
        }
        set
        {
            cumulatedBloodDrain = value;
        }
    }

    public float CurrentSensitivity
    {
        get
        {
            return currentSensitivity;
        }
        set
        {
            currentSensitivity = value;
        }
    }

    public void IncreaseSensitivity(float f)
    {
        targetStat.aggro += f;
        Debug.Log(targetStat.aggro);
    }

}
