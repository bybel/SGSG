using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelStraightBonus : MonoBehaviour
{
    public GameObject theGame;
    private GMKMechanics gameScript;
    private Tutorials tuto;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = theGame.GetComponent<GMKMechanics>();
        tuto = theGame.GetComponent<Tutorials>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(tuto.active) {
            if(other.transform.parent.tag.Equals("Player1")){
                tuto.collected("cancel");
                gameObject.SetActive(false);
            }
            return;
        }
        if(other.transform.parent.tag.Equals("Player1")) {
            gameScript.collected(1, "cancel", gameObject.tag);
            gameObject.SetActive(false);
        }
        if(other.transform.parent.tag.Equals("Player2")) {
            gameScript.collected(2, "cancel", gameObject.tag);
            gameObject.SetActive(false);
        }
    }
}

