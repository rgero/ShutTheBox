using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValidMoveDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DiceContainer;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        List<int> valid = DiceContainer.GetComponent<RollManager>().GetDiceResult();
        UpdateValidMoves(valid);
    }

    public void UpdateValidMoves(List<int> valid)
    {
        string validString = string.Join(", ", valid);
        this.textMesh.text = "Valid Moves\n" + validString;
    }
}
