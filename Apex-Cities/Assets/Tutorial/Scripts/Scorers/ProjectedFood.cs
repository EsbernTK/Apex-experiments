using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
public class ProjectedFood : ContextualScorerBase {

    public override float Score(IAIContext context)
    {
        var c = (CityContext)context;
        return c.food * this.score;
    }

}
