using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CarSpawner : MonoBehaviour
{
    public GameObject[] CarSpawners;
    public GameObject RoadGenerator;
    private float RoadLenght;
    private bool isSpawned = false;
    public float SpeedOfCars = 5f;
    public float DespawnZ = -5f;
    private float[] SpawnCoordinates = new float[] { -2.36f,-0.88f,0.79f,2.34f};
    private bool[] SpawnedCars = new bool[]{false,false,false,false};
    private int CountOfSpawnedCars=0;

    private void Awake()
    {
        RoadLenght = RoadGenerator.GetComponent<RoadGenerator>().CurrentLenght *
                     RoadGenerator.GetComponent<RoadGenerator>().DistanceBetweenRoads;
    }

    private void FixedUpdate()
    {
        
        if (!isSpawned)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (CountOfSpawnedCars<4)
                {
                    int r = Random.Range(1,3 );
                    if (r == 2)
                    {
                        CarSpawners[i].transform.localPosition = new Vector3(SpawnCoordinates[i] , 0, 15);
                        CountOfSpawnedCars++;
                        SpawnedCars[i] = true;

                    }
                }
            }
            isSpawned = true;
        }

        if (isSpawned)
        {
            for (int i = 0; i <=3; i++)
            {
                
                CarSpawners[i].transform.localPosition -= new Vector3(0, 0, SpeedOfCars*Time.fixedDeltaTime );
                if (CarSpawners[i].transform.localPosition.z <= DespawnZ || SpawnedCars[i]) 
                {
                    isSpawned = false;
                    CountOfSpawnedCars--;
                    SpawnedCars[i] = false;
                }
            } 
        }
        
    }
}
