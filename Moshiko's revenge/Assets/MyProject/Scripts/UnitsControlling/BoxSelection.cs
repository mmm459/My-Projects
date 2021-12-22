using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSelection : MonoBehaviour
{
    ControlingSystem controlingSystem;

    public RectTransform BoxVisual;

    Rect SelctionBox;

    Vector2 StartPosition;
    Vector2 EndPosition;

    void Start()
    {
        controlingSystem = GetComponent<ControlingSystem>();
        StartPosition = Vector2.zero;
        EndPosition = Vector2.zero;
        DrawBox();
    }


    void Update()
    {
        //check where you clicked first to draw the box from there
        if (Input.GetMouseButtonDown(0))
        {
            StartPosition = Input.mousePosition;
        }

        //draw the box while holding the button
        if (Input.GetMouseButton(0))
        {
            EndPosition = Input.mousePosition;
            DrawBox();
        }


        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject unit in controlingSystem.UnitsInTheGame)
            {//contain is func inside Rect and can identify what colliders are in the box
                if (SelctionBox.Contains(Camera.main.WorldToScreenPoint(unit.transform.position)))
                {
                    //check that the object inside the box nor allready selected 
                    if(unit.GetComponent<UnitOrderManager>().enabled == false)
                    {
                        controlingSystem.BoxSelection(unit);
                    }
                }
            }
            //clear the box, both vectors are zero
            StartPosition = Vector2.zero;
            EndPosition = Vector2.zero;
            DrawBox();
        }
    }
    

    //draw a box and creat the rect to check what is inside the box
    public void DrawBox()
    {
        Vector2 BoxStart = StartPosition;
        Vector2 BoxEnd = EndPosition;

        Vector2 BoxCenter = (BoxStart + BoxEnd) / 2;

        BoxVisual.position = BoxCenter;

        Vector2 BoxSize = new Vector2(Mathf.Abs(BoxStart.x - BoxEnd.x), Mathf.Abs(BoxStart.y - BoxEnd.y));

        BoxVisual.sizeDelta = BoxSize;

        SelctionBox.center = BoxCenter;

        SelctionBox.size = BoxSize;
    }
}
