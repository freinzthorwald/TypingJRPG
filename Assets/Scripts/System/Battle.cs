using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private List<Enemy> EnemyList;

    void Awake()
    {
        EnemyList = new List<Enemy>();
        EnemyList.Add(new Enemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
