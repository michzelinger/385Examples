using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameController mGameGameController = null;
    public float enemyHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        mGameGameController = FindObjectOfType <GameController>();
        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateColor()
    {
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        Color c = s.color;
        const float delta = 0.01f;
        c.r -= delta;
        c.a -= delta;
        s.color = c;
        Debug.Log("Plane: Color = " + c);

        if (c.a <= 0.0f)
        {
            Sprite t = Resources.Load<Sprite>("Textures/Egg");   // File name with respect to "Resources/" folder
            s.sprite = t;
            s.color = Color.white;
        }
    }
     public void TakeDamage(float amount)
     {
         Debug.Log("Enemy Health: " + enemyHealth);
         enemyHealth -= amount;
         
         if (enemyHealth <= 0)
         {
             Die();
         }
         else
         {
            UpdateColor();
         }
     }
     void Die()
     {
         Destroy(gameObject);
         mGameGameController.EnemyDestroyed();
     }
}
