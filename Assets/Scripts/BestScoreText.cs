using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreText : MonoBehaviour
{
    public GameObject bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.GetComponent<Text>().text = "Best Score so far: " + ScoreManager.Instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
