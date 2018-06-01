namespace MyNameSpace1  
{
    using Apex.AI;
    using UnityEngine;

    public class RotateToTarget : ActionWithOptions<HexInfo>
    {

        public override void Execute(IAIContext c)
        {
            var context = (CityContext)c;

            // We use the method "GetBest" which will evaluate all the GameObjects 
            // that we send in and return the one with the highest score

            var best = this.GetBest(context, context.targets);
            if (best == null)
            {
                return;
            }

            context.self.LookAt(best.transform);
        }

    }
}



