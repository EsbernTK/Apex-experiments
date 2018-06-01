using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using System;

public class ScanForBestCity : ActionWithOptions<CityContextProvider> {
    public override void Execute(IAIContext context)
    {
        var c = (CaravanContext)context;
        Debug.Log(c.cities.Count);
        var best = this.GetBest(c, c.cities);
        
        List<ScoredOption<CityContextProvider>> scores = new List<ScoredOption<CityContextProvider>>();
        this.GetAllScores(context, c.cities, scores);
        foreach(ScoredOption<CityContextProvider> city in scores)
        {
            city.option.GetComponentInChildren<TextMesh>().text = "" + city.score;
        }
    }

   
}
