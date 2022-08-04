using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadGenerator : MonoBehaviour
{
    private List<GameObject> ReadyRoad = new List<GameObject>();
    [Header("Массив дорог")]              public GameObject[] RoadTiles;
    [Header("Дистанция между дорогами")]  public float DistanceBetweenRoads;
    [Header("Текущая длина дороги")]      public int CurrentLenght;
    [Header("Максимальная длина дороги")] public int MaxLenght;
    [Header("Скорость дороги")] public int speedRoad = 5;

    [Header("Максимальная позиция удаления")]
    public float maxPositionZ = -15;

    [Header("Зона ожидания")] public Vector3 WaitingZone = new Vector3(0, 0, -40);
    private bool isGeneration = true;
    private int currentRoadNumber = -1;
    private int previousRoadNumber = -1;
    public bool[] roadNumbers;
    


    private void FixedUpdate()
    {
        if (isGeneration)
        {
            if (CurrentLenght != MaxLenght)
            {
                currentRoadNumber = Random.Range(0, RoadTiles.Length); 
                if (currentRoadNumber != previousRoadNumber)
                {
                    if (currentRoadNumber < RoadTiles.Length/2)
                    {
                        if (roadNumbers[currentRoadNumber] != true)
                        {
                            RoadCreation();
                        }
                    }
                    else if (currentRoadNumber >=RoadTiles.Length/2)
                    {
                        if (roadNumbers[currentRoadNumber] != true)
                        {
                            RoadCreation();
                        }
                    }
                }
            }
        }
        MovingRoad();
        if (ReadyRoad.Count !=0)
        {
            RemovingRoad();
        }
    }

    private void RoadCreation()
    {
        if (ReadyRoad.Count>0)
        {
            RoadTiles[currentRoadNumber].transform.localPosition = ReadyRoad[ReadyRoad.Count - 1].transform.position +
                                                                   new Vector3(0f, 0f, DistanceBetweenRoads);
        }
        else if (ReadyRoad.Count == 0)
        {
            RoadTiles[currentRoadNumber].transform.localPosition = new Vector3(0f, 0f, 0f);
        }
        RoadTiles[currentRoadNumber].GetComponent<Road>().number = currentRoadNumber;
        roadNumbers[currentRoadNumber] = true;
        previousRoadNumber = currentRoadNumber;
        ReadyRoad.Add(RoadTiles[currentRoadNumber]);
        CurrentLenght++;
    }

    private void MovingRoad()
    {
        foreach (var readyRoad in ReadyRoad)
        {
            readyRoad.transform.localPosition -= new Vector3(0f, 0f, speedRoad * Time.fixedDeltaTime);
        }
    }

    private void RemovingRoad()
    {
        if (ReadyRoad[0].transform.localPosition.z<maxPositionZ)
        {
            int i = ReadyRoad[0].GetComponent<Road>().number;
            roadNumbers[i] = false;
            ReadyRoad[0].transform.localPosition = WaitingZone;
            ReadyRoad.RemoveAt(0);
            CurrentLenght--;
        }
    }
}
