using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

        public float speed = 5f;
        public float deactivationTimer = 4f;

        [HideInInspector]
        public bool isEnemyLaser = false;
        // Start is called before the first frame update
        void Start()
    {
        if(isEnemyLaser)
                {
                        speed *= -1f;
                }
        Invoke("DeactivateGameObject", deactivationTimer);
                
    }

    // Update is called once per frame
    void Update()
    {
                Move();
        }

    void Move()
    {
                Vector3 temp = transform.position;
                temp.x += speed * Time.deltaTime;
                transform.position = temp;
        }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target) 
    {
        if(target.tag == "Laser" || target.tag == "Enemy" || target.tag == "Player")
        {
                        gameObject.SetActive(false);
        }
    
    }
}
