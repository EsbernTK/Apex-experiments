using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apex.AI.Components;
using Apex.AI;
using System;

public class CaravanContextProvider : MonoBehaviour, IContextProvider {

    public CaravanContext _context;
    [SerializeField]
    public int _oil = 10;
    [SerializeField]
    private int _water = 10;
    [SerializeField]
    private int _food = 10;
    [SerializeField]
    public List<CityContextProvider> _cities;
    private List<CityContext> _cityContexts = new List<CityContext>();
    public void OnEnable()
    {
        _context = new CaravanContext(transform, _oil + UnityEngine.Random.Range(0, 4), _water + UnityEngine.Random.Range(0, 4), _food + UnityEngine.Random.Range(0, 4), _cities);

    }
    public IAIContext GetContext(Guid aiId)
    {
        return _context;
    }

}
