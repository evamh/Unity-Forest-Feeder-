using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    private int scoreCount;
    private int totalNumRabbits;

    // subscribe to carrotDropped event
    public CarrotRabbitPairManager carrotRabbitPairManager;

    // Start is called before the first frame update
    void Start()
    {
        // find all instances of rabbits
        totalNumRabbits = GameObject.FindGameObjectsWithTag("Rabbit").Length;
        Debug.Log("totalNumRabbits: " + totalNumRabbits);

        scoreCount = 0;
        SetScoreText();

        carrotRabbitPairManager.fedRabbit?.AddListener(UpdateScore);
    }

    public void UpdateScore()
    {
        scoreCount++;
        SetScoreText();

        if(scoreCount == totalNumRabbits)
        {
            SetGameOverText();
        }
    }

    void SetScoreText()
    {
        score.text = "Rabbits fed: " + scoreCount + " out of " + totalNumRabbits;
    }

    void SetGameOverText()
    {
        score.text = "All rabbits fed! :)";
    }

}
