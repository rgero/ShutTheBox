using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] dices;
    public GameObject ValidMoveText;
    private GameObject cameraGame;
    bool rollingDice = false;
    bool needToUpdateBoard = false;
    int currentDice = 0;
    float timeBetween = 0.0f;

    public bool NeedToRoll;

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
            needToUpdateBoard = true;
            NeedToRoll = false;
        }

        if (rollingDice)
        {
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

    public List<int> GetDiceResult()
    {
        List<int> list = new List<int>();

        int total = 0;
        foreach(GameObject dice in dices)
        {
            int currentValue = dice.GetComponent<Die_d6>().value;
            list.Add(currentValue);
            total += currentValue;
        }

        list.Add(total);

        return list;
    }
}
