using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using System;
using System.Linq;

public class ScanForBestTiles : ActionWithOptions<HexInfo> {
    public override void Execute(IAIContext context)
    {
        var c = (CityContext)context;
        List<ScoredOption<HexInfo>> scores = new List<ScoredOption<HexInfo>>();
        this.GetAllScores(context, c.targets, scores);
        scores = scores.OrderBy(x => x.score).ToList();
        c.scoredHexes = scores;
    }

}
