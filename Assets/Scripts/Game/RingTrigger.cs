using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    private bool[] contained;

    // Start is called before the first frame update
    void Start()
    {
       contained = new bool[2];
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider other){
        if(other.tag.Equals("Player1")){
            contained[0] = true;
        } 
        if (other.tag.Equals("Player2")){
            contained[1] = true;
        }
    }

    void OnTriggerExit(Collider other){
        Debug.Log("*OEEEEE");
        if(other.tag.Equals("Player1")){
            contained[0] = false;
        } 
        if (other.tag.Equals("Player2")){
            contained[1] = false;
        }
    }
}