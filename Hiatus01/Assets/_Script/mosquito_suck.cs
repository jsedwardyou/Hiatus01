using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mosquito_suck : MonoBehaviour {

    [SerializeField] private float speed_drain;
    [SerializeField] private float max_drain;

    private float current_drain;

    [SerializeField] private Image blood_bar;

    private mosquito_state state;
    
    private Collision currentCollider;

	// Use this for initialization
	void Start () {
        blood_bar.fillAmount = 0;
        state = GetComponent<mosquito_state>();
	}

    // Update is called once per frame
    void Update()
    {
        if (state.current_state == (mosquito_state.m_state)1)
        {
            if (current_drain >= max_drain) return;

            if (currentCollider.gameObject.GetComponent<targetParts_stat>().isDrainable == true)
            {
                current_drain += speed_drain * Time.deltaTime;

                currentCollider.gameObject.GetComponent<targetParts_stat>().CumulatedBloodDrain += speed_drain * Time.deltaTime;
            }
        }
    }



    public Collision CurrentCollider
    {
        get
        {
            return currentCollider;
        }
        set
        {
            currentCollider = value;
        }
    }
}
