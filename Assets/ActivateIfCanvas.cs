using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateIfCanvas : MonoBehaviour
{

    public GameObject inGameCanvas;

    // Start is called before the first frame update
    void Start()
    {

        inGameCanvas = FirstWithTag(Resources.FindObjectsOfTypeAll<GameObject>(), "inGameCanvas");

        
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
        if(inGameCanvas.activeSelf) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
