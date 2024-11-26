using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{   public static GameController instance;
    public GameObject Player;
    public GameObject SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn (){
        Destroy(GameObject.FindWithTag("Player"));
        Instantiate(Player, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
       
    }

}
