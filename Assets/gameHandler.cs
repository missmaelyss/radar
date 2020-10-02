using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameHandler : MonoBehaviour
{
    public movingObject movingObject;
    public playerBehaviour playerBehaviour;
    public Button showResult;
    public Text text;
    public radarBehaviour radarBehaviour;
    
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        movingObject.enabled = true;
        playerBehaviour.enabled = false;
        showResult.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickStart()
    {
        if (!started)
        {
            text.text = "Stop";
            started = true;
            movingObject.enabled = false;
            radarBehaviour.CleanTab();
            playerBehaviour.enabled = true;
            showResult.enabled = true;
        }
        else
        {
            text.text = "Start";
            started = false;
            movingObject.enabled = true;
            radarBehaviour.CleanTab();
            radarBehaviour.HideResult();
            playerBehaviour.enabled = false;
            showResult.enabled = false;
        }
    }
}
