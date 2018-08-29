using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class mosquito_movement : MonoBehaviour {

    [SerializeField] private Camera fp_cam;
    [SerializeField] private Camera tp_cam;

    [SerializeField] private float speed;
    [SerializeField] private float jump_force;

    private Rigidbody rb;
    private bool canMove = true;

    // Use this for initialization
    void Start() {
        mouselook.Init(transform, fp_cam.transform);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float forward_movement = Input.GetAxis("Vertical");
        float right_movement = Input.GetAxis("Horizontal");

        if (canMove)
        {
            transform.Translate(Vector3.forward * speed * forward_movement * Time.deltaTime);
            transform.Translate(Vector3.right * speed * right_movement * Time.deltaTime);
        }
        else {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Switch_To_FirstPerson();
            }
        }
         
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(Vector3.up * jump_force);
        }

        LookAt_Mouse_Position();

    }

    [SerializeField] private MouseLook mouselook = new MouseLook();
    private void LookAt_Mouse_Position() {
        mouselook.LookRotation(transform, fp_cam.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Switch_To_ThirdPerson();
    }



    private void Switch_To_FirstPerson() {
        tp_cam.depth = -1;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;

        canMove = true;
    }
    private void Switch_To_ThirdPerson()
    {
        tp_cam.depth = 1;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        canMove = false;
    }
}
