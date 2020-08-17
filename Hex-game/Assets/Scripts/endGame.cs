using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cell
{
    public int id;
    public int idx;
    public int idy;
    public int color;
    public bool isFull = false;
    public bool isBoard;
    public graph graphnumber;

    public cell(int id, int idx, int idy, int color)
    {
        this.id = id;
        this.idx = idx;
        this.idy = idy;
        this.color = color;
        this.isFull = true;
        //isBoard = isBoard;          
    }
}

public class graph
{
    public int id;
    public int[] idcells;
}


public class endGame : MonoBehaviour
{
    public static List<graph> graphList;
    // Start is called before the first frame update
    void Start()
    {
        graphList = new List<graph>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newCell(int id, int idx, int idy, int color)
    {
        cell newcell = new cell(id, idx, idy, color);
    }
}
