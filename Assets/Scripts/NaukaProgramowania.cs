using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaukaProgramowania : MonoBehaviour
{
    private Transform camTransform;
    public GameObject directionLight;
    public Transform lightTransform;

    // Start is called before the first frame update
    void Start()
    {
        
        Character hero = new Character();
        
        Weapon huntingBow = new Weapon("£uk Myœliwski", 105);
        Weapon warBow = huntingBow;
        warBow.name = "£uk wojenny";
        warBow.damage = 155;

        //huntingBow.PrintWeaponStats();
        //warBow.PrintWeaponStats();

        Character hero2 = hero;
        hero2.Reset();

        Paladin knight = new Paladin("Sir Arthur", huntingBow);
        //knight.PrintStatsInfo();
        
        camTransform = this.GetComponent<Transform>();
        //Debug.Log(camTransform.localPosition);

        lightTransform = directionLight.GetComponent<Transform>();
        //Debug.Log(lightTransform.localPosition);
    }
  
}
