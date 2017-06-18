using UnityEngine;

public class ResourceLoad
{
    //Sprites
    public static Sprite hpBar = Resources.Load<Sprite>("Sprites/UI/" + UISprite.EntityHPBar.ToString());
    //Prefabs
    public static GameObject machineGunTurret = Resources.Load<GameObject>("Prefabs/Entities/Turret");
}

/*
 public class A
 {
    static void Initlaize
    GameObject[]
    Sprite[]
 }
     
     
     
     */