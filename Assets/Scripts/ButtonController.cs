using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonController : MonoBehaviour
{
    public GameObject LCube;
    public GameObject RCube;
    float posX, posY;

	// Use this for initialization
	void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            posX = LCube.transform.position.x;
            posY = LCube.transform.position.y;
            EventManager.TriggerEvent("ButtonPressed", posX, posY);
            //Debug.Log("LEFT" + posX + posY);
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            posX = RCube.transform.position.x;
            posY = RCube.transform.position.y;
            EventManager.TriggerEvent("ButtonPressed", posX, posY);
            //Debug.Log("RIGHT" + posX + posY);
        }

    }
}
