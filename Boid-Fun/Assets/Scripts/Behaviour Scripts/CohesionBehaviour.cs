using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FilteredFlockBehaviour
{
    public override Vector3 CalculateMovement(Boid b, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return Vector3.zero;

        Vector3 cohesionVec = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.contextfilter(b, context);
        foreach (Transform item in filteredContext)
        {
            cohesionVec += item.position;
        }
        cohesionVec /= context.Count;

        cohesionVec -= b.transform.position;
        return cohesionVec;
    }


}
