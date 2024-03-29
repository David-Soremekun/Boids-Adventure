using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FilteredFlockBehaviour
{
    public override Vector3 CalculateMovement(Boid b, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
            return b.transform.up;

        Vector3 alignmentVector = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.contextfilter(b, context);
        foreach (Transform item in context)
        {
            alignmentVector += item.transform.up;
        }
        alignmentVector /= context.Count;

        
        return alignmentVector;
    }
}
