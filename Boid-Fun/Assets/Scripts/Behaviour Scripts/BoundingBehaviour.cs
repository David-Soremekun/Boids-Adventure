using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Bounding")]
public class BoundingBehaviour : BoidBehaviour
{
    
    //public Vector3 center;
    //Camera cam;
    //public float radius=15.0f;
    //public Rect rect = new Rect(0, 0, 600, 600);

    //float xMin = 6000;
    //float yMin = 6000;
    //float xMax = 6000;
    //float yMax = 6000;
    
    public override Vector3 CalculateMovement(Boid b, List<Transform> context, Flock flock)
    {
        var OffsetFromCenter=flock.transform.position-b.transform.position;
        bool nearCenter = (OffsetFromCenter.magnitude >= flock.BoundingDist * 0.9f);
        return nearCenter ? OffsetFromCenter.normalized : Vector3.zero;
       
    }
    
}
