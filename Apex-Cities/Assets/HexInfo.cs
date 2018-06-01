using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexInfo : MonoBehaviour
{
    public int oil;
    public int food, water;

    public bool isBeingWorkedOn;

    public Renderer myRenderer;
    // Use this for initialization
    void Start()
    {
        int rand = Random.Range(0, 3);
        myRenderer = GetComponent<Renderer>();
        switch (rand)
        {
            case 0:
                oil = Random.Range(3, 8);
                myRenderer.material.color = Color.black;
                break;
            case 1:
                food = Random.Range(3, 8);
                myRenderer.material.color = Color.green;
                break;
            case 2:
                water = Random.Range(3, 8);
                myRenderer.material.color = Color.blue;
                return;
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
