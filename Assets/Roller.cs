using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] dices;
    private GameObject cameraGame;
    bool rollingDice = false;
    int currentDice = 0;
    float timeBetween = 0.0f;

    void Start()
    {
        cameraGame = FindObjectOfType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rollingDice = true;
        }

        if (rollingDice)
        {
            Debug.Log(timeBetween);
            timeBetween -= Time.deltaTime;
            if (timeBetween <= 0)
            {
                RollingDice(currentDice);
                currentDice++;
                timeBetween = 1.0f;
            }

            if (currentDice == dices.Length)
            {
                currentDice = 0;
                rollingDice = false;
                timeBetween = 0.0f;
            }
        }
    }

    void RollingDice(int currentDice)
    {
        GameObject d = dices[currentDice];
        d.transform.position = cameraGame.transform.position;
        d.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000);
        d.GetComponent<Rigidbody>().AddTorque(new Vector3(100, 200, 300));
    }
}
