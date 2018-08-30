using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosquito_state : MonoBehaviour {

    public enum m_state {
        idle     = 0,
        draining = 1,
        sitting  = 2,
        flying   = 3
    }

    public m_state current_state;
}
