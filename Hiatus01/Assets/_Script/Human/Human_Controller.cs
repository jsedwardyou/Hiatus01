using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Controller : MonoBehaviour {

    [SerializeField] private GameObject head;
    private GameObject mosquito;

    [SerializeField] private float rotate_speed;

    [SerializeField] private GameObject Left_Arm_Pivot;
    [SerializeField] private GameObject Right_Arm_Pivot;

    private bool canTrack = true;

    private Animator anim;

	// Use this for initialization
	void Start () {
        mosquito = GameObject.Find("Mosquito");
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        head.transform.LookAt(mosquito.transform.position);

        float angle = angle_towards_mosquito();
        
        if (angle > -90 && angle < 90) {
            
        }
        else
        {
            if (canTrack) {
                StartCoroutine(Track_Mosquito(angle));
            }
        }

        Left_Arm_Pivot.transform.LookAt(mosquito.transform.position);
        Right_Arm_Pivot.transform.LookAt(mosquito.transform.position);
    }

    private IEnumerator Track_Mosquito(float init_angle) {
        canTrack = false;
        float angle = init_angle;
        while (!(angle < 10 && angle > -10)) {
            if (angle < 0)
            {
                transform.Rotate(0, -rotate_speed * Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(0, rotate_speed * Time.deltaTime, 0);
            }
            angle = angle_towards_mosquito();
            yield return null;
        }
        anim.Play("Human_Catch");
        canTrack = true;
        yield return null;
    }

    private float angle_towards_mosquito() {
        Vector3 forward_ground = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        Vector3 direction_mosquito_ground = new Vector3(mosquito.transform.position.x - transform.position.x, 0, mosquito.transform.position.z - transform.position.z);
        float angle = Vector3.SignedAngle(forward_ground, direction_mosquito_ground, transform.up);

        return angle;
    }
}
