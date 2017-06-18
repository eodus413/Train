using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetter : MonoBehaviour
{
    [SerializeField]
    Stages currentStage;
    [SerializeField]
    private int stageNumber;
    Background.FieldGenerator   filedGenterator;
    Background.Parallaxing      parallaxing;
    void Start()
    {
        GameObject parent = GameObject.Find("Backgrounds");

        filedGenterator = parent.GetComponent<Background.FieldGenerator>();

        parallaxing = parent.GetComponent<Background.Parallaxing>();

        StageStart(currentStage);
    }
    public void StageStart(Stages stage)
    {
        this.currentStage = stage;
        filedGenterator.Initialize(currentStage);
        parallaxing.Initialize(currentStage);

        GameObject spawner = Resources.Load<GameObject>("Prefabs/Spawner/" + stage.ToString());
        Instantiate(spawner,null);
    }
}
