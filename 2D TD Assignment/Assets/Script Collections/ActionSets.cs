using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class ActionSets
{
    public static Action<Enemy> OnEnemyHit;
    public static Action<Enemy> OnEnemyKilled;
    public static Action<Enemy, float> OnProjectileHit;
    public static Action<Enemy> OnEnemyDestroyed;
}
