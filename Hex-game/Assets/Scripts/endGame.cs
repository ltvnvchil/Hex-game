using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cell
{
    public int id;
    public int idx;
    public int idy;
    public int color = 0;
    public bool isFull = false;
    public int whichWall = 0;
    public int graphnumber = -1;

    public cell()
    {
        this.color = 0;
    }

    public cell(int idx, int idy)
    {
        this.idx = idx;
        this.idy = idy;
    }

    public cell(int id, int idx, int idy, int color, int whichWall)
    {
        this.id = id;
        this.idx = idx;
        this.idy = idy;
        this.color = color;
        this.isFull = true;
        this.whichWall = whichWall;      
    }
}

public class graph
{
    public int color;
    public int id;
    public List<int> idx = new List<int>();
    public List<int> idy = new List<int>();
    public bool leftWall = false;//связан ли граф с левой\правой стеной
    public bool rightWall = false;

    public graph(int color)
    {
        this.color = color;
    }
}


public class endGame : MonoBehaviour
{
    public GameObject CanvasWin;
    public GameObject RedWin;
    public GameObject BlueWin;
    public List<graph> graphList;
    public cell[,] masCell;// = new cell[23, 13];
    private bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!isStart)
        {
            graphList = new List<graph>();
            masCell = new cell[23, 13];
            for (int i = 0; i < 23; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    cell newcell = new cell(i, j);
                    masCell[i, j] = newcell;
                }
            }
            isStart = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newCell(int id, int idx, int idy, int color, int whichWall)
    {
        cell newcell = new cell(id, idx, idy, color, whichWall);
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
        graphList[graphList.Count - 1].idx.Add(curx);//задаём в созданный граф 
        graphList[graphList.Count - 1].idy.Add(cury);//координаты x и y только что созданной ячейки
        masCell[curx, cury].graphnumber = idgraph;//задаём id графа для ячейки в массиве

        //проверка соседей и обновление графов

        //int graphnum1 = masCell[curx - 1, cury].graphnumber;
        //Debug.Log("debug " + masCell[curx - 1, cury].color + " " + curcolor+" ");

        if (masCell[curx - 1, cury].color == curcolor)//сверху слева
        {
            int graphnum = masCell[curx - 1, cury].graphnumber;
            Debug.Log(graphnum);
            for (int i = 0; i < graphList[graphnum].idx.Count; i++)//проходим по всем ячейкам находящимся в том же графе, что и сосед только что поставленной ячейки
            {
                //Debug.Log("зашли в цикл "+i+" "+ graphList[graphnum].idx.Count);
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                int prevGraphNumber = masCell[curXid, curYid].graphnumber;//номер предыдущего графа ячейки, которая присоединяется к новому графу от только созданной ячейки
                if (graphList[prevGraphNumber].leftWall)
                    graphList[graphList.Count - 1].leftWall = graphList[prevGraphNumber].leftWall;
                if (graphList[prevGraphNumber].rightWall)
                    graphList[graphList.Count - 1].rightWall = graphList[prevGraphNumber].rightWall;
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        if (masCell[curx + 1, cury].color == curcolor)//справа снизу
        {
            int graphnum = masCell[curx + 1, cury].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Count; i++)
            {
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                int prevGraphNumber = masCell[curXid, curYid].graphnumber;//номер предыдущего графа ячейки, которая присоединяется к новому графу от только созданной ячейки
                if (graphList[prevGraphNumber].leftWall)
                    graphList[graphList.Count - 1].leftWall = graphList[prevGraphNumber].leftWall;
                if (graphList[prevGraphNumber].rightWall)
                    graphList[graphList.Count - 1].rightWall = graphList[prevGraphNumber].rightWall;
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        if (masCell[curx, cury - 1].color == curcolor)//справа
        {
            int graphnum = masCell[curx, cury - 1].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Count; i++)
            {
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                int prevGraphNumber = masCell[curXid, curYid].graphnumber;//номер предыдущего графа ячейки, которая присоединяется к новому графу от только созданной ячейки
                if (graphList[prevGraphNumber].leftWall)
                    graphList[graphList.Count - 1].leftWall = graphList[prevGraphNumber].leftWall;
                if (graphList[prevGraphNumber].rightWall)
                    graphList[graphList.Count - 1].rightWall = graphList[prevGraphNumber].rightWall;
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        if (masCell[curx, cury + 1].color == curcolor)//слева
        {
            int graphnum = masCell[curx, cury + 1].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Count; i++)
            {
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                int prevGraphNumber = masCell[curXid, curYid].graphnumber;//номер предыдущего графа ячейки, которая присоединяется к новому графу от только созданной ячейки
                if (graphList[prevGraphNumber].leftWall)
                    graphList[graphList.Count - 1].leftWall = graphList[prevGraphNumber].leftWall;
                if (graphList[prevGraphNumber].rightWall)
                    graphList[graphList.Count - 1].rightWall = graphList[prevGraphNumber].rightWall;
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        if (masCell[curx - 1, cury - 1].color == curcolor)//справа сверху
        {
            int graphnum = masCell[curx - 1, cury - 1].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Count; i++)
            {
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                int prevGraphNumber = masCell[curXid, curYid].graphnumber;//номер предыдущего графа ячейки, которая присоединяется к новому графу от только созданной ячейки
                if (graphList[prevGraphNumber].leftWall)
                    graphList[graphList.Count - 1].leftWall = graphList[prevGraphNumber].leftWall;
                if (graphList[prevGraphNumber].rightWall)
                    graphList[graphList.Count - 1].rightWall = graphList[prevGraphNumber].rightWall;
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }
        if (masCell[curx + 1, cury + 1].color == curcolor)//слева снизу
        {
            int graphnum = masCell[curx + 1, cury + 1].graphnumber;
            for (int i = 0; i < graphList[graphnum].idx.Count; i++)
            {
                int curXid = graphList[graphnum].idx[i];
                int curYid = graphList[graphnum].idy[i];
                int prevGraphNumber = masCell[curXid, curYid].graphnumber;//номер предыдущего графа ячейки, которая присоединяется к новому графу от только созданной ячейки
                if (graphList[prevGraphNumber].leftWall)
                    graphList[graphList.Count - 1].leftWall = graphList[prevGraphNumber].leftWall;
                if (graphList[prevGraphNumber].rightWall)
                    graphList[graphList.Count - 1].rightWall = graphList[prevGraphNumber].rightWall;
                masCell[curXid, curYid].graphnumber = idgraph;
            }
        }

        //проверка ячейки у стены ли она и указние в граф этого
        if (masCell[curx, cury].color == 1)//если красная ячейка
        {
            if (masCell[curx, cury].whichWall == 1 || masCell[curx, cury].whichWall == 5 ||
                masCell[curx, cury].whichWall == 6)//если у левой красной(первой) границы
            {
                graphList[graphList.Count - 1].leftWall = true;
            }
            if (masCell[curx, cury].whichWall == 4 ||
                masCell[curx, cury].whichWall == 7 || masCell[curx, cury].whichWall == 8)//если у правой красной(первой) границы
            {
                graphList[graphList.Count - 1].rightWall = true;
            }
        }
        else if (masCell[curx, cury].color == 2)//если синяя ячейка
        {
            if (masCell[curx, cury].whichWall == 2 || masCell[curx, cury].whichWall == 5 ||
                masCell[curx, cury].whichWall == 7)//если у правой синей(первой) границы
            {
                graphList[graphList.Count - 1].rightWall = true;
            }
            if (masCell[curx, cury].whichWall == 6 ||
                masCell[curx, cury].whichWall == 3 || masCell[curx, cury].whichWall == 8)//если у левой синей(первой) границы
            {
                graphList[graphList.Count - 1].leftWall = true;
            }
        }

        //проверка выиграла ли эта ячейка
        if (graphList[graphList.Count - 1].leftWall == true && graphList[graphList.Count - 1].rightWall == true)
        {
            CanvasWin.SetActive(true);
            if (graphList[graphList.Count - 1].color == 1)
                RedWin.SetActive(true);
            else
                BlueWin.SetActive(true);
            Debug.Log(" Winning cell! ");
        }
    }
}
