using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using System.Linq;
public sealed class ReassignWorkerToFoodAction : ActionBase {

    public override void Execute(IAIContext context)
    {
        var c = (CityContext) context;
        List<HexInfo> h = new List<HexInfo>(c.targets.OrderBy(x => x.food));
        HexInfo bestFood = h[h.Count - 1];
        if (!c.workedHexInfos.Contains(bestFood))
        {
            c.workedHexInfos.Add(bestFood);
            if (c.population <= 0)
            {
                c.workedHexInfos.RemoveAt(0);
                //c.population++;
            }
            c.population--;
            
            Debug.DrawRay(bestFood.transform.position, bestFood.transform.up * 3, Color.green, 10);

        }

    }
}
