using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOnLongTouch : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    public GameObject startButton;
    public GameObject theGame;
    private GameMechanics gameMechanics;
    public GameObject Choices;
    public GameObject inGameButtons;
    public GameObject pause;
    public GameObject resume;
    public GameObject mute;
    public GameObject unmute;
    public GameObject continu;
    public GameObject UI;
    public GameObject connButton;
    private CelluloAgentRigidBody cStart1;
    private CelluloAgentRigidBody cStart2;

    // Start is called before the first frame update
    void Start()
    {
        gameMechanics = theGame.GetComponent<GameMechanics>();
        cStart1 = p1.GetComponent<CelluloAgentRigidBody>();
        cStart2 = p2.GetComponent<CelluloAgentRigidBody>(); 
    }

    // Update is called once per frame
    void Update()
    {
/**
        if(cStart1.hasLongPressed && cStart2.hasLongPressed) {
            startButton.SetActive(false);
            Choices.SetActive(false);
            pause.SetActive(true);
            resume.SetActive(false);
            mute.SetActive(true);
            unmute.SetActive(false);
            inGameButtons.SetActive(true);
            continu.SetActive(false);
            UI.SetActive(true);
            connButton.SetActive(true);
            gameMechanics.game_init();
            cStart1.hasLongPressed = false;
            cStart2.hasLongPressed = false;
        }*/
    }
}
