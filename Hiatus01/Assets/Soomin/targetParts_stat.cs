using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetParts_stat : MonoBehaviour {


    [SerializeField] float maxSensitivity;
    float currentSensitivity;

    [SerializeField] float maxTotalBlood;
    [SerializeField] float maxBloodperDrain;
    float currentBloodDrain;
    float cumulatedBloodDrain;
    int iterationNo = 1;


    target_stat targetStat;



    bool isDrainable = true;
    
    Transform mosq;

    // Use this for initialization
    void Start () {
        mosq = GameObject.FindGameObjectWithTag("player").transform; //find the player mosquito //through tag
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

                // action of the target works here
                // coroutine prefered
                // will be declared in each body parts

                isDrainable = true;

                iterationNo++;

            }
        }


        //blood drained is calculated through interaction between the mosquito

        //mostquito will increase the sensitivity of the body parts

    }
}
