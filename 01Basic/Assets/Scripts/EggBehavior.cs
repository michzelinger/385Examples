using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{

    public const float kEggSpeed = 40f;

    private const int kLifeTime = 300;

    private int mLifeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        mLifeCount = kLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime);
        mLifeCount--;
        if(mLifeCount <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
}
