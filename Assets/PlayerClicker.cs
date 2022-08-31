using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClicker : MonoBehaviour
{
    public GameObject diceContainer;

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
                if(clickedObject.tag == "Tile")
                {
                    RollManager rollManager = diceContainer.GetComponent<RollManager>();
                    List<int> validOptions = rollManager.GetDiceResult();

                    int tileNumber = int.Parse(clickedObject.name);

                    if (validOptions.Contains(tileNumber) && !rollManager.NeedToRoll)
                    {
                        clickedObject.GetComponent<TileController>().ToggleMoving();
                        rollManager.NeedToRoll = true;
                    }
                }
            }
        }
    }
}
