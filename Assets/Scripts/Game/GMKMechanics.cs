using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GMKMechanics : MonoBehaviour
{
    public int p1Score;
    public int p2Score;
    public bool isPlaying;
    public GameObject inGameCanvas;
    public GameObject gameOver;
    public GameObject p1;
    public GameObject p2;
    private float setVolume;
    private float timer;
    private static int COLORS_IN_ROUND = 5;
    private static float TIME_IN_POINT = 6f;
    private int round;
    private int roundMax;
    private int colorInRound;
    private float timerStart;
    private int[] color1 = new int[5];
    private int[] color2 = new int[5];
    private Random rd;
    private MoveWithKeyboardBehavior key1;
    private MoveWithKeyboardBehavior key2;

    // Start is called before the first frame update
    void Start()
    {
        colorInRound = 5;
        timer = 0f;
        timerStart = 0f;
        round = 0;
        roundMax = 5;
        isPlaying = false;
        setVolume = AudioListener.volume;
        rd = new Random();
        key1 = p1.GetComponent<MoveWithKeyboardBehavior>();
        key2 = p2.GetComponent<MoveWithKeyboardBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
//        if(isPlaying){
            if(timer <= 0f) 
            {
                //End of the game
                if (round>roundMax){
                    gameOver.SetActive(true);
                    inGameCanvas.SetActive(false);
//                    game_pause();
                } else {
                    //End of a round
                    if(colorInRound >= COLORS_IN_ROUND){
                        startRound();
                        if(timerStart <= 0f){
                            colorInRound = 1;
                            timer = TIME_IN_POINT;
                        }
                    } else {
                        //end of a point 
                        checkPosition();
                        ++colorInRound;
                        timer = TIME_IN_POINT;
                    }
                }
            } else {
                timer -= Time.deltaTime;
            }
//        }
    }

    private void checkPosition(){
        //check if cellulos are in color and give points plus make sound 
    }

    private void startRound(){
        if(timerStart <= 0f){
            timerStart = 7f;
            //desactiver le loup
            int prev1 = -1;
            int prev2 = -1;
            for(int i=0; i<5; ++i){
                do{
                    color1[i] = rd.Next(6);
                } while(color1[i] == prev1);
                prev1 = color1[i];
                do{
                    color2[i] = rd.Next(6);
                } while(color2[i] == prev2);
                prev2 = color2[i];
            }
        } else {
            if(timerStart==7f){
                //envoyer le lourd son et mettre couleur normale
                key1.setColor();
                key2.setColor();
            } else if(timerStart<=1f+(Time.deltaTime/2) && timerStart>=1f-(Time.deltaTime/2)){
                //envoyer le lourd son et mettre couleur normale
                key1.setColor();
                key2.setColor();
            } else if(timerStart <= 6f && timerStart >= 1f){
                //mettre la couleur avec un  modulo sur le timeStart
                key1.setColor(color1[(int)(timerStart-1)]);
                key2.setColor(color2[(int)(timerStart-1)]);
            }
            timerStart -= Time.deltaTime;
        }
    }

    public void keepScore(GameObject player) { 
        if(player.tag.Equals("Player1")) {
            p1Score = player.GetComponent<PlayerScore>().getScore();
        }
        else {
            p2Score = player.GetComponent<PlayerScore>().getScore();
        }
    }

    public void game_init()
    {
        isPlaying = true;
        timer = 120.0f;
    }
    /**    public void game_pause()
    {
        GameObject p1 = FirstWithTag(Resources.FindObjectsOfTypeAll<GameObject>(), "Player1");
        GameObject p2 = FirstWithTag(Resources.FindObjectsOfTypeAll<GameObject>(), "Player2");
        GameObject sheep = FirstWithTag(Resources.FindObjectsOfTypeAll<GameObject>(), "Sheep");
        GameObject mid = FirstWithTag(Resources.FindObjectsOfTypeAll<GameObject>(), "mid");

        float xmid = mid.transform.position.x;
        float ymid = mid.transform.position.y;
        float zmid = mid.transform.position.z;

        float y = p1.transform.position.y;

        p1.transform.position = new Vector3(xmid - 9.0f, y, zmid - 3.0f);
        p2.transform.position = new Vector3(xmid + 9.0f, y, zmid - 3.0f);
        sheep.transform.position = new Vector3(xmid, y, zmid + 3.0f);

        p1.GetComponent<PlayerScore>().score = 0;
        p2.GetComponent<PlayerScore>().score = 0;
        sheep.GetComponent<GhostSheepBehavior>().timer = 0;
        sheep.GetComponent<GhostSheepBehavior>().isSheep = true;

        isPlaying = false;
    }*/

    

    public void round1(){roundMax = 1;}
    
    public void round2(){roundMax = 2;}
    
    public void round3(){roundMax = 3;}

    public void round4(){roundMax = 4;}

    public void round5(){roundMax = 5;}
    
    public void round6(){roundMax = 6;}
}