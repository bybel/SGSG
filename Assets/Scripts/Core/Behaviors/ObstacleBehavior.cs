using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : AgentBehaviour
{
    public GameObject theGame;
    public GameObject p1;
    public GameObject p2;
    private bool isActive;
    private Steering steering;
    private Vector3 position;
    private Vector3 closest;
    private Vector3 pos1;
    private Vector3 pos2;
    private float dis1;
    private float dis2;
    private GMKMechanics gameScript;
    private Tutorials tuto;
    private int accelVsPlayer;
    public AudioSource looseSound;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = theGame.GetComponent<GMKMechanics>();
        tuto = theGame.GetComponent<Tutorials>();
        isActive = false;
        accelVsPlayer = 0;
    }

    // Update is called once per frame
    public override Steering GetSteering()
    {
        if ((tuto.active || gameScript.isPlaying) && isActive){
            locatePlayers();
            closest.Normalize();
            if(accelVsPlayer>0){
                steering.linear = closest * agent.maxAccel;
            } else {
                steering.linear = closest * (agent.maxAccel/8);
            }
            steering.linear = transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));

            return steering;
        }

        return new Steering();
    }

    private void locatePlayers()
    {
        steering = new Steering();
        
        position = transform.position;
        pos1 = p1.transform.position - position;
        pos2 = p2.transform.position - position;

        dis1 = pos1.sqrMagnitude;
        dis2 = pos2.sqrMagnitude;
        closest = pos2;

        if(accelVsPlayer == 1){
            closest = pos1;
        } else if(accelVsPlayer == 2){
            closest = pos2;
        } else if (dis1 < dis2)
        {
            closest = pos1;
        }
    }

    public void active(bool condition){
        isActive = condition;
    }

    public void accelerateObstacle(int player){
        accelVsPlayer = player;
    }

    void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Player1") || tag.Equals("Player2"))
        {
            looseSound.Play();
            if(tuto.active) {
                tuto.touched(tag);
            } else {
                gameScript.loosePoint(tag);
            }
        }
    }
}