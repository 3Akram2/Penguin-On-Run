using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    public float speed = 100;
    private PlayerControl playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Penguin").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.gameOver == false)
        { 
         transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
       
    }
}
