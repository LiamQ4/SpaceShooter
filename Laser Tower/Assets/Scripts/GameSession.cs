using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    [SerializeField] int totalScore = 0;


    private void Awake()
    {
        SetUpSingleTon();
    }
    
    // Start is called before the first frame update
    void SetUpSingleTon()
    {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;

        if (numberGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return totalScore;
    }

    public void AddToScore(int enemyScore)
    {
        totalScore += enemyScore;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}