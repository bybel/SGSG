using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    GameObject bluePlayer;
    GameObject purplePlayer;
    GameObject timerObj;
    public float timer;
    public int p1Score;
    public int p2Score;
    public bool isPlaying;
    public GameObject inGameCanvas;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        timer = 120.0f;
        isPlaying = false;
        inGameCanvas = GameObject.FindGameObjectWithTag("inGameCanvas");
        gameOver = FirstWithTag(Resources.FindObjectsOfTypeAll<GameObject>(), "gameOverCanvas");
        //game_pause();
    }   

    private GameObject FirstWithTag(GameObject[] tab, string tag)
    {
        foreach(GameObject g in tab)
        {
            if (g.CompareTag(tag)) return g;
        }
        return new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0 && isPlaying) 
        {
            inGameCanvas.SetActive(false);
            gameOver.SetActive(true);
            game_pause();
        }
        if (isPlaying) timer -= Time.deltaTime;
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
    }

    public void game_pause()
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

        timer = 120.0f;

        p1.GetComponent<PlayerScore>().score = 0;
        p2.GetComponent<PlayerScore>().score = 0;
        sheep.GetComponent<GhostSheepBehavior>().timer = 0;
        sheep.GetComponent<GhostSheepBehavior>().isSheep = true; 
        isPlaying = false;
    }

    private GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name.Equals(name))
            {
                return t.gameObject;
            }
        }
        return null;
    }

}