using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenUpBehavior : MonoBehaviour
{

   public Text mEnemyCountText = null;
   public float mPlanesTouched = 0;
   public float speed = 20f;
   public float acceleration = 100f;
   public float maxSpeed = 60f;
   public float mHeroRotateSpeed = 90f / 2f;

   public float shootingRate = 0.2f;
   private float timeStamp;

   private GameController mGameGameController = null;
   public bool mFollowMousePosition = true;
   // Start is called before the first frame update
   void Start()
   {
      mGameGameController = FindObjectOfType <GameController>();
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.M))
      {
         mFollowMousePosition = !mFollowMousePosition;
      }

      Vector3 pos = transform.position;

      if (mFollowMousePosition)
      {
         pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         //Debug.Log("Position is " + pos);
         pos.z = 0f;
      }

      else
      {
         if (Input.GetKey(KeyCode.W))
         {
            if(speed < 60f)
            {
               speed += Time.deltaTime * acceleration;
            }
            else if(speed > 60f)
            {
               speed = 60f;
            }
            pos += ((speed * Time.smoothDeltaTime) * transform.up);
         }

         if (Input.GetKey(KeyCode.S))
         {
            pos -= ((speed * Time.smoothDeltaTime) * transform.up);
         }

         if (Input.GetKey(KeyCode.D))
         {
            transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
         }

         if (Input.GetKey(KeyCode.A))
         {
            transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
         }
      }
      if (Time.time >= timeStamp && Input.GetKey(KeyCode.Space))
      {
          GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
          e.transform.localPosition = transform.localPosition;
          e.transform.rotation = transform.rotation;
          Debug.Log("Spawn Eggs:" + e.transform.localPosition);
          timeStamp = Time.time + shootingRate;
      }
      transform.position = pos;
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {
      Debug.Log("Here x Plane: OnTriggerEnter2D");
      mPlanesTouched++;
      mEnemyCountText.text = "Planes touched " + mPlanesTouched;
      Destroy(collision.gameObject);
      mGameGameController.EnemyDestroyed();
   }

   private void OnTriggerStay2D(Collider2D collision)
   {
      Debug.Log("Plane On TriggerStay");
   }

}


