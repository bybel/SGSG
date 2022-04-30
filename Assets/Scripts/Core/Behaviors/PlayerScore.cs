using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;
    public AudioSource winSound;
    public AudioSource loseSound;
    public GameMechanics gameMechanics;

    // Start is called before the first frame update
    void Start()
    {
        gameMechanics = GameObject.FindGameObjectsWithTag("GameMechanics")[0].GetComponent<GameMechanics>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementScore()
    {
        score++;
        AudioSource.PlayClipAtPoint(winSound.clip, transform.position);
        gameMechanics.keepScore(gameObject);
    }
    public void decrementScore()
    {
        score--;
        AudioSource.PlayClipAtPoint(loseSound.clip, transform.position);
        gameMechanics.keepScore(gameObject);
    }

    public int getScore() {
        return score;
    }
}