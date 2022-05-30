using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelStraightBonus : MonoBehaviour
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
        if(other.transform.parent.tag.Equals("Player1")) {
            gameScript.cancelStraight(1);
            gameObject.SetActive(false);
        }
        if(other.transform.parent.tag.Equals("Player2")) {
            gameScript.cancelStraight(2);
            gameObject.SetActive(false);
        }
    }
}

