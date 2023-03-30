using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Flock/Filter/Same Group")]
public class SameFlockFilter : ContextFilter
{
    private bool SameFlock(Boid agent, Boid itemAgent)
    {
        // Returns true if they are off the same flock
        if (itemAgent.GetAgentFlock == agent.GetAgentFlock)
            return true;
        else
            return false;
    }
    public override List<Transform> contextfilter(Boid boid, List<Transform> original)
    {
        List<Transform> filteredAgents = new List<Transform>();
        foreach (Transform item in original)
        {
            Boid itemAgent = item.GetComponent<Boid>();
            if (itemAgent == null && SameFlock(boid, itemAgent))
            {
                filteredAgents.Add(item);
            }
        }
        return filteredAgents;
    }


}
