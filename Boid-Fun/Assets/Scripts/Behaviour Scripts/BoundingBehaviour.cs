using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Bounding")]
public class BoundingBehaviour : BoidBehaviour
{
    
    public Vector3 center;
    Camera cam;
    public float radius=15.0f;
    public Rect rect = new Rect(0, 0, 600, 600);

    float xMin = 6000;
    float yMin = 6000;
    float xMax = 6000;
    float yMax = 6000;
    
    public override Vector3 CalculateMovement(Boid b, List<Transform> context, Flock flock)
    {
        
        //Vector3 centerOffset = center - b.transform.position;
        //float t = center.magnitude / radius;
        //if (t < 0.9f)
        //{
        //    return Vector3.zero;
        //}
        Vector3 v = Vector3.zero;
        if (b.transform.position.x < xMin)
        {
            v.x = 10;
        }
        else if(b.transform.position.x > xMax)
        {
            v.x = -10;
        }

        if (b.transform.position.y < yMin)
        {
            v.y = 10;
        }
        else if (b.transform.position.y < yMax)
        {
            v.y = -10;
        }

        return v;
    }
    
}
