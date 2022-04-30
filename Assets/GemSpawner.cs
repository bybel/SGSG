using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{

    public AudioSource spawnSound;
    public AudioSource destroySound;

    public float gemSpawnTime = 10f;
    private float gemTimer;
    private bool isActive;
    public float par = 2.5f;
    private GameObject gem;
    private GameMechanics gameScript;

    // Start is called before the first frame update
    void Start()
    {
        gem = GameObject.FindGameObjectWithTag("Gem");
        gameScript = GameObject.FindGameObjectWithTag("GameMechanics").GetComponent<GameMechanics>();
        desactive();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameScript.isPlaying)
        {
            if(!isActive){
                gemTimer += Time.deltaTime;

                if(gemTimer >= gemSpawnTime) {
                    Spawn();
                    isActive = true;
                }
            }
        }
    }

    void Spawn() {
        float xmin = GameObject.FindGameObjectWithTag("xmin").transform.position.x;
        float xmax = GameObject.FindGameObjectWithTag("xmax").transform.position.x;
        float zmin = GameObject.FindGameObjectWithTag("zmin").transform.position.z;
        float zmax = GameObject.FindGameObjectWithTag("zmax").transform.position.z;

        float spawnX = Random.Range(xmin + par, xmax - par);
        float spawnZ = Random.Range(zmin + par, zmax - par);
        
        gem.transform.GetChild(0).position = new Vector3(spawnX, GameObject.FindGameObjectWithTag("Player1").transform.position.y, spawnZ);
        gem.transform.GetChild(0).gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(spawnSound.clip, transform.position);

    }

    public void desactive(){
        isActive = false;
        gem.transform.GetChild(0).gameObject.SetActive(false);
        gemTimer = 0f;
    }

    public void playDestroyAudio (){
        AudioSource.PlayClipAtPoint(destroySound.clip, transform.position);
    }

}