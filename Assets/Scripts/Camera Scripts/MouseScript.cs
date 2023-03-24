using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public Texture2D cursurTexture;
    private CursorMode mode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;

    public GameObject mousePoint;
    private GameObject insantiadMouse;


    void Start()
    {
        
    }

    
    void Update()
    {
      //  Cursor.SetCursor(cursurTexture, hotSpot, mode);

        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider is TerrainCollider)
                {
                    Vector3 temp = hit.point;
                    temp.y = 0.25f;
                    Instantiate(mousePoint, temp, Quaternion.identity);

                    if(insantiadMouse == null)
                    {
                        insantiadMouse = Instantiate(mousePoint) as GameObject;
                        insantiadMouse.transform.position = temp;
                    }
                    else
                    {
                        Destroy(insantiadMouse);
                        insantiadMouse = Instantiate(mousePoint) as GameObject;
                        insantiadMouse.transform.position = temp;
                    }
                }
            }


        }


    }



} // class









