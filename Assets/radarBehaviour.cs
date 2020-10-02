using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class radarBehaviour: MonoBehaviour
{
    public Material good;
    public Material bad;
    public Renderer player;
    public Text[]   tales;
    public string[,]    result = new string[3, 3];
    public GameObject canvas_res;

    private Vector3 position;
    private int onTrigger = 0;
    // Start is called before the first frame update
    void Start()
    {
        canvas_res.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (onTrigger == 1)
        {
            player.material = good;
        }
        else
        {
            player.material = bad;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        onTrigger += 1;
        // Debug.Log("radar enter on collision with : " + other.gameObject.name);
        position = other.gameObject.transform.position * (3f/20f) + new Vector3(1.5f, 0f, 1.5f) ;
        // Debug.Log("stocking in : " + (int)position.x +  (int)position.z);
        result[(int)position.x, (int)position.z] += other.gameObject.name;
        tales[(int)position.z*3 + (int)position.x].text += " " + other.gameObject.name;
    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger -= 1;
    }

    public void HideResult()
    {
        canvas_res.SetActive(false);
    }

    public void GiveResult()
    {
        canvas_res.SetActive(!canvas_res.activeSelf);
    }

    public void CleanTab()
    {
        var i = 0;
        while (i < 9)
        {
            tales[i].text = "";
            i++;
        }
    }
}
