    using System;
    using Apex.AI;
    using Apex.Serialization;
    using MyNameSpace1;
    using UnityEngine;

    public sealed class HasLowOilScorer : ContextualScorerBase
{
        public override float Score(IAIContext _context)
        {
            CityContext context = (CityContext) _context;
            score = (100f/context.oil);
        //var targets = context._surroundingHexCells;
        //Debug.Log(score + " Oil");

        return this.score;

        }
}
