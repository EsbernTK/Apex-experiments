using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using System.Linq;
public sealed class ReassignWorkerToWaterAction : ActionBase {


    public override void Execute(IAIContext context)
    {
        var c = (CityContext) context;
        List<HexInfo> h = new List<HexInfo>(c.targets.OrderBy(x => x.water));
        HexInfo bestWater = h[h.Count - 1];
        if (!c.workedHexInfos.Contains(bestWater))
        {
            c.workedHexInfos.Add(bestWater);
            bestWater.myRenderer.material.color *= Color.grey;
            if (c.population <= 0)
            {
                c.workedHexInfos.RemoveAt(0);
                //c.population++;
            }
            c.population--;
           
            Debug.DrawRay(bestWater.transform.position, bestWater.transform.up * 3, Color.blue, 10);

        }

    }
}
