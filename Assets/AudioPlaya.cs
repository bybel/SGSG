using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Math;

public class AudioPlaya : MonoBehaviour
{
    public AudioSource beep;
    public AudioSource boop;
    public AudioSource color_bonus;
    public AudioSource speed_bonus;
    public AudioSource double_bonus;
    public AudioSource killStreak_bonus;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {  
    }
}
