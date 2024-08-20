using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0;
    private bool isGameActive;
    private float timeGameStarted;

    public int Score { get => score; set => score = value; }
    public bool IsGameActive 
    { 
        get => isGameActive; 
        set 
        {
            isGameActive = value;
            if (!isGameActive)
            {
                ResetScore();
            }
            else
            {
                timeGameStarted = Time.time;
            }
        }
    }

    public float TimeGameStarted { get => timeGameStarted; }

    public void IncreaseScore()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            IncreaseScore();
        }
    }
}
