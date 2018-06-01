    using System;
    using Apex.AI;
    using Apex.Serialization;
    using UnityEngine;

    public sealed class HasLowWaterScorer : ContextualScorerBase
{
        public override float Score(IAIContext _context)
        {
           CityContext context = (CityContext)_context;
        score = (100f / context.water);
        //Debug.Log(score + " Water");

        //var targets = context._surroundingHexCells;
        return this.score;
    }
}

