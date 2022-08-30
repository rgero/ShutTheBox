using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.transform.gameObject;
                Debug.Log(clickedObject.name);
                if (clickedObject.tag == "Dice")
                {
                    int dieUp = clickedObject.GetComponent<Die_d6>().value;
                    Debug.Log("The side facing up is: " + dieUp.ToString());
                }

                if(clickedObject.tag == "Tile")
                {
                    clickedObject.GetComponent<TileController>().ToggleMoving();
                }
            }
        }
    }
}
