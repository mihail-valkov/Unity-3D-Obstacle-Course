using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreDisplay : MonoBehaviour
{
    //Textmeshpro object
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    private ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreText.text = "Bumps: " + scoreKeeper.Score;
        timeText.text = "Time: 0.00";
    }

    // Update is called once per frame
    void Update()
    {
        if (!scoreKeeper.IsGameActive)
        {
            return;
        }

        scoreText.text = "Bumps: " + scoreKeeper.Score;
        timeText.text = "Time: " + (Time.time - scoreKeeper.TimeGameStarted).ToString("F2");
    }
}
