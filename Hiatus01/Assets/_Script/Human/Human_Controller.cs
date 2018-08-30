using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Controller : MonoBehaviour {

    [SerializeField] private GameObject head;
    private GameObject mosquito;

    [SerializeField] private float max_head_rotangle;
    [SerializeField] private float rotate_speed;

    private bool canTrack = true;

	// Use this for initialization
	void Start () {
        mosquito = GameObject.Find("Mosquito");
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
