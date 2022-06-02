using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayColorBonus : MonoBehaviour
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
            if(gameScript.getColorInRound() <= 5) {
                gameScript.collected(1, "display", gameObject.tag);
            }
            gameObject.SetActive(false);
        }
        if(other.transform.parent.tag.Equals("Player2")) {
            if(gameScript.getColorInRound() <= 5) {
                gameScript.collected(2, "display", gameObject.tag);
            }
            gameObject.SetActive(false);
        }
    }
}
