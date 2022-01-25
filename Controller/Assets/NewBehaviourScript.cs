﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Docs
Build a general controller for maintining a given cmd vel.
Now just uses the AddRelativeForce and AddTorque methods if Rigid Body.
Can be used for any general rigid Body

Settings:
Make sure u Freeze Rotation in  x and z axis or else the box tumbles.
(Go to Rigid Body > Constraints for this)
*/

public class NewBehaviourScript : MonoBehaviour
{   
    public float scale = 10.0f;
    public int frames = 3;
    public Rigidbody rb;
    public float velocity;
    public float rotation;
    public float MaxVelocity = 2.0f;
    public float MaxAngularVelocity = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Fixed Update updates every physiscs step
    void FixedUpdate()
    {
        /* Fixed update is used whenever physics is used.
        So let this be.
        */
        AddForceWithRespectToVelcoity(velocity);
        AddTorquewithRespectToVelocity(rotation);
    }
    // Updates every step
    void Update(){
        /*TODO:
        Take a given velcoity as input
        Interfacing with ros
        */
        velocity += Input.GetAxis("Vertical");
        rotation += Input.GetAxis("Horizontal");
    }

    void AddForceWithRespectToVelcoity(float velocity){
        /* WOrking optimally
        Maintains a given velocity by adding force according to the error
        Have test this
        */
        float present_vel = rb.velocity.x;
        float error = velocity - present_vel;
        float acceleration = error/(frames * Time.deltaTime);
        rb.AddRelativeForce(new Vector3(rb.mass * acceleration * scale, 0, 0));
        Debug.Log("Lin Vel");
        Debug.Log(rb.velocity);        
    }

    void AddTorquewithRespectToVelocity(float rotation){
        /* TODO:
        1. The cube is not rotating with a lower velocity
        2. With the given settings its rotating somewhat at a velocity of 5.6 to 6
        3. Fix this to accomadate the slow angular velocity movement also
        */
        float present_vel = rb.angularVelocity.y;
        float error = rotation - present_vel;
        float acceleration = error/(frames * Time.deltaTime);
        rb.AddRelativeTorque(new Vector3(0, rb.mass * acceleration, 0));
        Debug.Log("Ang Vel");
        Debug.Log(rb.angularVelocity);       
    }
}