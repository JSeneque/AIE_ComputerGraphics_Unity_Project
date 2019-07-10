using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    // this class manages the turning on and off of the forcefield that is attached to the gameobject
    private bool isOn = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // get the animator component
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // when F key is pressed
        if(Input.GetKeyDown(KeyCode.F))
        {
            // swap flag
            isOn = !isOn;

            // set the animation parameter
            anim.SetBool("isOn", isOn);
        }
    }
}
