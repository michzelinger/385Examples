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
    private void UpdateColor(float amount)
    {
        float decreaseAmount = amount / 100f;
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        
        Color c = s.color;
        float delta = decreaseAmount;
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
         
         enemyHealth -= amount;
         Debug.Log("Enemy Health: " + enemyHealth);
         
         if (enemyHealth <= 0)
         {
             Die();
         }
         else
         {
            UpdateColor(amount);
         }
     }
     void Die()
     {
         Destroy(gameObject);
         mGameGameController.EnemyDestroyed();
     }
     
}
