using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDisplayTuto : MonoBehaviour
{
    public GameObject theGame;
    private Tutorials gameScript;
    private TMPro.TextMeshProUGUI gui;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = theGame.GetComponent<Tutorials>();
        gui = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gui.text = "" + gameScript.getTimer();
    }
}