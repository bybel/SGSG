using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum Difficulty {
    easy = 2, medium = 1, hard = 0
};

public class GMKMechanics : MonoBehaviour
{
    private float par = 2.5f;
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
    public GameObject obstacleCellulo;
    public GameObject obstacleLeds;
    public GameObject cancelStraightBonus1;
    public GameObject cancelStraightBonus2;
    public GameObject cancelStraightBonus3;
    public GameObject cancelStraightBonus4;
    public GameObject cancelStraightBonus5;
    private GameObject[] cancelStraightBonuses = new GameObject[5];
    private bool[] cancelStraightBonusesActive = new bool[5];
    private int nbcancelStraightBonuses;
    public GameObject doubleStraightBonus1;
    public GameObject doubleStraightBonus2;
    public GameObject doubleStraightBonus3;
    public GameObject doubleStraightBonus4;
    public GameObject doubleStraightBonus5;
    private GameObject[] doubleStraightBonuses = new GameObject[5];
    private bool[] doubleStraightBonusesActive = new bool[5];
    private int nbdoubleStraightBonuses;
    public GameObject displayColorBonus1;
    public GameObject displayColorBonus2;
    public GameObject displayColorBonus3;
    public GameObject displayColorBonus4;
    public GameObject displayColorBonus5;
    private GameObject[] displayColorBonuses = new GameObject[5];
    private bool[] displayColorBonusesActive = new bool[5];
    private int nbdisplayColorBonuses;
    public GameObject accelerateObstacleBonus;
    public GameObject xminObj;
    public GameObject xmaxObj;
    public GameObject zminObj;
    public GameObject zmaxObj;
    public GameObject mid;

    public int p1Score;
    public int p2Score;
    public bool isPlaying = false;
    public GameObject inGameCanvas;
    public GameObject gameOver;
    public GameObject p1;
    public GameObject p2;
    public GameObject gui;
    private float xmin;
    private float xmax;
    private float zmin;
    private float zmax;
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
    public int straight1;
    public int straight2;
    private bool accelOnCourt;
    private float timerColor1;
    private float timerColor2;
    private float timerAccel1;
    private float timerAccel2;
    private Difficulty difficulty;
    public AudioSource beep;
    public AudioSource boop;
    public AudioSource killStreak_bonus;
    public AudioSource color_bonus;
    public AudioSource speed_bonus;
    public AudioSource double_bonus;
    private bool isacc1;
    private bool isacc2;

    public GameObject Image;


    // Start is called before the first frame update
    void Start()
    {
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
                    Image.SetActive(true);
                    inGameCanvas.SetActive(false);
                    gui.SetActive(false);
                    isPlaying = false;
                    boop.Play();
                    key1.vibrate();
                    key2.vibrate();
                    
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
                            newBonus();
                            key1.setColor();
                            key2.setColor();
                        }
                    } else {
                        checkPlayers();
                        ++colorInRound;
                        timer = TIME_IN_POINT;
                        newBonus();
                        boop.Play();
                        key1.vibrate();
                        key2.vibrate();
                        key1.setColor();
                        key2.setColor();
                        speed_bonus.Stop();
                    }
                }
            } else {
                if(timer<=((int)timer)+(Time.deltaTime) && timer>((int)timer)-(Time.deltaTime)) {
                    beep.Play();
                    key1.setColor();
                    key2.setColor();
                }
                  
                timer -= Time.deltaTime;
                
                if(timerColor1>0f){
                    timerColor1 -= Time.deltaTime;
                }
                if(timerColor2>0f){
                    timerColor2 -= Time.deltaTime;
                } 

                if(timerAccel1>0f){
                    timerAccel1 -= Time.deltaTime;
                } else if(isacc1){
                    obstacle.accelerateObstacle(0);
                    isacc1 = false;
                }
                if(timerAccel2>0f){
                    timerAccel2 -= Time.deltaTime;
                } else if(isacc2){
                    obstacle.accelerateObstacle(0);
                    isacc2 = false;
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
                    p1Score += straight1++;
                } else{
                    p2Score += straight2++;
                }
                //make victory noise
            } else
            {
                if(i==0){
                    straight1 = 1;
                } else{
                    straight2 = 1;
                }
            }
        }
    }

    public int getColor(string tag){
        if (tag.Equals("Player1") && timerColor1>0f){
            return colors[0,colorInRound-1];
        } else if(tag.Equals("Player2") && timerColor2>0f){
            return colors[1,colorInRound-1];
        }
        return -1;
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
            speed_bonus.Stop();
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
                boop.Play();
                key1.vibrate();
                key2.vibrate();
                key1.setColor();
                key2.setColor();
            } else if(timerStart<=1f+(Time.deltaTime) && timerStart>1f-(Time.deltaTime)){
                //envoyer le lourd son et mettre couleur normale
                boop.Play();
                key1.vibrate();
                key2.vibrate();
                key1.setColor();
                key2.setColor();
            } else if(timerStart <= 6f && timerStart >= 1f){
                //mettre la couleur avec un  modulo sur le timeStart
                if(timerStart<=((int)timerStart+1)+(Time.deltaTime) && timerStart>((int)timerStart+1)-(Time.deltaTime)){
                    key1.setColor(colors[0,(int)(6-timerStart)]);
                    key2.setColor(colors[1,(int)(6-timerStart)]);
                    beep.Play();
                }
                
            }
            timerStart -= Time.deltaTime;
        }
    }

    public void loosePoint(string tag){
        obstacle.accelerateObstacle(0);
        isacc1 = false;
        isacc2 = false;
        if(tag.Equals("Player1")){
            --p1Score;
            straight1 = 1;
        } else {
            --p2Score;
            straight2 = 1;
        }
    }

    public void collected(int player, string kind, string tag){
        if(kind.Equals("double")){
            double_bonus.Play();
            doubleStraight(player);
            doubleStraightBonusesActive[int.Parse(tag)] = false;
            --nbdoubleStraightBonuses;
        } else if(kind.Equals("display")){
            color_bonus.Play();
            displayColor(player);
            displayColorBonusesActive[int.Parse(tag)] = false;
            --nbdisplayColorBonuses;
        } else if(kind.Equals("cancel")){
            killStreak_bonus.Play();
            cancelStraight(player);
            cancelStraightBonusesActive[int.Parse(tag)] = false;
            --nbcancelStraightBonuses;
        } else{
            speed_bonus.Play();
            accelerateObstacle(player);
            accelOnCourt = false;
        }
        Debug.Log("cancel " + nbcancelStraightBonuses + " double " + nbdoubleStraightBonuses + " display " + nbdisplayColorBonuses + " accel " + accelOnCourt);
    }

    private void doubleStraight(int player){
        if(player==1){
            p1Score += straight1;
            straight1 *= 2;
        } else{
            p2Score += straight2;
            straight2 *= 2;
        }
    }

    private void displayColor(int player){
        if(player==1){
            timerColor1 += 6f;
            key1.setColor(colors[0,colorInRound-1]);
        } else{
            timerColor2 += 6f;
            key2.setColor(colors[1,colorInRound-1]);
        }
    }

    private void cancelStraight(int player){
        if(player==1){
            straight2 = 1;
        } else{
            straight1 = 1;
        }
    }

    private void accelerateObstacle(int player) {
        if(player==1){
            obstacle.accelerateObstacle(2);
            timerAccel1 += 6f;
            isacc1 = true;
        } else{
            obstacle.accelerateObstacle(1);
            timerAccel2 += 6f;
            isacc2 = true;
        }
    }

    private void newBonus(){
        if(difficulty != Difficulty.hard) return;
        if(nbcancelStraightBonuses>4 && nbdisplayColorBonuses>4 && nbdoubleStraightBonuses>4 && accelOnCourt) return;

        float spawnX = rand(xmin + par, xmax - par);
        float spawnZ = rand(zmin + par, zmax - par);

        int index = -1;
        GameObject toDisp = accelerateObstacleBonus;
        while(index < 0){
            index = rd.Next((accelOnCourt || isacc1 || isacc2) ? 3 : 4);
            if(index==0){
                if(nbcancelStraightBonuses > 4) {
                    index = -1;
                } else {
                    int i = -1;
                    while(cancelStraightBonusesActive[++i]);
                    cancelStraightBonusesActive[i] = true;
                    toDisp = cancelStraightBonuses[i];
                    ++nbcancelStraightBonuses;
                }
            } else if(index==1){
                if(nbdoubleStraightBonuses > 4) {
                    index = -1;
                } else {
                    int i = -1;
                    while(doubleStraightBonusesActive[++i]);
                    doubleStraightBonusesActive[i] = true;
                    toDisp = doubleStraightBonuses[i];
                    ++nbdoubleStraightBonuses;
                }
            } else if(index==2){
                if(nbdisplayColorBonuses > 4) {
                    index = -1;
                } else {
                    int i = -1;
                    while(displayColorBonusesActive[++i]);
                    displayColorBonusesActive[i] = true;
                    toDisp = displayColorBonuses[i];
                    ++nbdisplayColorBonuses;
                }
            } else {
                toDisp = accelerateObstacleBonus;
                accelOnCourt = true;
            }
        }

        toDisp.transform.position = new Vector3(spawnX, p1.transform.position.y, spawnZ);
        toDisp.gameObject.SetActive(true);
        Debug.Log("cancel " + nbcancelStraightBonuses + " double " + nbdoubleStraightBonuses + " display " + nbdisplayColorBonuses + " accel " + accelOnCourt);
    }

    private float rand(float min, float max){
        double range = (double) (max - min);
        return (float) ((rd.NextDouble() * range) + min);
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
        return timer<0f ? 0 : (int) timer + 1;
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

    public void game_pause()
    {
        isPlaying = false;
    }

    public void game_play()
    {
        isPlaying = true;
    }

    public void game_easy(){
        difficulty = Difficulty.easy;
    }

    public void game_medium(){
        difficulty = Difficulty.medium;
        activeObstacle();
    }

    public void game_hard(){
        difficulty = Difficulty.hard;
        activeObstacle();
    }
    
    private void activeObstacle(){
        obstacleCellulo.SetActive(true);
        obstacleLeds.SetActive(true);
    }

    public void game_reset() 
    { 
        timerColor1 = 0f;
        timerColor2 = 0f;
        timerAccel1 = 0f;
        timerAccel2 = 0f;
        roundMax = 5;
        float xmid = mid.transform.position.x;
        float ymid = mid.transform.position.y;
        float zmid = mid.transform.position.z;

        float y = p1.transform.position.y;

        p1.transform.position = new Vector3(xmid - 9.0f, y, zmid - 3.0f);
        p2.transform.position = new Vector3(xmid + 9.0f, y, zmid - 3.0f);
        obstacleObject.transform.position = new Vector3(xmid, y, zmid + 3.0f);

        p1Score = 0;
        p2Score = 0;

        isPlaying = false;
        key1 = p1.GetComponent<MoveWithKeyboardBehavior>();
        key2 = p2.GetComponent<MoveWithKeyboardBehavior>();
        key1.setColor();
        key2.setColor();

        colorInRound = 6;
        timer = -0.5f;
        timerStart = 0f;
        round = 0;
        roundMax = 5;
        straight1 = 1;
        straight2 = 1;
        rd = new Random();
        obstacle = obstacleObject.GetComponent<ObstacleBehavior>();
        xmin = xminObj.transform.position.x;
        xmax = xmaxObj.transform.position.x;
        zmin = zminObj.transform.position.z;
        zmax = zmaxObj.transform.position.z;
        cancelStraightBonuses[0] = cancelStraightBonus1;
        cancelStraightBonuses[1] = cancelStraightBonus2;
        cancelStraightBonuses[2] = cancelStraightBonus3;
        cancelStraightBonuses[3] = cancelStraightBonus4;
        cancelStraightBonuses[4] = cancelStraightBonus5;
        doubleStraightBonuses[0] = doubleStraightBonus1;
        doubleStraightBonuses[1] = doubleStraightBonus2;
        doubleStraightBonuses[2] = doubleStraightBonus3;
        doubleStraightBonuses[3] = doubleStraightBonus4;
        doubleStraightBonuses[4] = doubleStraightBonus5;
        displayColorBonuses[0] = displayColorBonus1;
        displayColorBonuses[1] = displayColorBonus2;
        displayColorBonuses[2] = displayColorBonus3;
        displayColorBonuses[3] = displayColorBonus4;
        displayColorBonuses[4] = displayColorBonus5;
        disactiveAllBonuses();
        nbcancelStraightBonuses = 0;
        nbdisplayColorBonuses = 0;
        nbdoubleStraightBonuses = 0;
        accelOnCourt = false;
        obstacleCellulo.SetActive(false);
        obstacleLeds.SetActive(false);
        isacc1 = false;
        isacc2 = false;
    }

    private void disactiveAllBonuses(){
        for (int i=0; i<5; ++i){
            cancelStraightBonuses[i].SetActive(false);
            cancelStraightBonusesActive[i] = false;
            doubleStraightBonuses[i].SetActive(false);
            doubleStraightBonusesActive[i] = false;
            displayColorBonuses[i].SetActive(false);
            displayColorBonusesActive[i] = false;
        }
        accelerateObstacleBonus.SetActive(false);
    }

    public void round1(){roundMax = 1;}
    
    public void round3(){roundMax = 3;}

    public void round5(){roundMax = 5;}

    public void mute(){
        AudioListener.volume = 0;
    }

    public void unmute(){
        if(AudioListener.volume == 0){
            AudioListener.volume = 1;
        }else{
            AudioListener.volume = setVolume;
        }
    }

}