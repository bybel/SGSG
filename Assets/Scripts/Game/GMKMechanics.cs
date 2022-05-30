using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GMKMechanics : MonoBehaviour
{
    public GameObject smallRed;
    public GameObject bigRed;
    public GameObject smallYellow;
    public GameObject bigYellow;
    public GameObject smallBlue;
    public GameObject bigBlue;
    public GameObject smallPurple;
    public GameObject bigPurple;
    public GameObject smallOrange;
    public GameObject bigOrange;
    public GameObject smallGreen;
    public GameObject bigGreen;
    public GameObject obstacleObject;

    public int p1Score;
    public int p2Score;
    public bool isPlaying = false;
    public GameObject inGameCanvas;
    public GameObject gameOver;
    public GameObject p1;
    public GameObject p2;
    public GameObject gui;
    private float setVolume;
    private float timer;
    private static int COLORS_IN_ROUND = 5;
    private static float TIME_IN_POINT = 6f;
    private int round;
    private int roundMax;
    private int colorInRound;
    private float timerStart;
    private int[,] colors = new int[2,5];
    private Random rd;
    private MoveWithKeyboardBehavior key1;
    private MoveWithKeyboardBehavior key2;
    private ObstacleBehavior obstacle;
    private int straight1;
    private int straight2;
    private bool inv1;
    private bool inv2;
    private float timerDouble1;
    private float timerDouble2;
    private bool double1;
    private bool double2;
    private bool accelerateObstacle;
    private bool accelerateTimer;
    private bool timerAccelerate;

    // Start is called before the first frame update
    void Start()
    {
        colorInRound = 6;
        timer = 0f;
        timerStart = 0f;
        round = 0;
        roundMax = 5;
        straight1 = 0;
        straight2 = 0;
        isPlaying = false;
        inv1 = false;
        inv2 = false;
        double1 = false;
        double2 = false;
        accelerateObstacle = false;
        accelerateTimer = false;
        timerAccelerate = false;
        setVolume = AudioListener.volume;
        rd = new Random();
        key1 = p1.GetComponent<MoveWithKeyboardBehavior>();
        key2 = p2.GetComponent<MoveWithKeyboardBehavior>();
        obstacle = obstacleObject.GetComponent<ObstacleBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            if(timer <= 0f) 
            {
                //End of the game
                if (round>=roundMax && colorInRound >= COLORS_IN_ROUND){
                    gameOver.SetActive(true);
                    inGameCanvas.SetActive(false);
                    gui.SetActive(false);
//                    game_pause();
                } else {
                    //End of a round
                    if(colorInRound >= COLORS_IN_ROUND){
                        startRound();
                        if(timerStart <= 0f){
                            ++round;
                            colorInRound = 1;
                            timer = TIME_IN_POINT;
                            obstacle.active(true);
                            inv1 = false;
                            inv2 = false;
                            if(accelerateObstacle){
                                obstacle.accelerateObstacle(true);
                                accelerateObstacle = false;
                            } else {
                                obstacle.accelerateObstacle(false);
                            }
                            if(accelerateTimer){
                                timerAccelerate = true;
                                accelerateTimer = false;
                            } else {
                                timerAccelerate = false;
                            }
                        }
                    } else {
                        checkPlayers();
                        ++colorInRound;
                        timer = TIME_IN_POINT;
                        key1.setColor();
                        key2.setColor();
                    }
                }
            } else {
                if (timerAccelerate){
                    timer -= 2f*(Time.deltaTime);
                } else {
                    timer -= Time.deltaTime;
                }
                if(double1){
                    if(timerDouble1>0){
                        timerDouble1 -= Time.deltaTime;
                    } else {
                        double1 = false;
                    }
                }
                if(double2){
                    if(timerDouble2>0){
                        timerDouble2 -= Time.deltaTime;
                    } else {
                        double2 = false;
                    }
                }
            }
        }
    }

    private void checkPlayers()
    {
        if(round < 1) return;
        for(int i = 0; i < 2; ++i)
        {
            if(checkPosition(i, colors[i, colorInRound-1]))
            {
                if(i==0){
                    if(double1){
                        p1Score += 2*(++straight1);
                    } else{
                        p1Score += ++straight1;
                    }
                } else{
                    if(double2){
                        p2Score += 2*(++straight2);
                    } else{
                        p2Score += ++straight2;
                    }
                }
                //make victory noise
            } else
            {
                if(i==0){
                    straight1 = 0;
                } else{
                    straight2 = 0;
                }
            }
        }
    }
    private bool checkPosition(int player, int color){
        bool goodPosition = false;
        //blue green yellow red magenta orange
        switch (color)
        {
            case 0:
                goodPosition = smallBlue.GetComponent<RingTrigger>().contains(player) || bigBlue.GetComponent<RingTrigger>().contains(player);
                break;
            case 1:
                goodPosition = smallGreen.GetComponent<RingTrigger>().contains(player) || bigGreen.GetComponent<RingTrigger>().contains(player);
                break;
            case 2:
                goodPosition = smallYellow.GetComponent<RingTrigger>().contains(player) || bigYellow.GetComponent<RingTrigger>().contains(player);
                break;
            case 3:
                goodPosition = smallRed.GetComponent<RingTrigger>().contains(player) || bigRed.GetComponent<RingTrigger>().contains(player);
                break;
            case 4:
                goodPosition = smallPurple.GetComponent<RingTrigger>().contains(player) || bigPurple.GetComponent<RingTrigger>().contains(player);
                break;
            case 5:
                goodPosition = smallOrange.GetComponent<RingTrigger>().contains(player) || bigOrange.GetComponent<RingTrigger>().contains(player);
                break;
        }
        return goodPosition;
    }
    private void startRound(){
        if(timerStart <= 0f){
            checkPlayers();
            timerStart = 7f;
            obstacle.active(false);
            int prev1 = -1;
            int prev2 = -1;
            for(int i=0; i<5; ++i){
                do{
                    colors[0,i] = rd.Next(6);
                } while(colors[0,i] == prev1);
                prev1 = colors[0,i];
                do{
                    colors[1,i] = rd.Next(COLORS_IN_ROUND+1);
                } while(colors[1,i] == prev2);
                prev2 = colors[1,i];
            }
            Debug.Log(" [" + strColor(colors[0,0]) + "," + strColor(colors[0,1]) + "," + strColor(colors[0,2]) + "," + strColor(colors[0,3]) + "," + strColor(colors[0,4]) + "]");
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
                if(inv1){
                    key1.setColor(colors[0,(int)(timerStart-1)]);
                } else {
                    key1.setColor(colors[0,(int)(6-timerStart)]);
                }
                if(inv2){
                    key2.setColor(colors[1,(int)(timerStart-1)]);
                } else {
                    key2.setColor(colors[1,(int)(6-timerStart)]);
                }
            }
            timerStart -= Time.deltaTime;
        }
    }

    public void game_init()
    {
        isPlaying = true;
    }

    public void loosePoint(string tag){
        if(tag.Equals("Player1")){
            --p1Score;
            straight1 = 0;
        } else {
            --p2Score;
            straight2 = 0;
        }
    }

    public void invColors(int player){
        if(player==1){
            inv2 = true;
        } else{
            inv1 = true;
        }
    }

    public void doubleEarnings(int player){
        if(player==1){
            double1 = true;
            timerDouble2 = 18f;
        } else{
            double2 = true;
            timerDouble1 = 18f;
        }
    }

    public void displayColor(int player){
        if(player==1){
            key1.setColor(colors[0,colorInRound-1]);
        } else{
            key2.setColor(colors[1,colorInRound-1]);
        }
    }

    public void cancelStraight(int player){
        if(player==1){
            straight2 = 0;
        } else{
            straight1 = 0;
        }
    }

    public void accelerateObstacleNextRound() {
        accelerateObstacle = true;
    }

    public void accelerateTimerNextRound() {
        accelerateTimer = true;
    }

    public int getRound(){
        return round;
    }

    public int getRoundMax(){
        return roundMax;
    }

    public int getColorInRound(){
        return colorInRound;
    }

    public int getTimer(){
        return (int) timer;
    }

    private string strColor(int c){
        string color;
        switch(c) {
            case 0: color = "blue"; break;
            case 1: color = "green"; break;
            case 2: color = "yellow"; break;
            case 3: color = "red"; break;
            case 4: color = "violet"; break;
            default: color = "orange"; break;
        }
        return color;
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