using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using System.Linq;
public sealed class GatherResources : ActionBase {


    public override void Execute(IAIContext context)
    {
        var c = (CityContext) context;
        foreach (var workedHexInfo in c.workedHexInfos)
        {
            c.oil += workedHexInfo.oil;
            c.food += workedHexInfo.food;
            c.water += workedHexInfo.water;
        }

        c.oil += c.cityTile.oil;
        c.food += c.cityTile.food;
        c.water += c.cityTile.water;
        // List<HexInfo> h = new List<HexInfo>(c._surroundingHexCells.OrderBy(x => x.oil));
        //c._workedHexCells.Add(h[h.Count-1]);
        //Debug.Log("Moved Worker "  + h[h.Count - 1].oil);
    }
}
