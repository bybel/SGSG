using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    public GameObject theGame;
    private GMKMechanics gameScript;
    private TMPro.TextMeshProUGUI gui;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = theGame.GetComponent<GMKMechanics>();
        gui = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gui.text = "" + gameScript.getTimer();
    }
}