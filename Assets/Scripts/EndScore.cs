using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScore : MonoBehaviour
{
    [SerializeField] IntVariable Score;
    private TMP_Text endScore;

    private void Start()
    {
        if (this.gameObject.TryGetComponent(out TMP_Text text)) endScore = text;   
    }

    private void Update()
    {
        endScore.text = "Final Score: " + Score.value;
        
    }
}
