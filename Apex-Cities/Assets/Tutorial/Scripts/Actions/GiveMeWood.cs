namespace MyNameSpace1
{
    using Apex.AI;
    using UnityEngine;

    public class GiveMeWood : ActionWithOptions<GameObject>
    {

        public override void Execute(IAIContext c)
        {
            var context = (CityContext)c;

            context.wood += 5;

            context.food -= (int) Random.Range(1, 3);
            context.water -= (int)Random.Range(1, 3);
            context.oil -= (int)Random.Range(1, 3);

        }

    }
}
