using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_stat : MonoBehaviour {

    public float aggro = 0;
    enum AggroState {Low, Medium, High};
    [SerializeField] AggroState CurrentState;
    /// <summary>
    /// 부위별로 필요한 부분들
    /// 각 부위별 촉각 수치 -> 전체 어그로로 환산
    /// 각 부위별 최대 흡혈 가능량, 1회 최대 흡혈량
    /// </summary>

    Transform mosq;
    float mosqdst; //머리tag의 부위와 모기 사이의 거리
    [SerializeField] float dstRange=2; //거리 제한
    [SerializeField] float dstAggroSpeed=5;

    Transform head;


    // Use this for initialization
    void Start () {
        mosq = GameObject.FindGameObjectWithTag("Player").transform; //find the player mosquito //through tag
        head = transform.Find("head"); //find the head child //through name
	}
	
	// Update is called once per frame
	void Update () {
		
        //calculate distance between mosquito
        if(mosq != null && head != null)
        {
            mosqdst = Vector3.Distance(head.transform.position, mosq.transform.position);

            //add aggro if the distance is too close
            if (mosqdst < dstRange)
            {
                aggro += dstAggroSpeed * Time.deltaTime;
            }
            else
            {
                aggro -= dstAggroSpeed / 2 * Time.deltaTime;
            }

            aggro = Mathf.Clamp(aggro, 0, 100);

        }

        

        //aggro affecting the aggrostate
        if(aggro <= 33)
        {
            CurrentState = AggroState.Low;
        } else if (aggro > 66)
        {
            CurrentState = AggroState.High;
        } else
        {
            CurrentState = AggroState.Medium;
        }


	}
}
