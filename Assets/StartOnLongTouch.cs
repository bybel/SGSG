using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOnLongTouch : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    public GameObject startButton;
    public GameObject theGame;
    private GMKMechanics gameMechanics;
    public GameObject Choices;
    public GameObject inGameButtons;
    public GameObject pause;
    public GameObject resume;
    public GameObject mute;
    public GameObject unmute;
    public GameObject image;
    public GameObject hud;
    private CelluloAgentRigidBody cStart1;
    private CelluloAgentRigidBody cStart2;

    // Start is called before the first frame update
    void Start()
    {
        gameMechanics = theGame.GetComponent<GMKMechanics>();
        cStart1 = p1.GetComponent<CelluloAgentRigidBody>();
        cStart2 = p2.GetComponent<CelluloAgentRigidBody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(cStart1.hasLongPressed && cStart2.hasLongPressed) {
            Debug.Log("ASS");
            
            startButton.SetActive(false);
            Choices.SetActive(false);
            pause.SetActive(true);
            resume.SetActive(false);
            mute.SetActive(true);
            unmute.SetActive(false);
            inGameButtons.SetActive(true);
            image.SetActive(false);
            gameMechanics.game_play();
            cStart1.hasLongPressed = false;
            cStart2.hasLongPressed = false;
            gameMechanics.game_medium();
            hud.SetActive(true);
        }
    }
}
