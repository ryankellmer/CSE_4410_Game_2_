using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
        public float bottomBound = -4.3f;
        public float topBound = 4.3f;

        public GameObject enemyPrefab;
        public GameObject asteroidPrefab;
        public static float timer;

        public bool isAsteroid = false;

        // Start is called before the first frame update
        void Start()
    {
                Invoke("SpawnEnemy", timer);
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy() 
    {
                float positionY = Random.Range(bottomBound, topBound);
                Vector3 temp = transform.position;
                temp.y = positionY;

                if(!isAsteroid)
                {
                         Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 90f));
                        isAsteroid = true;
                }
               else
               {
                       Instantiate(asteroidPrefab, temp, Quaternion.Euler(0f, 0f, 90f));
                       isAsteroid = false;
               }

                Invoke("SpawnEnemy", timer);
        }
}
