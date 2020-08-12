using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tapOnSceen_Test : MonoBehaviour, IPointerDownHandler

{

    //public GameObject particle;
    public GameObject fieldcolorred;
    public GameObject fieldcolorblue;
    public GameObject fieldcolornext;
    public GameObject inst_obj;
    private nextMove move;
    public GameObject field1h;
    private bool isClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive!");
        //move = GetComponent<nextMove>();
        move = field1h.GetComponent<nextMove>();
        //Instantiate(fieldcolor);

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("I am working onPoinerDown!");
        //GameObject inst_obj = (GameObject)Instantiate(fieldcolor, new Vector3(transform.position.x - 5f, fieldcolor.transform.position.y, fieldcolor.transform.position.z), Quaternion.identity);
        if (!isClicked)
        {
            if (move.currentMove == 0)
            {
                inst_obj = Instantiate(fieldcolorred, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f), Quaternion.identity) as GameObject;
                move.currentMove = 1;
                isClicked = true;
            }
            else if (move.currentMove == 1)
            {
                inst_obj = Instantiate(fieldcolorblue, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f), Quaternion.identity) as GameObject;
                move.currentMove = 0;
                isClicked = true;
            }
        }
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
