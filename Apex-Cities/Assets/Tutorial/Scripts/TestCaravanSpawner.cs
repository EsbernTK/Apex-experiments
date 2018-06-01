using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCaravanSpawner : MonoBehaviour {
    public List<CityContextProvider> cities;
    public GameObject prefab;
    float delay;
	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(delay);
        GameObject temp = Instantiate(prefab) as GameObject;
        temp.GetComponent<CaravanContextProvider>()._cities = cities;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
