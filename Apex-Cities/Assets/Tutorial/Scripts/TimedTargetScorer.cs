namespace MyNameSpace1
{
    using System;
    using Apex.AI;
    using Apex.Serialization;
    using UnityEngine;

    public sealed class TimedTargetScorer : OptionScorerBase<HexInfo>
    {

        [
            ApexSerialization(defaultValue = 10f), 
            FriendlyName("Score", "The score output for the option that evaluates true")
        ]

        public float score = 10f;


        public override float Score(IAIContext context, HexInfo option)
        {
            throw new NotImplementedException();
        }
    }

}

