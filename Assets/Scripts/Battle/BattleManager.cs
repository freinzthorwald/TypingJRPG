using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BattleManager : MonoBehaviour
{
    public List<Enemy> Enemies { get; private set; }
    public GameObject EnemyPrefab;
    public GameObject PlayerPrefab;

    public void Awake()
    {
        CreateEnemies();
        CreatePlayer();
    }

    public void Update()
    {
        //Call everyone's UpdateTurnTimer here.
        //If you do it in each object's Update then you'll be handling TurnTimer when not in combat
        //Even if this means doing a constant check to see if you do should handle it
    }

    private void CreateEnemies()
    {
        Enemies = new List<Enemy>();
        GameObject enemyObject = Instantiate(EnemyPrefab);
        if (!enemyObject.TryGetComponent(out enemyObject))
        {
            //Debug.LogError("Could not find quest.");
            return;
        }
        Enemy Enemy = enemyObject.GetComponent<Enemy>();
        Enemy.Setup();
        Enemies.Add(Enemy);
    }

    private void CreatePlayer()
    {
        //I'll sort this out when player controls and the like are added.
        /*
        GameObject playerObject = Instantiate(PlayerPrefab);
        if (!playerObject.TryGetComponent(out playerObject))
        {
            Debug.LogError("Could not find quest.");
            return;
        }
        Enemy Enemy = playerObject.GetComponent<Enemy>();
        Enemy.Setup();
        Enemies.Add(Enemy);
        */
    }
}
