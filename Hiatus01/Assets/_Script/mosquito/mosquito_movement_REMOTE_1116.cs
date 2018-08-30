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

    private mosquito_state state;
    private mosquito_suck suck;

    private Vector3 surface_vector = Vector3.up;


    // Use this for initialization
    void Start() {
        mouselook.Init(transform, fp_cam.transform);
        rb = GetComponent<Rigidbody>();
        state = GetComponent<mosquito_state>();
        suck = GetComponent<mosquito_suck>();
    }

    // Update is called once per frame
    void Update() {
        float forward_movement = Input.GetAxis("Vertical");
        float right_movement = Input.GetAxis("Horizontal");

        if (canMove)
        {
            transform.Translate(Vector3.forward * speed * forward_movement * Time.deltaTime);
            transform.Translate(Vector3.right * speed * right_movement * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jump_force);
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 normal_to_surface = transform.position - surface_vector;
                rb.AddForce(normal_to_surface * 2000);
                Switch_To_FirstPerson();
            }
        }
        LookAt_Mouse_Position();
    }

    [SerializeField] private MouseLook mouselook = new MouseLook();
    private void LookAt_Mouse_Position() {
        mouselook.LookRotation(transform, fp_cam.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Switch_To_ThirdPerson(collision);

        surface_vector = collision.contacts[0].point;
    }



    private void Switch_To_FirstPerson() {
        tp_cam.depth = -1;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;

        canMove = true;

        state.current_state = (mosquito_state.m_state)3;
        suck.CurrentCollider = null;
    }
    private void Switch_To_ThirdPerson(Collision collision)
    {
        tp_cam.depth = 1;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        canMove = false;

        bool drainableTarget;
        if (collision.gameObject.GetComponent<targetParts_stat>() != null) drainableTarget = collision.gameObject.GetComponent<targetParts_stat>().isDrainable;
        else drainableTarget = false;

        if (collision.transform.tag == "Human" && drainableTarget)
        {
            state.current_state = (mosquito_state.m_state)1;
            suck.CurrentCollider = collision;
        }
        else
        {
            state.current_state = (mosquito_state.m_state)0;
        }
    }

    
}
