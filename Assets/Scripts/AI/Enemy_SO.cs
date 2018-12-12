using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "AI/EnemyStats", order = 1)]
public class Enemy_SO : ScriptableObject {

    public float LookingRadius;
    public float AttackingRadius;
    public float PatrollingRadius;

    public int Enemy_HP;
    public int Enemy_AT;
    public float AttackRate;
}
