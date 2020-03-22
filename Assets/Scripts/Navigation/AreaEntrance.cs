using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string areaTransitionName;

    // Start is called before the first frame update
    void Start()
    {
        if (areaTransitionName == PlayerController.instance.areaTransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }

        UIFade.instance.FadeFromBlack();
        GameManager.instance.loadingBetweenAreas = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
