using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tapOnSceen_Test : MonoBehaviour, IPointerDownHandler

{

    //public GameObject particle;
    public GameObject fieldcolorred;
    public GameObject fieldcolorblue;
    private GameObject fieldcolornext;
    public GameObject inst_obj;
    private nextMove move;
    private endGame endgame;
    public GameObject field1h;
    private bool isClicked = false;
    public int id;
    public int idx;
    public int idy;
    public int whichWall = 0;//1-левый верх, 2 правый верх, 3 - левый низ, 4- правый низ, 5 - верхний угол, 6 -левый угол, 7 - правый угол, 8 - нижний угол

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("I am alive!");
        //move = GetComponent<nextMove>();
        move = field1h.GetComponent<nextMove>();
        endgame = field1h.GetComponent<endGame>();
             
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        //GameObject inst_obj = (GameObject)Instantiate(fieldcolor, new Vector3(transform.position.x - 5f, fieldcolor.transform.position.y, fieldcolor.transform.position.z), Quaternion.identity);
        if (!isClicked)
        {
            Debug.Log("I am working onPointerDown!");
            if (move.currentMove == 0)
            {
                inst_obj = Instantiate(fieldcolorred, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f), Quaternion.identity) as GameObject;
                checkGame( id,  idx,  idy,  1, whichWall);
                move.currentMove = 1;
                isClicked = true;

            }
            else if (move.currentMove == 1)
            {
                inst_obj = Instantiate(fieldcolorblue, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f), Quaternion.identity) as GameObject;
                checkGame( id,  idx,  idy,  2, whichWall);
                move.currentMove = 0;
                isClicked = true;

            }
        }
    }

    public void checkGame(int id, int idx, int idy, int color, int whichWall)
    {
        Debug.Log("Clicked cell "+ id+ " " + idx+ " " + idy+ " " + color + " " + whichWall);
        endgame.newCell(id, idx, idy, color, whichWall);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // что-то делать

                Debug.Log("I am working!");
                //GameObject inst_obj = (GameObject)Instantiate(fieldcolor, new Vector3(transform.position.x - 5f, fieldcolor.transform.position.y, fieldcolor.transform.position.z), Quaternion.identity);
                inst_obj = Instantiate(field2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;

            }
        }*/
    }

}
