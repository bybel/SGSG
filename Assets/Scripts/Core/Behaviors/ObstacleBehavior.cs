using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : AgentBehaviour
{
    public GameObject theGame;
    private bool isActive;
    private Steering steering;
    private Vector3 position;
    private Vector3 closest;
    private Vector3 pos1;
    private Vector3 pos2;
    private float dis1;
    private float dis2;
    private GMKMechanics gameScript;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = theGame.GetComponent<GMKMechanics>();
    }

    // Update is called once per frame
    public override Steering GetSteering()
    {
        if (isActive){
            locatePlayers();
            closest.Normalize();
            steering.linear = closest * (agent.maxAccel/7);
            steering.linear = transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));

            return steering;
        }

        return new Steering();
    }

    private void locatePlayers()
    {
        steering = new Steering();
        GameObject[] p1;
        GameObject[] p2;
        p1 = GameObject.FindGameObjectsWithTag("Player1");
        p2 = GameObject.FindGameObjectsWithTag("Player2");
        

        position = transform.position;
        pos1 = p1[0].transform.position - position;
        pos2 = p2[0].transform.position - position;

        dis1 = pos1.sqrMagnitude;
        dis2 = pos2.sqrMagnitude;
        closest = pos2;

        if (dis1 < dis2)
        {
            closest = pos1;
        }
    }

    public void active(){
        isActive = true;
    }

    public void desactive(){
        isActive = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Player1") || tag.Equals("Player2"))
        {
            gameScript.loosePoint(tag);
        }
    }
}