using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

        public float speed = 5f;
        public float rotateSpeed = 50f;
        public bool canShoot;
        public bool canRotate;
        private bool canMove = true;

        public float boundX = -11f;
        public Transform attackPoint;
        public GameObject laserPrefab;
        

        // Start is called before the first frame update
        void Awake()
    {
    


    }

    // Update is called once per frame
    void Update()
    {
                Move();
        }

        void Start ()
        {
            if(canRotate)
            {
                if(Random.Range(0, 2) > 0)
                {
                                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                                rotateSpeed *= -1f;
                        }
            }

            if(canShoot)
                {
                    Invoke("Shoot", Random.Range(1f, 3f)); 
                }
        }

    void Move() 
    {
        if(canMove) 
        {
                        Vector3 temp = transform.position;
                        temp.x -= speed * Time.deltaTime;
                        transform.position = temp;

                        if(temp.x < boundX)
                        {
                            gameObject.SetActive(false);
                        }
                }
    }

    void RotateEnemy() 
    {
        if(canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }

    void Shoot() 
    {
                GameObject laser = Instantiate(laserPrefab, attackPoint.position, Quaternion.AngleAxis(90f, Vector3.forward));
                laser.GetComponent<Laser>().isEnemyLaser = true;

                if(canShoot)
                {
                    Invoke("Shoot", Random.Range(1f, 3f)); 
                }
        }

        void OnTriggerEnter2D(Collider2D target) 
    {
        if(target.tag == "Laser" || target.tag == "Player")
        {
            canMove = false;
            if(canShoot)
            {
                canShoot = false;
                CancelInvoke("Shoot");
            }

            Invoke("TurnOffGameObject", 0.05f);
        }
    }

    void TurnOffGameObject() 
    {
        gameObject.SetActive(false);
    }
}
