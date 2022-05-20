using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWinner : MonoBehaviour
{
    int s1;
    int s2;
    public GameObject theGame;
    GMKMechanics mechanicsScript;
    TMPro.TextMeshProUGUI winner;

    // Start is called before the first frame update
    void Start()
    {
        mechanicsScript = theGame.GetComponent<GMKMechanics>();
        winner = GameObject.FindGameObjectsWithTag("winner")[0].GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        s1 = mechanicsScript.p1Score;
        s2 = mechanicsScript.p2Score;
        if(s1 < s2) {
            winner.text = "Player 2";
        }
        else if(s1 > s2) {
            winner.text = "Player 1";
        }
        else {

            winner.text = "Everybody, it's a tie";

        }
    }
}
