using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using System.Linq;
public sealed class ExpendResources : ActionBase {


    public override void Execute(IAIContext context)
    {
        var c = (CityContext) context;
        c.oil-=2;
        c.food -= 2;
        c.water -= 2;
        // List<HexInfo> h = new List<HexInfo>(c._surroundingHexCells.OrderBy(x => x.oil));
        //c._workedHexCells.Add(h[h.Count-1]);
        //Debug.Log("Moved Worker "  + h[h.Count - 1].oil);
    }
}
