namespace MyNameSpace1
{
    using Apex.AI;
    using UnityEngine;

    public class GiveMeWater : ActionWithOptions<GameObject>
    {

        public override void Execute(IAIContext c)
        {
            var context = (CityContext)c;

            context.water += 5;

            context.wood -= (int)Random.Range(1, 3);
            context.food -= (int)Random.Range(1, 3);
            context.oil -= (int)Random.Range(1, 3);
        }

    }
}
