using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum BasicStates {
    start = 0, arrows = 1, red = 2, wasd = 3, obstacle = 4, comb = 5
};

public enum BonusStates {
    start = 0, color = 1, twice = 2, cancel = 3, accel = 4
};

public class Tutorials : MonoBehaviour
{
    public GameObject obstacleCellulo;
    public GameObject obstacleLeds;
    public GameObject advCellulo;
    public GameObject advLeds;
    public GameObject accelerateObstacleBonus;
    public GameObject cancelStraightBonus;
    public GameObject doubleStraightBonus;
    public GameObject displayColorBonus;

    public int p1Score;
    public int p2Score;
    public GameObject xminObj;
    public GameObject xmaxObj;
    public GameObject zminObj;
    public GameObject zmaxObj;
    public GameObject mid;
    public GameObject p1;
    public GameObject p2;
    public GameObject obstacleObject;
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
    public GameObject inGameCanvas;
    public int straight1;
    public int straight2;
    public bool active;
    public GameObject texts;
    public GameObject arrowsTutoText;
    public GameObject wasdTutoText;
    public GameObject redTutoText;
    public GameObject combTutoText;
    public GameObject obstacleTutoText;
    public GameObject colorTutoText;
    public GameObject accelTutoText;
    public GameObject doubleTutoText;
    public GameObject cancelTutoText;
    public GameObject finishTutoText;
    public GameObject box;
    public GameObject ok_button;
    
    private float setVolume;
    private Random rd;
    private MoveWithKeyboardBehavior key1;
    private MoveWithKeyboardBehavior key2;
    private ObstacleBehavior obstacle;
    private float xmin;
    private float xmax;
    private float zmin;
    private float zmax;
    private float timer;
    private static int COLORS_IN_ROUND = 3;
    private static float TIME_IN_POINT = 6f;
    private int colorInRound;
    private float timerStart;
    private int[] colors = new int[3];
    private bool bonusTuto;
    private bool baseTuto;
    public BasicStates basicState;
    public BonusStates bonusState;
    private bool cgt;
    private bool accelCollected;
    private bool displayCollected;
    private Vector3 midPos;


    // Start is called before the first frame update
    void Start()
    {
        setVolume = AudioListener.volume;
        rd = new Random();
        key1 = p1.GetComponent<MoveWithKeyboardBehavior>();
        key2 = p2.GetComponent<MoveWithKeyboardBehavior>();
        obstacle = obstacleObject.GetComponent<ObstacleBehavior>();
    }// Update is called once per frame
    void Update()
    {
        if(cgt){
            if(bonusTuto){
                ++bonusState;
                updateBonusTuto();
            } else if(baseTuto){
                ++basicState;
                updateBaseTuto();
            }
        } else if(baseTuto && active) {
            if(timer < 0f){
                if(basicState == BasicStates.arrows){
                    activeBox(redTutoText);
                } else if(basicState == BasicStates.wasd){
                    activeBox(obstacleTutoText);
                } else if(basicState == BasicStates.obstacle){
                    activeBox(combTutoText);
                } else if(basicState == BasicStates.comb) {
                    if (colorInRound == 0){
                        startRound();
                        if(timerStart <= 0f){
                            colorInRound = 1;
                            timer = TIME_IN_POINT;
                        }
                    } else if(colorInRound<COLORS_IN_ROUND){
                        checkPlayers();
                        ++colorInRound;
                        timer = TIME_IN_POINT;
                    } else {
                        checkPlayers();
                        finishTuto();
                    }
                }
            } else {
                timer -= Time.deltaTime;
            }
        }
    }

    private void checkPlayers()
    {
        if(checkPosition(colors[colorInRound-1]))
        {
            p1Score += straight1++;
        } else
        {
            straight1 = 1;
        }
    }

    private bool checkPosition(int color){
        bool goodPosition = false;
        //blue green yellow red magenta orange
        switch (color)
        {
            case 0:
                goodPosition = smallBlue.GetComponent<RingTrigger>().contains(0) || bigBlue.GetComponent<RingTrigger>().contains(0);
                break;
            case 1:
                goodPosition = smallGreen.GetComponent<RingTrigger>().contains(0) || bigGreen.GetComponent<RingTrigger>().contains(0);
                break;
            case 2:
                goodPosition = smallYellow.GetComponent<RingTrigger>().contains(0) || bigYellow.GetComponent<RingTrigger>().contains(0);
                break;
            case 3:
                goodPosition = smallRed.GetComponent<RingTrigger>().contains(0) || bigRed.GetComponent<RingTrigger>().contains(0);
                break;
            case 4:
                goodPosition = smallPurple.GetComponent<RingTrigger>().contains(0) || bigPurple.GetComponent<RingTrigger>().contains(0);
                break;
            case 5:
                goodPosition = smallOrange.GetComponent<RingTrigger>().contains(0) || bigOrange.GetComponent<RingTrigger>().contains(0);
                break;
        }
        return goodPosition;
    }

    private void activeBox(GameObject text){
        box.SetActive(true);
        text.SetActive(true);
        p1.transform.position = midPos;
        active = false;
    }

    public void ok(){
        cgt = true;
        active = true;
        box.SetActive(false);
        disactiveAllText();
    }

    private void updateBonusTuto(){
        if(bonusState == BonusStates.color){
            spawn(displayColorBonus);
            displayCollected = false;
        } else if(bonusState == BonusStates.twice){
            spawn(doubleStraightBonus);
        } else if(bonusState == BonusStates.cancel){
            spawn(cancelStraightBonus);
        } else if(bonusState == BonusStates.accel){
            placeAdv();
            placeObs();
            accelCollected = false;
            spawn(accelerateObstacleBonus);
        }
        cgt = false;
    }
    private void updateBaseTuto(){
        if(basicState == BasicStates.arrows){
            timer = 5f;
        } else if(basicState == BasicStates.red){
        } else if(basicState == BasicStates.wasd){
            timer = 5f;
            placeAdv();
        } else if(basicState == BasicStates.obstacle){
            timer = 10f;
            placeObs();
            placeAdv();
        } 
        cgt = false;
    }

    private void spawn (GameObject obj){
        float xmid = mid.transform.position.x;
        float zmid = mid.transform.position.z;
        float y = p1.transform.position.y;

        obj.transform.position = new Vector3(xmid-4f, p1.transform.position.y, zmid+3f);
        obj.SetActive(true);
    }

    public void initBonusTutorial(){
        bonusTuto = true;
        active = true;
        activeBox(colorTutoText);
    }

    public void initBasicsTutorial(){
        baseTuto = true;
        active = true;
        activeBox(arrowsTutoText);
    }

    public void exitTuto(){
        bonusTuto = false;
        baseTuto = false;
        active = false;
        placeAdv();
    }

    private void placeAdv(){
        float xmid = mid.transform.position.x;
        float ymid = mid.transform.position.y;
        float zmid = mid.transform.position.z;
        float y = p1.transform.position.y;

        p2.transform.position = new Vector3(xmid + 9.0f, y, zmid - 3.0f);
        advCellulo.SetActive(true);
        advLeds.SetActive(true);
    }

    private void placeObs(){
        float xmid = mid.transform.position.x;
        float ymid = mid.transform.position.y;
        float zmid = mid.transform.position.z;
        float y = p1.transform.position.y;

        obstacleObject.transform.position = new Vector3(xmid - 9.0f, y, zmid - 3.0f);
        obstacleCellulo.SetActive(true);
        obstacleLeds.SetActive(true);
        obstacle.active(true);
    }

    public void initCourt(){
        float xmid = mid.transform.position.x;
        float ymid = mid.transform.position.y;
        float zmid = mid.transform.position.z;

        float y = p1.transform.position.y;

        midPos = new Vector3(xmid, y, zmid);
        p1.transform.position = midPos;

        p1Score = 12;
        p2Score = 17;

        key1 = p1.GetComponent<MoveWithKeyboardBehavior>();
        key2 = p2.GetComponent<MoveWithKeyboardBehavior>();
        key1.setColor();
        key2.setColor();

        colorInRound = 0;
        timer = -0.5f;
        timerStart = 0f;
        straight1 = 5;
        straight2 = 8;
        rd = new Random();
        obstacle = obstacleObject.GetComponent<ObstacleBehavior>();
        xmin = xminObj.transform.position.x;
        xmax = xmaxObj.transform.position.x;
        zmin = zminObj.transform.position.z;
        zmax = zmaxObj.transform.position.z;
        disactiveAll();
        basicState = BasicStates.start;
        bonusState = BonusStates.start;
    }

    private void disactiveAll(){
        obstacleCellulo.SetActive(false);
        obstacleLeds.SetActive(false);
        advCellulo.SetActive(false);
        advLeds.SetActive(false);
        
        accelerateObstacleBonus.SetActive(false);
        cancelStraightBonus.SetActive(false);
        doubleStraightBonus.SetActive(false);
        displayColorBonus.SetActive(false);

        disactiveAllText();
    }

    private void disactiveAllText(){
        texts.SetActive(true);
        arrowsTutoText.SetActive(false);
        wasdTutoText.SetActive(false);
        redTutoText.SetActive(false);
        combTutoText.SetActive(false);
        obstacleTutoText.SetActive(false);
        colorTutoText.SetActive(false);
        accelTutoText.SetActive(false);
        doubleTutoText.SetActive(false);
        cancelTutoText.SetActive(false);
        finishTutoText.SetActive(false);
    }

    private float rand(float min, float max){
        double range = (double) (max - min);
        return (float) ((rd.NextDouble() * range) + min);
    }

    public void collected(string kind){
        if(kind.Equals("double")){
            p1Score += straight1;
            straight1 *= 2;
            activeBox(cancelTutoText);
        } else if(kind.Equals("display")){
            key1.setColor(3);
            displayCollected = true;
        } else if(kind.Equals("cancel")){
            straight2 = 1;
            activeBox(accelTutoText);
        } else {
            obstacle.accelerateObstacle(2);
            accelCollected = true;
        }
    }

    public void reached(){
        if(bonusTuto && displayCollected){
            activeBox(doubleTutoText);
            displayCollected = false;
            key1.setColor();
        } else if (baseTuto && basicState == BasicStates.red){
            activeBox(wasdTutoText);
        }
    }

    public void touched(string tag){
        if(tag.Equals("Player1")){
            --p1Score;
            straight1 = 1;
        } else {
            --p2Score;
            straight2 = 1;
            if(accelCollected) {
                finishTuto();
            }
        }
    }

    private void finishTuto(){
        active = false;
        activeBox(finishTutoText);
        placeAdv();
        ok_button.SetActive(false);
    }

    public int getTimer(){
        return timer<0f ? 0 : (int) timer + 1;
    }

    private void startRound(){
        if(timerStart <= 0f){
            advCellulo.SetActive(false);
            advLeds.SetActive(false);
            obstacleCellulo.SetActive(false);
            obstacleLeds.SetActive(false);
            timerStart = 5f;
            obstacle.active(false);
            int prev = -1;
            for(int i=0; i<COLORS_IN_ROUND; ++i){
                do{
                    colors[i] = rd.Next(6);
                } while(colors[i] == prev);
                prev = colors[i];
            }
        } else {
            if(timerStart==5f){
                //envoyer le lourd son et mettre couleur normale
                key1.setColor();
            } else if(timerStart<=1f+(Time.deltaTime) && timerStart>1f-(Time.deltaTime)){
                //envoyer le lourd son et mettre couleur normale
                key1.setColor();
            } else if(timerStart <= 4f && timerStart >= 1f){
                //mettre la couleur avec un  modulo sur le timeStart
                if(timerStart<=((int)timerStart+1)+(Time.deltaTime) && timerStart>((int)timerStart+1)-(Time.deltaTime)){
                    key1.setColor(colors[(int)(4-timerStart)]);
                }
                
            }
            timerStart -= Time.deltaTime;
        }
    }
}