using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosquito_movement : MonoBehaviour {

    [SerializeField] private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float forward_movement = Input.GetAxis("Vertical");

        transform.Translate(transform.forward * speed * Time.deltaTime * forward_movement);
	}
}
