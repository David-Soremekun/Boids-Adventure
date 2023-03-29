using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Seperation")]
public class SeperationBehaviour : FilteredFlockBehaviour
{
    public override Vector3 CalculateMovement(Boid b, List<Transform> context, Flock flock)
    {

        if (context.Count == 0)
            return Vector3.zero;

        Vector3 seperationVec= Vector3.zero;
        int ObjectsToAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.contextfilter(b, context);
        foreach (Transform item in context)
        {
            if(Vector3.SqrMagnitude(item.position-b.transform.position)< flock.getAvoidanceRadius)
            {
                ObjectsToAvoid++;
                seperationVec += (b.transform.position - item.position);
            }
            
        }
        if (ObjectsToAvoid > 0)
            seperationVec /= ObjectsToAvoid;

        return seperationVec;
    }
}

