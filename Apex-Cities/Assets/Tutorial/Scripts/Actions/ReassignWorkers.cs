using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using System;

public class ReassignWorkers : ActionBase
{
    public override void Execute(IAIContext context)
    {
        var c = (CityContext)context;
        c.workedHexInfos = new List<HexInfo>();
        if (c.population > 0 && c.scoredHexes.Count > 0) {

            for (int i = 1; i < c.population +1; i++)
            {
                c.workedHexInfos.Add(c.scoredHexes[c.scoredHexes.Count-i].option);
            }
        }
    }
}
