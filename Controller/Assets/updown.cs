using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updown : MonoBehaviour
{
    /*public float v_thrust, h_thrust, scale = 100;
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
    	v_thrust = Input.GetAxis("Vertical");
    	h_thrust = Input.GetAxis("Horizontal");
       	rb.AddRelativeForce(new Vector3(-v_thrust * scale,0,h_thrust * scale));
    }*/
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public Rigidbody rb;

    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
        float angle = Mathf.Atan2(rb.velocity.z, rb.velocity.x) ;
        Debug.Log(angle);  
    }
}
