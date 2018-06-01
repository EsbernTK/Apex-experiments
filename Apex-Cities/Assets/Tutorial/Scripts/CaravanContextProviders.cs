using System;
using System.Collections;
using System.Collections.Generic;
using Apex.AI;
using Apex.AI.Components;
using UnityEngine;

public class CaravanContextProviders : MonoBehaviour, IContextProvider {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private List<GameObject> _knownCities;
    private CaravanContext _context;

    public void OnEnable()
    {
        _context = new CaravanContext(this.transform,this._knownCities);
    }

    public IAIContext GetContext(Guid aiId)
    {
        return _context;
    }
}
