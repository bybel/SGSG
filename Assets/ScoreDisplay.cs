using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    GameObject p1;
    GameObject p2;
    GameObject s1;
    GameObject s2;
    PlayerScore score1Script;
    PlayerScore score2Script;
    GameMechanics gameScript;
    // Start is called before the first frame update
    void Start()
    {
        gameScript = GameObject.FindGameObjectWithTag("GameMechanics").GetComponent<GameMechanics>();

        
    }

    // Update is called once per frame
    void Update()
    {

        if(gameScript.isPlaying) {
            p1 = GameObject.FindGameObjectsWithTag("Player1")[0];
            p2 = GameObject.FindGameObjectsWithTag("Player2")[0];
            s1 = GameObject.FindGameObjectsWithTag("score1")[0];
            s2 = GameObject.FindGameObjectsWithTag("score2")[0];

            score1Script = p1.GetComponent<PlayerScore>();
            score2Script = p2.GetComponent<PlayerScore>();
            s1.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1 : " + score1Script.getScore();
            s2.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 2 : " + score2Script.getScore();
        }
    }
}