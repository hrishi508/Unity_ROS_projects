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

public class RosController : MonoBehaviour
{   
    public float scale = 1.0f;
    public float scale_2 = 10.0f;
    public int frames = 3;
    public Rigidbody rb;
    public GameObject go;
    public float velocity = 1; //input for translation
    public float rotation = 1; //input for rotation
    public Vector3 vect_speed; 
    public Vector3 vect_speed_rot; 
    public float speed;  //speed for translation
    public float speed_rot; //speed for rotation
    public float lin_speed_limit = 0.15f;
    public float rot_speed_limit = 0.075f;

    // Start is called before the first frame update
    void Start()
    {
        //rb = this.GetComponent<Rigidbody>();
        vect_speed = RosSharp.RosBridgeClient.TwistSubscriber.linearVelocity;
        vect_speed_rot = RosSharp.RosBridgeClient.TwistSubscriber.angularVelocity;

        speed = vect_speed.z; speed*=scale_2;
        speed_rot = vect_speed_rot.y; speed_rot*=scale_2;
    }

    void Update(){
        /*TODO:
        Take a given velcoity as input
        Interfacing with ros
        */
        //velocity = 1;
        //rotation = 1;
        vect_speed = RosSharp.RosBridgeClient.TwistSubscriber.linearVelocity;
        vect_speed_rot = RosSharp.RosBridgeClient.TwistSubscriber.angularVelocity;

        // limit velocities         
        speed = vect_speed.z;
        if(speed < -lin_speed_limit){
            speed = -lin_speed_limit;
        }
        else if(speed > lin_speed_limit){
            speed = lin_speed_limit;
        }
        speed*=scale_2;

        // angular vel
        speed_rot = vect_speed_rot.y;

        if(speed_rot < -rot_speed_limit){
            speed_rot = -rot_speed_limit;
        }
        else if(speed_rot > rot_speed_limit){
            speed_rot = rot_speed_limit;
        }
        speed_rot*=scale_2;

        AddForceWithRespectToVelcoity(velocity);
        AddTorquewithRespectToVelocity(rotation);
    }

    void AddForceWithRespectToVelcoity(float velocity){
        /* Sometimes flies off randomly after rotation. (fixed)
        Maintains the value of speed variable as long as w/d pressed
        */
        Vector3 currenteulerAngles = go.transform.rotation.eulerAngles;
        float angle = Mathf.Atan2(Mathf.Abs(rb.velocity.x), Mathf.Abs(rb.velocity.z)) * Mathf.Rad2Deg;

        if(rb.velocity.x >= 0 && rb.velocity.z >= 0)
        {
            angle*=1;
        }

        else if(rb.velocity.x >= 0 && rb.velocity.z <= 0)
        {
            angle = 180 - angle;
        }
        
        else if(rb.velocity.x <= 0 && rb.velocity.z <= 0)
        {
            angle = 180 + angle;
        }

        else if(rb.velocity.x <= 0 && rb.velocity.z >= 0)
        {
            angle = 360 - angle;
        }   

        float sign;
        if( Mathf.Abs(currenteulerAngles.y - angle) > 90)
            sign = -1;
        else
            sign = 1;
        
        float present_vel = rb.velocity.magnitude * sign;
        float error = (speed * velocity) - present_vel;
        float acceleration = error/(frames * Time.deltaTime);
        rb.AddRelativeForce(new Vector3(0, 0, rb.mass * acceleration * scale));     
        Debug.Log("Lin Vel");
        Debug.Log(rb.velocity.magnitude);     
    }

    void AddTorquewithRespectToVelocity(float rotation){
        /* TODO:
       Working, but need to test more extensively
        */
        float present_vel = rb.angularVelocity.y;
        float error = (speed_rot * rotation) - present_vel;
        float acceleration = error/(frames * Time.deltaTime);
        rb.AddTorque(transform.up * rb.mass * acceleration);    
        Debug.Log("Ang Vel");
        Debug.Log(rb.angularVelocity.y);   
    }
}