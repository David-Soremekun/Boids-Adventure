using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{

    public int SwarmIndex{get; set;}
    public float NoClumpingRadius{get,set;}
    public float LocalAreaRadius{get,set;}
    public float Speed{get,set;}
    public float SteeringSpeed{get,set;}
    // Start is called before the first frame update
    public void BoidMovement(List<BoidController>other, float deltaTime){
        var steering=Vector3.zero;
        if(stering!=Vector3.zero)
            transform.rotation=Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(steering), SteeringSpeed*deltaTime);
        
        transform.position+=transform.TransformDirection(new Vector3(0,0,Speed))*deltaTime;


    }
}
