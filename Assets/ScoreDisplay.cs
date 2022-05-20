using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject theGame;
    private GameObject p1;
    private GameObject p2;
    private GameObject s1;
    private GameObject s2;
    private PlayerScore score1Script;
    private PlayerScore score2Script;
    private GMKMechanics gameScript;
    // Start is called before the first frame update
    void Start()
    {
        gameScript = theGame.GetComponent<GMKMechanics>();
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
            s1.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1 : " + gameScript.p1Score;
            s2.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 2 : " + gameScript.p2Score;
        }
    }
}