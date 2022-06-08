using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundDisplay : MonoBehaviour
{
    public GameObject theGame;
    private GMKMechanics gameScript;
    public GameObject color1;
    public GameObject color2;
    public GameObject color3;
    public GameObject color4;
    public GameObject color5;
    public GameObject round1;
    public GameObject round2;
    public GameObject round3;
    public GameObject round4;
    public GameObject round5;
    public GameObject round1Back;
    public GameObject round2Back;
    public GameObject round3Back;
    public GameObject round4Back;
    public GameObject round5Back;
    public GameObject color1Back;
    public GameObject color2Back;
    public GameObject color3Back;
    public GameObject color4Back;
    public GameObject color5Back;
    private GameObject[] colors;
    private GameObject[] rounds;
    private GameObject[] roundsBack;
    private GameObject[] colorsBack;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = theGame.GetComponent<GMKMechanics>();
        colors = new GameObject[5];
        colors[0] = color1;
        colors[1] = color2;
        colors[2] = color3;
        colors[3] = color4;
        colors[4] = color5;
        rounds = new GameObject[5];
        rounds[0] = round1;
        rounds[1] = round2;
        rounds[2] = round3;
        rounds[3] = round4;
        rounds[4] = round5;
        roundsBack = new GameObject[5];
        roundsBack[0] = round1Back;
        roundsBack[1] = round2Back;
        roundsBack[2] = round3Back;
        roundsBack[3] = round4Back;
        roundsBack[4] = round5Back;
        colorsBack = new GameObject[5];
        colorsBack[0] = color1Back;
        colorsBack[1] = color2Back;
        colorsBack[2] = color3Back;
        colorsBack[3] = color4Back;
        colorsBack[4] = color5Back;
    }

    // Update is called once per frame
    void Update()
    {
        int colorInRound = gameScript.getColorInRound();
        colorInRound = colorInRound>5 ? 0 : colorInRound;
        int round = gameScript.getRound();
        int roundMax = gameScript.getRoundMax();

        for(int i=0; i<min(colorInRound, 5); ++i){
            colors[i].SetActive(true);
        }
        for(int i=colorInRound; i<5; ++i){
            colors[i].SetActive(false);
        }

        for(int i=0; i<round; ++i){
            rounds[i].SetActive(true);
        }
        for(int i=round; i<5; ++i){
            rounds[i].SetActive(false);
        }

        for(int i=0; i<round; ++i){
            roundsBack[i].SetActive(false);
        }
        for(int i=round; i<roundMax; ++i){
            roundsBack[i].SetActive(true);
        }
        for(int i=roundMax; i<5; ++i){
            roundsBack[i].SetActive(false);
        }

        for(int i=0; i<min(colorInRound, 5); ++i){
            colorsBack[i].SetActive(false);
        }
        for(int i=colorInRound; i<5; ++i){
            colorsBack[i].SetActive(true);
        }
    }

    private int min(int a, int b){
        return a<b ? a : b;
    }
}
