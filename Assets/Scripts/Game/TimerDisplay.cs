using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    GameMechanics gameScript;
    // Start is called before the first frame update
    void Start()
    {
        gameScript = GameObject.FindGameObjectWithTag("GameMechanics").GetComponent<GameMechanics>();
    }

    // Update is called once per frame
    void Update()
    {
        string time = (int)gameScript.timer / 60 + ":" + (int)gameScript.timer % 60;
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = time;
    }
}