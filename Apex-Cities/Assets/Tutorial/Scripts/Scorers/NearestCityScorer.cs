using System;
using Apex.AI;
using Apex.Serialization;
using UnityEngine;

public sealed class NearestCityScorer : ContextualScorerBase
{

    public override float Score(IAIContext _context)
    {
        CaravanContext context = (CaravanContext)_context;
        
        

        return this.score;
    }
}
