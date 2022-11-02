using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public int exp = 0;
    public Character()
    {
        name = "Nieprzypisana";
    }
    public Character(string name)
    {
        this.name = name;
    }
    
    public void Reset()
    {
        this.name = "Nieprzypisana";
        this.exp = 0;
    }
    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("Bohater: {0} - doœwiadczenie {1}", name, exp);
    }   
}


public class Paladin: Character
{
    public Paladin(string name) : base(name)
    { }
    public Weapon weapon;
    public Paladin(string name, Weapon weapon) : base(name)
    { 
    this.weapon = weapon;
    }
    public override void PrintStatsInfo()
    {
        Debug.LogFormat("Hej, {0} - weŸ swoj¹ broñ: {1}!", name, weapon.name);
    }
}
public struct Weapon
{
    public string name;
    public int damage;
    
    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }
    public void PrintWeaponStats()
    {
        Debug.LogFormat("Broñ: {0} - Si³a ra¿enia - {1}", name, damage);
    }
}