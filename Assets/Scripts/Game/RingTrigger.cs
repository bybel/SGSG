using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    private bool[] contained;
    public GameObject theGame;
    private Tutorials tuto;

    // Start is called before the first frame update
    void Start()
    {
       contained = new bool[2];
       tuto = theGame.GetComponent<Tutorials>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider other){
        if(tuto.active && (tuto.bonusState == BonusStates.color || tuto.basicState == BasicStates.red) && gameObject.tag.Equals("sRed")){
            tuto.reached();
        }
        if(other.transform.parent.tag.Equals("Player1")){
            contained[0] = true;
        } 
        if (other.transform.parent.tag.Equals("Player2")){
            contained[1] = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.transform.parent.tag.Equals("Player1")){
            contained[0] = false;
        } 
        if (other.transform.parent.tag.Equals("Player2")){
            contained[1] = false;
        }
    }

    public bool contains(int player)
    {
        return contained[player];
    }
}