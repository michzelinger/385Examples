using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class GameController : MonoBehaviour
{
    private int maxPlanes = 10;
    public int numberOfPlanes = 0;
    private int numberOfEnemiesKilled = 0;

    public Text mEggsCountText = null;
    public Text mEnemiesInTheWorld = null;

    public Text mEnemiesDestroyed = null;
    public int numEggsOnScreen = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q)) {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        if(numberOfPlanes < maxPlanes)
        {

            CameraSupport s = Camera.main.GetComponent<CameraSupport>();
            
            GameObject e = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject);
            Vector3 pos;
            pos.x = s.GetWorldBound().min.x + Random.value * s.GetWorldBound().size.x;
            pos.y = s.GetWorldBound().min.y + Random.value * s.GetWorldBound().size.y;
            pos.z = 0;
            e.transform.localPosition = pos;
            numberOfPlanes++;
            mEnemiesInTheWorld.text = "Number of Enemies " + numberOfPlanes;
        }
    }
    
    public void IncreaseNumEggs()
    {
        numEggsOnScreen++;
        mEggsCountText.text = "Eggs in world " + numEggsOnScreen;
    }

    public void EggDestroyed()
    {
        numEggsOnScreen--;
        mEggsCountText.text = "Eggs in world " + numEggsOnScreen;
    }
    public void EnemyDestroyed()
    {
        numberOfPlanes--;
        mEnemiesInTheWorld.text = "Number of Enemies " + numberOfPlanes;
        numberOfEnemiesKilled++;
        mEnemiesDestroyed.text = "Number of Enemies Killed " + numberOfEnemiesKilled;
    }

}
