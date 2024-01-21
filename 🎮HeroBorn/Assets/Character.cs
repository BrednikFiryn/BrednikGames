using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public int exp = 0;

    public Character (string name)
    {
        this.name = name;
    }

    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("Start Character: {0}, exp {1}", name, exp);
    }
}

public struct Weapon
{
    public string name;
    public int damage;

    public Weapon (string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    public void PrintWeaponStatsInfo()
    {
        Debug.LogFormat("Weapon: {0} - {1} DMB", name, damage);
    }
}