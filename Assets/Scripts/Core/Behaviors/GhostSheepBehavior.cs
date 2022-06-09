using System.Linq;
using UnityEngine;

public class GhostSheepBehavior : AgentBehaviour
{

    public float minDistance = 27.0f;
    public float par = 2.5f;
    public float eps = 0.00001f;
    public AudioSource wolfSound;
    public float timer;
    public AudioSource sheepSound;
    public bool isSheep;

    private Steering steering;
    private Vector3 position;
    private Vector3 closest;
    private GameObject closestPlayer;
    private Vector3 pos1; 
    private Vector3 pos2;
    private float dis1;
    private float dis2;
    private float switchTime;
    private float xmin;
    private float zmin;
    private float xmid;
    private float zmid;
    private float xmax;
    private float zmax;

    public void Start() {
        timer = 0;
        isSheep = true;
        switchTime = Random.Range(10.0f,14.0f);
        locateBorders();
    }   

    public override Steering GetSteering()
    {
        GameMechanics gameScript = GameObject.FindGameObjectWithTag("GameMechanics").GetComponent<GameMechanics>();

        if (gameScript.isPlaying)
        {
            locatePlayers();

            timer += Time.deltaTime;

            if (isSheep)
            {
                sheep();
                agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.green, 0);
            }
            else
            {
                wolf();
                agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.red, 0);
            }

            if (timer > switchTime)
            {
                isSheep = !isSheep;
                timer = 0;
                switchTime = Random.Range(10.0f, 14.0f);
                AudioSource.PlayClipAtPoint(isSheep ? sheepSound.clip : wolfSound.clip, transform.position);
            }
        }
        else {
            return new Steering();
        }
        return gameScript.isPlaying ? steering : new Steering();
    }

    private float abs(float f)
    {
        if (f < 0)
        {
            return -f;
        }
        return f;
    }

    private void locatePlayers()
    {
        steering = new Steering();
        //implement your code here.
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
        closestPlayer = p2[0];

        if (dis1 < dis2)
        {
            closest = pos1;
            closestPlayer = p1[0];
        }
    }

    private void locateBorders(){
        GameObject[] left;
        GameObject[] right;
        GameObject[] up;
        GameObject[] down;
        GameObject[] mid;
        left = GameObject.FindGameObjectsWithTag("xmin");
        right = GameObject.FindGameObjectsWithTag("xmax");
        down = GameObject.FindGameObjectsWithTag("zmin");
        up = GameObject.FindGameObjectsWithTag("zmax");
        mid = GameObject.FindGameObjectsWithTag("mid");
        xmin = left[0].transform.position.x;
        xmax = right[0].transform.position.x;
        zmin = down[0].transform.position.z;
        zmax = up[0].transform.position.z;
        xmid = mid[0].transform.position.x;
        zmid = mid[0].transform.position.z;
    }
    private void sheep()
    {
        if (closest.sqrMagnitude > minDistance)
        {
            closest = Vector3.zero;
        }
        else
        {
            float dir = Vector3.Dot(pos1, pos2) / (pos1.magnitude * pos2.magnitude);
            if (dis1 < minDistance && dis2 < minDistance && abs(dir) < par && dir < 0)
            {
                if (position.x < xmin + par)
                {
                    closest = new Vector3(-1, 0, 0);
                }
                else if (position.x > xmax - par)
                {
                    closest = new Vector3(1, 0, 0);
                }
                else
                {
                    if (position.z > zmid)
                    {
                        closest = new Vector3(-(pos1.z / pos1.x), 0, 1);
                    }
                    else
                    {
                        closest = new Vector3(pos1.z / pos1.x, 0, -1);
                    }

                }
            }
            else
            {
                if (position.x >= xmax - par || position.x <= xmin + par)
                {
                    if (closest.z < 0)
                    {
                        closest = new Vector3(0, 0, -1);
                    }
                    else
                    {
                        closest = new Vector3(0, 0, 1);
                    }
                }
                else if (position.z >= zmax - par || position.z <= zmin + par)
                {
                    if (closest.x < 0)
                    {
                        closest = new Vector3(-1, 0, 0);
                    }
                    else
                    {
                        closest = new Vector3(1, 0, 0);
                    }
                }
            }

            closest.Normalize();
        }

        steering.linear = -closest * agent.maxAccel;
        steering.linear = transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
    }

    private void wolf()
    {
        closest.Normalize();
        steering.linear = closest * agent.maxAccel;
        steering.linear = transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isSheep)
        {
            GameObject gameObject = collision.gameObject;
            if (gameObject.tag.Equals("Player1") || gameObject.tag.Equals("Player2"))
            {
                PlayerScore scoreScript = gameObject.GetComponent<PlayerScore>();
                scoreScript.decrementScore();
            }
        }
    }

    public void incrementScore()
    {
        if(isSheep){
            PlayerScore scoreScript = closestPlayer.GetComponent<PlayerScore>();
            scoreScript.incrementScore();
        }
    }
}