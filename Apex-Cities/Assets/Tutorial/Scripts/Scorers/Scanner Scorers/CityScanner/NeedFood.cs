using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using Apex.Serialization;
using System;

public class NeedFood : ScannerCustomScorer<HexInfo> {

    [ApexSerialization(defaultValue = 10f), FriendlyName("Threshhold", "When a city has enough of the resource")]
    public float Threshhold = 10f;
    [ApexSerialization(defaultValue = 10f), FriendlyName("Weight", "how important is this resource")]
    public float Weight = 10f;

    public override float Score(IAIContext context, HexInfo option)
    {
        var c = (CityContext)context;
        this.score = Weight * option.food * (Threshhold / c.food);
        return this.score;
    }
}
