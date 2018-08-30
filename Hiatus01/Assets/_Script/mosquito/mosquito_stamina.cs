using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mosquito_stamina : MonoBehaviour {

    [SerializeField] private float max_stamina;
    [SerializeField] private float decayspeed_stamina;

    private float current_stamina;

    [SerializeField] private Image stamina_bar;

	// Use this for initialization
	void Start () {
        current_stamina = max_stamina;
	}
	
	// Update is called once per frame
	void Update () {
        current_stamina -= decayspeed_stamina * Time.deltaTime;

        if (current_stamina > 0) {
            stamina_bar.fillAmount = (current_stamina / max_stamina);
        }
	}
}
