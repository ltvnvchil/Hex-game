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
    public int color;
    public int id;
    public int[] idx;
    public int[] idy;
    public bool leftWall = false;//связан ли граф с левой\правой стеной
    public bool rightWall = false;

    public graph(int color)
    {
        this.color = color;
    }
}


public class endGame : MonoBehaviour
{
    public List<graph> graphList;
    public cell[,] masCell = new cell[22, 12];
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
        masCell[idx, idy] = newcell;

        checkCellinGraph(newcell);
    }

    public void checkCellinGraph(cell curcell)
    {
        int curx = curcell.idx;
        int cury = curcell.idy;
        int curcolor = curcell.color;

        graph newgraph = new graph(curcolor);//сделать добавление в новый граф текущей ячейки, потом проверка и добавление ячеек в граф
        graphList.Add(newgraph);
        int idgraph = graphList.Count - 1;
        graphList[graphList.Count - 1].id = idgraph;//задаём id созданному графу
        masCell[curx, cury].graphnumber = idgraph;

        //проверка соседей и обновление графов
        if (masCell[curx - 1, cury].color == curcolor)//сверху слева
        {
            int graphnum = masCell[curx - 1, cury].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Length; i++)//проходим по всем ячейкам находящимся в том же графе, что и сосед только что поставленной ячейки
            {
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        if (masCell[curx + 1, cury].color == curcolor)//справа снизу
        {
            int graphnum = masCell[curx + 1, cury].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Length; i++)
            {
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        if (masCell[curx, cury - 1].color == curcolor)//справа
        {
            int graphnum = masCell[curx, cury - 1].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Length; i++)
            {
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        if (masCell[curx, cury + 1].color == curcolor)//слева
        {
            int graphnum = masCell[curx, cury + 1].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Length; i++)
            {
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        if (masCell[curx - 1, cury - 1].color == curcolor)//справа сверху
        {
            int graphnum = masCell[curx - 1, cury - 1].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Length; i++)
            {
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        if (masCell[curx + 1, cury + 1].color == curcolor)//слева снизу
        {
            int graphnum = masCell[curx + 1, cury + 1].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Length; i++)
            { 
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        //проверка соседей и обновление графов


    }
}
