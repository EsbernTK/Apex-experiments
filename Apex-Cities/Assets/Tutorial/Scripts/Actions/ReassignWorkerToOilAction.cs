using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using System.Linq;
using UnityEditor;

public sealed class ReassignWorkerToOilAction : ActionBase {


    public override void Execute(IAIContext context)
    {
        var c = (CityContext) context;
        List<HexInfo> h = new List<HexInfo>(c.targets.OrderBy(x => x.oil));
        HexInfo bestOil = h[h.Count - 1];
        if (!c.workedHexInfos.Contains(bestOil))
        {
            c.workedHexInfos.Add(bestOil);
            if (c.population <= 0)
            {
                c.workedHexInfos.RemoveAt(0);
                //c.population++;
            }
            c.population--;
            
            Debug.DrawRay(bestOil.transform.position, bestOil.transform.up * 3, Color.black, 10);

            Debug.Log("Moved Worker " + h[h.Count - 1].oil);
        }
    }
}
