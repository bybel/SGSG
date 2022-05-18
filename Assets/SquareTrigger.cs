using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("ASSSSS");
        CelluloAgent agent = CelluloManager._celluloList[0].GetComponent<CelluloAgent>();
        Cellulo robot = agent._celluloRobot;
        robot.SetVisualEffect((long)VisualEffect.VisualEffectConstAll, (long)(1 * 255), (long)(1 * 255), (long) (0 * 255), 1);

    }
}
