using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject fishh;
    public GameObject barrier;
    public GameObject treePrefab;
    public GameObject projectilePrefab;
    int pos;
    int xp;
    private PlayerControl playerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("showing", 1, 1);
        InvokeRepeating("printing", 1, 1);
        InvokeRepeating("fishInstantiation", 1, 1);
        InvokeRepeating("displaying", 1, 1);
        playerScript = GameObject.Find("Penguin").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        xp = Random.Range(0, 61);
        pos = Random.Range(0, 60);
    }
    void showing()
    {
        if (playerScript.gameOver == false)
        {
            Instantiate(projectilePrefab, new Vector3(-35, 0, 250), projectilePrefab.transform.rotation);
        }
        
    }
    void printing()
    {
        if (playerScript.gameOver == false)
        {
            Instantiate(barrier, new Vector3(xp, 1.5f, 250), barrier.transform.rotation);
        }

    }
    void fishInstantiation()
    {
        if (playerScript.gameOver == false)
        {
            Instantiate(fishh, new Vector3(pos, 3, 100), fishh.transform.rotation);
        }

    }
    void displaying()
    {
        if (playerScript.gameOver == false)
        {
            Instantiate(treePrefab, new Vector3(90, 0, 250), treePrefab.transform.rotation);
        }

    }

}
