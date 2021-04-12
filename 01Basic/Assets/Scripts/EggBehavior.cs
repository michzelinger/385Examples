using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EggBehavior : MonoBehaviour
{

   // private Camera mainCamera;
    public const float kEggSpeed = 40f;
    
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

}
