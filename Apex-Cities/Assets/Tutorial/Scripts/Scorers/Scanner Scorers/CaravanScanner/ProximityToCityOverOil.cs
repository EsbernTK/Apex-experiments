using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI;
using Apex.Serialization;
using System;

public class ProximityToCityOverOil : ScannerCustomScorer<CityContextProvider> {
    [ApexSerialization(defaultValue = 1f), FriendlyName("Fuel pr unit", "how much fuel it takes to go one unit")]
    public float fuelPrUnit = 1f;
    [ApexSerialization(defaultValue = 10f), FriendlyName("Weight", "how important is this resource")]
    public float Weight = 10f;

    public override float Score(IAIContext context, CityContextProvider option)
    {
        var c = (CaravanContext)context;
        Debug.Log(option);
        Vector3 goal = option.transform.position;
        float distance = Vector3.Distance(goal, c.self.position);
        this.score = (c.oil / (distance / fuelPrUnit))*Weight;
        return this.score;
    }
}
