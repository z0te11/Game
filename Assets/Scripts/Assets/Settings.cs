using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Settings : ScriptableObject, ISettings
{
    public GameObject player;
    public GameObject enemy;
    public int healthEnemy;
    public int damageEnemy;
    public float delaySpawn;

    public GameObject Player => player;
    public GameObject Enemy => enemy;
    public int HealthEnemy => healthEnemy;
    public int DamageEnemy => damageEnemy;
    public float DelaySpawn => delaySpawn;
}
