using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rules : MonoBehaviour
{
        public int health = 3;
        public GameObject[] hearts;

        void OnTriggerEnter2D() 
        {
                Debug.Log("Collision");
                Destroy(hearts[health - 1].gameObject);
                health--;

                if(health <= 0)
                {
                        Die(); 
                }
        }

        void Die() 
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
}
