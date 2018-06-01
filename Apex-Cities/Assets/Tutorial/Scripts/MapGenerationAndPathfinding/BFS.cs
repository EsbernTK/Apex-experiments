using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : MonoBehaviour
{

    public GameObject Tile;
    public float delay;

    GameObject[,] tiles;
    Vector2[,] parent;
    int[,] map = {
        { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1 },
        { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 },
        { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 3, 1 },
        { 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    };

    List<Vector2> q;


    void Start()
    {
        parent = new Vector2[12, 12];
        q = new List<Vector2>();
        tiles = new GameObject[12, 12];
        for (int y = 0; y < 12; y++)
        {
            for (int x = 0; x < 12; x++)
            {
                tiles[x, y] = Instantiate(Tile, new Vector3(x - 5.5f, 5.5f - y, 0), Quaternion.identity) as GameObject;
                if (map[y, x] == 0)
                    tiles[x, y].GetComponent<Renderer>().material.color = Color.black;
                else if (map[y, x] == 2)
                {
                    tiles[x, y].GetComponent<Renderer>().material.color = Color.red;
                    q.Add(new Vector2(x, y));
                }
                else if (map[y, x] == 3)
                    tiles[x, y].GetComponent<Renderer>().material.color = Color.blue;
                else
                    tiles[x, y].GetComponent<Renderer>().material.color = Color.gray;


            }
        }
        StartCoroutine(slowAnim());
    }


    void Update()
    {

    }

    IEnumerator drawPath()
    {
        while (map[(int)q[0].y, (int)q[0].x] != 2)
        {
            q[0] = parent[(int)q[0].x, (int)q[0].y];
            tiles[(int)q[0].x, (int)q[0].y].GetComponent<Renderer>().material.color = Color.white;
            yield return new WaitForSeconds(delay);
        }
        q.RemoveAt(0);
    }

    IEnumerator slowAnim()
    {
        while (q.Count > 0)
        {
            if (map[(int)q[0].y, (int)q[0].x] == 3)
            {
                tiles[(int)q[0].x, (int)q[0].y].GetComponent<Renderer>().material.color = Color.white;
                StartCoroutine(drawPath());
                break;
            }
            tiles[(int)q[0].x, (int)q[0].y].GetComponent<Renderer>().material.color = Color.white;
            yield return new WaitForSeconds(delay);
            if (q[0].x > 0 && (tiles[(int)q[0].x - 1, (int)q[0].y].GetComponent<Renderer>().material.color == Color.gray
                || tiles[(int)q[0].x - 1, (int)q[0].y].GetComponent<Renderer>().material.color == Color.blue))
            {
                q.Add(new Vector2(q[0].x - 1, q[0].y));
                parent[(int)q[0].x - 1, (int)q[0].y] = new Vector2(q[0].x, q[0].y);
                tiles[(int)q[0].x - 1, (int)q[0].y].GetComponent<Renderer>().material.color = Color.red;
                yield return new WaitForSeconds(delay);
            }
            if (q[0].x < 11 && (tiles[(int)q[0].x + 1, (int)q[0].y].GetComponent<Renderer>().material.color == Color.gray
            || tiles[(int)q[0].x + 1, (int)q[0].y].GetComponent<Renderer>().material.color == Color.blue))
            {
                q.Add(new Vector2(q[0].x + 1, q[0].y));
                parent[(int)q[0].x + 1, (int)q[0].y] = new Vector2(q[0].x, q[0].y);
                tiles[(int)q[0].x + 1, (int)q[0].y].GetComponent<Renderer>().material.color = Color.red;
                yield return new WaitForSeconds(delay);
            }
            if (q[0].y > 0 && (tiles[(int)q[0].x, (int)q[0].y - 1].GetComponent<Renderer>().material.color == Color.gray
            || tiles[(int)q[0].x, (int)q[0].y - 1].GetComponent<Renderer>().material.color == Color.blue))
            {
                q.Add(new Vector2(q[0].x, q[0].y - 1));
                parent[(int)q[0].x, (int)q[0].y - 1] = new Vector2(q[0].x, q[0].y);
                tiles[(int)q[0].x, (int)q[0].y - 1].GetComponent<Renderer>().material.color = Color.red;
                yield return new WaitForSeconds(delay);
            }
            if (q[0].y < 11 && (tiles[(int)q[0].x, (int)q[0].y + 1].GetComponent<Renderer>().material.color == Color.gray
            || tiles[(int)q[0].x, (int)q[0].y + 1].GetComponent<Renderer>().material.color == Color.blue))
            {
                q.Add(new Vector2(q[0].x, q[0].y + 1));
                parent[(int)q[0].x, (int)q[0].y + 1] = new Vector2(q[0].x, q[0].y);
                tiles[(int)q[0].x, (int)q[0].y + 1].GetComponent<Renderer>().material.color = Color.red;
                yield return new WaitForSeconds(delay);
            }

            tiles[(int)q[0].x, (int)q[0].y].GetComponent<Renderer>().material.color = Color.green;
            q.RemoveAt(0);
            yield return new WaitForSeconds(delay);

        }
    }
}



