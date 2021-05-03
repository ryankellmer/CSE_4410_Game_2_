using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rules : MonoBehaviour
{
        public int health;

        public Image[] hearts;
        public Sprite redHeart;

        void Start()
        {
                ScoreManager.scoreValue = 0;
                Spawner.timer = 2f;
        }

        void Update() 
        {
                for (int i = 0; i < hearts.Length; i++)
                {
                        if(i <  health)
                        {
                                hearts[i].enabled = true;
                        }
                        else
                        {
                                hearts[i].enabled = false;
                        }
                }
        }

         void OnTriggerEnter2D() 
        {
                Debug.Log("Collision");
                health--;

                if(health == 0)
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
