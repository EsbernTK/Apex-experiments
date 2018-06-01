using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AStarAgent : MonoBehaviour
{
    public HexGrid hexGrid;

    private Vector3 startingPos;
    private Vector3 goalPosition;

    public HexCell currentCell;
    public HexCell endCell = null;
    public bool pathDone = true;
    


    void Awake()
    {
        

        currentCell = hexGrid.getCellFromIndex(25); //start at first cell
    }

   

    
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(1))
        {
            GetPosition(1);

        }
	    if (Input.GetMouseButton(0))
	    {
	        GetPosition(0);
	    }

	    if (endCell != null && pathDone)
	    {
	        pathDone = !pathDone;
	        StartCoroutine(hexGrid.FindPath(currentCell, endCell));

	    }

    }


    void GetPosition( int inputButton)
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit))
        {
            if (inputButton == 1)
            {
              endCell = hexGrid.getCell(hit.point);
            }
            if (inputButton == 0)
            {
                currentCell = hexGrid.ChooseStartingCell(hit.point);
            }
     
        }

    }

    

    
}
