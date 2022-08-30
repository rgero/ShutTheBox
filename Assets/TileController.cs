using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    bool isStanding = true;
    bool shouldMove = false;
    double rotationAmount = 90;
    float direction;
    public Vector3 bottomPosition;
    public float movementSpeed;

    void Start()
    {
        movementSpeed = 70.0f;
        bottomPosition = transform.position;
        bottomPosition.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            float rotateAmount = movementSpeed * Time.deltaTime;
            rotationAmount -= rotateAmount;
            transform.RotateAround(bottomPosition, Vector3.right, rotateAmount * direction);
            if (rotationAmount <= 0)
            {
                shouldMove = false;
                isStanding = !isStanding;
                rotationAmount = 90;
            }
        }
    }

    public void ToggleMoving()
    {
        shouldMove = true;
        direction = (isStanding) ? -1 : 1;
    }
}
