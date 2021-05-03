using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;

    public static GameController instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void UpdateScore()
    {
        scoreText.text = totalScore.ToString().PadLeft(4, '0');; 
        //Faz com que o scoreText receba o valor do Total Score
        //O .PadLeft vai manter os 0000 na numeração do Score
    }
    
}
