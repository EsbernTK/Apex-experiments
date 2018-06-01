

    using System.Collections.Generic;
    using Apex.AI;
    using UnityEngine;

    public sealed class CityContext : IAIContext
    {
        public HexInfo cityTile;
    public List<ScoredOption<HexInfo>> scoredHexes = new List<ScoredOption<HexInfo>>();
        public CityContext(Transform transform, List<HexInfo> targets, List<HexInfo> workedHexInfos, int oil, int wood, int water, int food)
        {
            this.self = transform;
            cityTile = targets[0];
            targets.RemoveAt(0);
            this.targets = targets;
            this.workedHexInfos = workedHexInfos;
            this.oil = oil;
            this.wood = wood;
            this.water = water;
            this.food = food;
        }

        public int population = 1;

        public Transform self { get; private set; }
         public List<HexInfo> workedHexInfos { get; set; }

    public List<HexInfo> targets { get; private set; }

        public int oil { get;  set; }
        public int wood { get;  set; }
        public int water { get;  set; }
        public int food { get;  set; }

    }



