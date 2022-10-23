using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapInformation : MonoBehaviour
{
    public float EnemySpawnTime;
    public float GameSessionTime;
    public int FinalScore;

    void Start()
    {
       DontDestroyOnLoad(gameObject);
    }

    public void DestroyObject()
    { 
        Destroy(gameObject);
    }
}
