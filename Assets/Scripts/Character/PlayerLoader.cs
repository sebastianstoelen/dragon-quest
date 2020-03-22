using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject player;
    public float xPosition;
    public float yPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance == null)
        {
            Instantiate(player);
            player.transform.position = new Vector3(xPosition, yPosition, player.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
