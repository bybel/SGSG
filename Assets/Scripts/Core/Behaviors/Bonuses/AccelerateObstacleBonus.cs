using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateObstacleScript : MonoBehaviour
{
    public GameObject theGame;
    private GMKMechanics gameScript;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = theGame.GetComponent<GMKMechanics>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.parent.tag.Equals("Player1") || other.transform.parent.tag.Equals("Player2")){
            gameScript.accelerateObstacleNextRound();
            gameObject.SetActive(false);
        }
    }
}
