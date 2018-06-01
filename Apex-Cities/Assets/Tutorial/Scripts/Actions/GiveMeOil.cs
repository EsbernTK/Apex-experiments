namespace MyNameSpace1
{
    using Apex.AI;
    using UnityEngine;

    public class GiveMeOil : ActionWithOptions<GameObject>
    {

        public override void Execute(IAIContext c)
        {
            var context = (CityContext)c;

            context.oil += 5;

            context.food -= (int)Random.Range(1, 3);
            context.water -= (int)Random.Range(1, 3);
            context.wood -= (int)Random.Range(1, 3);
        }

    }
}
