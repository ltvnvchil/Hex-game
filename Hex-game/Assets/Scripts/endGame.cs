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
    public int graphnumber;

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
    public List<graph> graphList;
    public cell[,] masCell = new cell[21, 11];
    // Start is called before the first frame update
    void Start()
    {
        graphList = new List<graph>();
        //masCells = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newCell(int id, int idx, int idy, int color)
    {
        cell newcell = new cell(id, idx, idy, color);
        masCell[idx-1, idy-1] = newcell;

        checkCellinGraph(newcell);
    }

    public void checkCellinGraph(cell curcell)
    {
        int curx = curcell.idx-1;
        int cury = curcell.idy-1;
        int curcolor = curcell.color;

        graph newgraph = new graph();
        graphList.Add(newgraph);
        int idgraph = graphList.Count;
        masCell[curx, cury].graphnumber = idgraph;

        if (masCell[curx - 1, cury].color == curcolor)//сверху слева
        {

        }
        else if (masCell[curx + 1, cury].color == curcolor)//справа снизу
        {

        }
        else if (masCell[curx, cury - 1].color == curcolor)//справа
        {

        }
        else if (masCell[curx, cury + 1].color == curcolor)//слева
        {

        }
        else if (masCell[curx - 1, cury - 1].color == curcolor)//справа сверху
        {

        }
        else if (masCell[curx + 1, cury + 1].color == curcolor)//слева снизу
        {

        }
        else
        {

        }
    }
}
