using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SphereController : MonoBehaviour
{
    Rigidbody rb;
    public float upForce = 1.0f;
    public float sideForce = 0.3f;

    private UnityAction<float, float> listener;

    void Awake()
    {
        listener = new UnityAction<float, float>(OnTrigger);
    }

    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, -4F, 0);
        rb = GetComponent<Rigidbody>();
        EventManager.StartListening("ButtonPressed", listener);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        
    }

    void OnTrigger(float posX, float posY)
    {
        rb.AddForce(Vector3.up * upForce, ForceMode.VelocityChange);
        rb.AddForce(Vector3.right * sideForce, ForceMode.VelocityChange);
        //Debug.Log(posY.ToString() + posZ.ToString());
    }
}
