using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        public float speed = 5f;
        public float topBoundary;
        public float bottomBoundary;

         public float leftBoundary;
        public float rightBoundary;

        [SerializeField]
        private GameObject playerLaser;

        [SerializeField]
        private Transform attackPoint;

        public float attackTimer = 0.35f;
        public float currentAttackTimer;
        private bool canAttack;


        // Start is called before the first frame update
        void Start()
        {
                currentAttackTimer = attackTimer;
        }

        // Update is called once per frame
        void Update()
        {
                MovePlayer();
                Attack();
        }

        void MovePlayer()
        {
            if(Input.GetAxisRaw("Vertical") > 0f)
            {
                        Vector3 temp = transform.position;
                        temp.y += speed * Time.deltaTime;

                        if(temp.y > topBoundary)
                        {
                            temp.y = topBoundary;
                        }

                        transform.position = temp;

            }
            if(Input.GetAxisRaw("Vertical") < 0f)
            {
                        Vector3 temp = transform.position;
                        temp.y -= speed * Time.deltaTime;

                         if(temp.y < bottomBoundary)
                        {
                            temp.y = bottomBoundary;
                        }

                        transform.position = temp;
            }

            if(Input.GetAxisRaw("Horizontal") > 0f)
            {
                        Vector3 temp = transform.position;
                        temp.x += speed * Time.deltaTime;

                         if(temp.x > rightBoundary)
                        {
                            temp.x = rightBoundary;
                        }

                        transform.position = temp;
            }

             if(Input.GetAxisRaw("Horizontal") < 0f)
            {
                        Vector3 temp = transform.position;
                        temp.x -= speed * Time.deltaTime;

                         if(temp.x < leftBoundary)
                        {
                            temp.x = leftBoundary;
                        }

                        transform.position = temp;
            }

        }

        void Attack()
        {
                attackTimer += Time.deltaTime;
                if(attackTimer > currentAttackTimer)
                {
                    canAttack = true;
                }

                if(Input.GetKeyDown(KeyCode.Space))
               {
                        if (canAttack)
                        {
                                canAttack = false;
                                attackTimer = 0f;

                                Instantiate(playerLaser, attackPoint.position, Quaternion.AngleAxis(-90, Vector3.forward));
                        }
                }
        }

        
}
