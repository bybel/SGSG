using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;
//    public AudioSource winSound;
//    public AudioSource loseSound;
//    public GameMechanics gameMechanics;
    private PlayerScore other;
    private bool ateGem;

    // Start is called before the first frame update
    void Start()
    {
//        gameMechanics = GameObject.FindGameObjectsWithTag("GameMechanics")[0].GetComponent<GameMechanics>();
        score = 0;
        if (gameObject.tag.Equals("Player1")){
            other = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerScore>();
        } else {
            other = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerScore>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void incrementScore()
    {
        score++;
//        AudioSource.PlayClipAtPoint(winSound.clip, transform.position);
//        gameMechanics.keepScore(gameObject);
    }
    public void decrementScore()
    {
        score--;
//        AudioSource.PlayClipAtPoint(loseSound.clip, transform.position);
//        gameMechanics.keepScore(gameObject);
    }

    public int getScore() {
        return score;
    }

    void OnCollisionEnter(Collision collision){
/**        if(collision.gameObject.tag.Equals("GemObject")) {
            GemSpawner gs = GameObject.FindGameObjectWithTag("Gem").GetComponent<GemSpawner>();
            gs.desactive();
            gs.playDestroyAudio();
            other.ateGem = false;
            ateGem = true;
        }
        if(ateGem && (collision.gameObject.tag.Equals("Player1") || collision.gameObject.tag.Equals("Player2"))){
            incrementScore();
            incrementScore();
            other.decrementScore();
            other.decrementScore();
            ateGem = false;
        }*/
    }
}