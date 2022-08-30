using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTiles : MonoBehaviour
{
    public List<GameObject> tiles;

    // Start is called before the first frame update
    void Start()
    {
        var childTransforms = this.GetComponentsInChildren<Transform>();
        foreach(Transform childTransform in childTransforms)
        {
            if (childTransform.gameObject.name != this.transform.name)
            {
                tiles.Add(childTransform.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject tile in tiles)
            {
                tile.GetComponent<TileController>().ResetTile();
            }
        }
    }
}
