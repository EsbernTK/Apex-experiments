using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HexGrid : MonoBehaviour {

    public int width = 6;
    public int height = 6;

    public Text cellLabelPrefab;
    public HexCell cellPrefab;
    public Color defaultColor = Color.grey;


    public List<HexCell> openList;

    private Canvas gridCanvas;
    private HexMesh hexMesh;

    private HexCell[] cells; 

    public void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();

        cells = new HexCell [width * height];
        openList = new List<HexCell>();

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
            
        }
    }

    void Start()
    {
        hexMesh.Triangulate(cells);
    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f); 
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform,false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x,z);
        cell.index = cell.coordinates.X + cell.coordinates.Z * width + cell.coordinates.Z / 2;
        cell.transform.name = HexCoordinates.FromPosition(cell.transform.position).ToString();
        
        cell.cost = Random.Range(0, 6); // random range 0 - 5 (int)
      //  cell.color = Color.magenta /cell.cost;
        cell.color = Color.grey * 0.1f;
      

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition = 
            new Vector2(position.x, position.z);
        //label.rectTransform.rect.Set(position.x, position.y, 10,15);
        label.text = cell.coordinates.ToStringOnSeparateLines();
    }


   

    public  void ColorCell(Vector3 position, Color color)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int index = coordinates.X + coordinates.Z*width + coordinates.Z/2;
        HexCell cell = cells[index];
        cell.color = color;
        hexMesh.Triangulate(cells);

    }

    private void ColorNeighbour(int index)
    {
        HexCell cell = cells[index];
        cell.color += Color.green;
        hexMesh.Triangulate(cells);
    }

    private void ColorNeighbour(int index, Color color)
    {
        HexCell cell = cells[index];
        cell.color = color;
        hexMesh.Triangulate(cells);
    }

    public HexCell ChooseStartingCell(Vector3 position)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
        HexCell cell = cells[index];
        cell.color = Color.blue;
        hexMesh.Triangulate(cells);

        return cell;
    }

    public HexCell  getCell(Vector3 position)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
        HexCell cell = cells[index];

        Debug.Log("Go to cell " + index);
        Debug.Log("With coordinates " + coordinates);
        cell.color = Color.black;
        hexMesh.Triangulate(cells);

        return cell;
    }

    public HexCell getCellFromIndex( int index)
    {
        HexCell cell = cells[index];
        return cell;
    }


    

    public void addNeighbours(HexCell currentCell, HexCell endCell)
    {
        HexCell neighbour;
        //check if upper left exists, if it does add it

        for (int i = 0; i < cells.Length; i++)
        {

            // 1
            if (cells[i].coordinates.X == currentCell.coordinates.X &&
                cells[i].coordinates.Y == currentCell.coordinates.Y - 1 &&
                cells[i].coordinates.Z == currentCell.coordinates.Z + 1)
            {
                if (cells[i].burned == false)
                {
                    evaluateCell(cells[i], endCell, currentCell);
                }

            }
            // 2
            if (cells[i].coordinates.X == currentCell.coordinates.X + 1 &&
                cells[i].coordinates.Y == currentCell.coordinates.Y - 1 &&
                cells[i].coordinates.Z == currentCell.coordinates.Z )
            {
                if (cells[i].burned == false)
                {
                    evaluateCell(cells[i], endCell, currentCell);
                }

            }
            // 3
            if (cells[i].coordinates.X == currentCell.coordinates.X + 1 &&
                cells[i].coordinates.Y == currentCell.coordinates.Y &&
                cells[i].coordinates.Z == currentCell.coordinates.Z -1)
            {
                if (cells[i].burned == false)
                {
                    evaluateCell(cells[i], endCell, currentCell);
                }

            }
            // 4
            if (cells[i].coordinates.X == currentCell.coordinates.X  &&
                cells[i].coordinates.Y == currentCell.coordinates.Y  + 1&&
                cells[i].coordinates.Z == currentCell.coordinates.Z - 1)
            {
                if (cells[i].burned == false)
                {
                    evaluateCell(cells[i], endCell, currentCell);
                }

            }
            // 5 
            if (cells[i].coordinates.X == currentCell.coordinates.X -1 &&
                cells[i].coordinates.Y == currentCell.coordinates.Y + 1&&
                cells[i].coordinates.Z == currentCell.coordinates.Z )
            {
                if (cells[i].burned == false)
                {
                    evaluateCell(cells[i], endCell, currentCell);
                }

            }
            // 6 
            if (cells[i].coordinates.X == currentCell.coordinates.X - 1 &&
                cells[i].coordinates.Y == currentCell.coordinates.Y &&
                cells[i].coordinates.Z == currentCell.coordinates.Z +1 )
            {
                if (cells[i].burned == false)
                {
                    evaluateCell(cells[i], endCell, currentCell);
                }

            }


        }


    }

    private void evaluateCell(HexCell cell, HexCell endCell, HexCell currentCell)
    {
        
        if (!openList.Contains(cell))
        {
            
            cell.heuristic = (int)Vector3.Distance(cell.transform.localPosition, endCell.transform.localPosition);
            cell.combinedCost = cell.cost + cell.heuristic;



            cell.parents.Add(currentCell);
            cell.parents.AddRange(currentCell.parents);
            cell.combinedCost += cell.parents.Sum(x => x.cost);


            
                openList.Add(cell);
                ColorNeighbour(cell.index);
            
            
        }
        
        
    }


    public IEnumerator FindPath( HexCell currentCell, HexCell endCell)
    {
        openList.Add(currentCell);

        while (true)
        {
             
       
            addNeighbours(currentCell, endCell);
            yield return new WaitForEndOfFrame();

            currentCell.burned = true;
            openList.Remove(currentCell);

            openList = openList.OrderBy(x => x.combinedCost).ToList(); //sort open list according to tile/node cost

            currentCell = openList[0];
        

            if (currentCell == endCell)
            {
               
                break;
            }
           

        }

        foreach (HexCell parent in endCell.parents)
        {
            ColorNeighbour(parent.index, Color.red); 
        }
       

        
    }
}
