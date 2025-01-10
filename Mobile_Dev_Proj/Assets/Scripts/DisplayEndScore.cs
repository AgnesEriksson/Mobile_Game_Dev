using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayEndScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = ScoreManager.Instance.DisplayScore();
    }
}
