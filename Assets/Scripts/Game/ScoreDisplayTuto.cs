using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplayTuto : MonoBehaviour
{
    public GameObject theGame;
    public GameObject s1;
    public GameObject s2;
    public GameObject streak1;
    public GameObject streak2;
    private Tutorials gameScript;
    // Start is called before the first frame update
    void Start()
    {
        gameScript = theGame.GetComponent<Tutorials>();
    }

    // Update is called once per frame
    void Update()
    {
        s1.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 1 : " + gameScript.p1Score;
        s2.GetComponent<TMPro.TextMeshProUGUI>().text = "Player 2 : " + gameScript.p2Score;
        streak1.GetComponent<TMPro.TextMeshProUGUI>().text = "X" + gameScript.straight1;
        streak2.GetComponent<TMPro.TextMeshProUGUI>().text = "X" + gameScript.straight2;
    }
}