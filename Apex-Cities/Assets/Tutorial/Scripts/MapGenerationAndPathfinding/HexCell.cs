using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{

    public HexCoordinates coordinates;

    public Color color;

    public int cost, index, combinedCost, pathCost, heuristic;

    public List<HexCell> parents;

    public bool burned = false;




}
