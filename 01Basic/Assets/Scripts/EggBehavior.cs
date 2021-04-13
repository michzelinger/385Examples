using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EggBehavior : MonoBehaviour
{
    public float eggDamage = 25f;
    public float kEggSpeed = 40f;
    
    private const int kLifeTime = 300;
    private int mLifeCount = 0;
    // Start is called before the first frame update
    void OnBecameInvisible()
    {
        Destroy(transform.gameObject);
        mLifeCount--;
    }
    void Start()
    {   
        mLifeCount = kLifeTime;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime);
    }
    
     private void OnTriggerEnter2D(Collider2D collision)
   {
      
      if(collision.gameObject.tag == "Enemy")
      {
            EnemyBehavior enemy = collision.gameObject.GetComponent<EnemyBehavior>();
            Debug.Log("Here x Plane: OnTriggerEnter2D");
            enemy.TakeDamage(eggDamage);
       //  mPlanesTouched++;
     //    mEnemyCountText.text = "Planes touched " + mPlanesTouched;
           // enemyKill.TakeDamage(eggDamage);
            Destroy(gameObject);
      }
   }
    

}
