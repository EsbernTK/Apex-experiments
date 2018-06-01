    using System;
    using Apex.AI;
    using Apex.Serialization;
    using UnityEngine;

    public sealed class HasLowWoodScorer : OptionScorerBase<GameObject>
    {
        public float score;


        public override float Score(IAIContext c, GameObject option)
        {
            var context = (CityContext)c;
            var targets = context.targets;
           // var index = Array.IndexOf(targets, option);

            //if (Mathf.RoundToInt(Time.time) % targets.Length == index)
            //{
            //    return this.score;
            //}
            return 0f;
        }
    }

