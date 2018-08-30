using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mosquito_suck_sm : MonoBehaviour {

    [SerializeField] private float speed_drain;
    [SerializeField] private float max_drain;

    private float current_drain;

    [SerializeField] private Image blood_bar;

    private mosquito_state state;

	// Use this for initialization
	void Start () {
        blood_bar.fillAmount = 0;
        state = GetComponent<mosquito_state>();
	}
	
	// Update is called once per frame
	void Update () {
        if (state.current_state == (mosquito_state.m_state)1) {
            if (current_drain >= max_drain) return;

            current_drain += speed_drain * Time.deltaTime;
        }

        blood_bar.fillAmount = (current_drain / max_drain);
	}
}
