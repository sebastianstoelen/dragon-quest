using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    public AreaEntrance areaEntrance;
    public string areaToLoad;
    public string areaTransitionName;
    public float waitToLoad = 1f;

    private bool shouldLoadAfterFade;
    
    // Start is called before the first frame update
    void Start()
    {
        areaEntrance.areaTransitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
       
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.CompareTag(PLAYER_TAG))
        {
        
            shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack();
            GameManager.instance.loadingBetweenAreas = true;
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
