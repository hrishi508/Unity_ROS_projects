using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Docs
Build a general controller for maintining a given cmd vel.
Now just uses the AddRelativeForce and AddTorque methods for Rigid Body.
Can be used for any general rigid Body

Settings:
Make sure u Freeze Rotation in  x and z axis or else the box tumbles.
(Go to Rigid Body > Constraints for this)


Changes:
instead of increasing the speed with each key input, this script 
maintains a constant speed as long as the key is pressed.
*/

public class controllerv2 : MonoBehaviour
{	
    public float scale = 1.0f;
    public int frames = 3;
	public Rigidbody rb;
    public GameObject go;
	public float velocity; //input for translation
    public float rotation; //input for rotation
    public float speed = 5.0f; //speed for translation
    public float speed_rot = 2.0f; //speed for rotation

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update(){
        /*TODO:
        Take a given velcoity as input
        Interfacing with ros
        */
        velocity = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
        AddForceWithRespectToVelcoity(velocity);
        AddTorquewithRespectToVelocity(rotation);
    }

    void AddForceWithRespectToVelcoity(float velocity){
        /* Sometimes flies off randomly after rotation. 
        Maintains the value of speed variable as long as w/d pressed
        */
        Vector3 currenteulerAngles = go.transform.rotation.eulerAngles;
        float angle = Mathf.Atan2(rb.velocity.z, rb.velocity.x);

        float sign2;
        if(currenteulerAngles.y * Mathf.Deg2Rad > Mathf.PI)
            sign2 = 1;
        else
            sign2 = -1;
        
        float sign = sign2 * Mathf.Sign(angle);
        float present_vel = rb.velocity.magnitude * sign;
        float error = (speed * velocity) - present_vel;
        float acceleration = error/(frames * Time.deltaTime);
        rb.AddRelativeForce(new Vector3(rb.mass * acceleration * scale, 0, 0));     
        //Debug.Log("Lin Vel");
        Debug.Log(sign2);     
    }

    void AddTorquewithRespectToVelocity(float rotation){
        /* TODO:
       Working, but need to test more extensively
        */
        float present_vel = rb.angularVelocity.y;
        float error = (speed_rot * rotation) - present_vel;
        float acceleration = error/(frames * Time.deltaTime);
        rb.AddTorque(transform.up * rb.mass * acceleration); 	
        //Debug.Log("Ang Vel");
        //Debug.Log(rb.angularVelocity);   
    }
}