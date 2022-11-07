using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    public float timeElapsed;

    public int enemiesCount;
    public List<Transform> enemies = new List<Transform>();

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        timeElapsed = Time.time;    
    }

    public void RefreshEnemiesCount()
    {
        enemiesCount = enemies.Count;
    }

}
