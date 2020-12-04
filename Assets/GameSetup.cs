using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    
    public int NumeberOfPlayers;

    private GameObject CanvasSetup;

    
    // Start is called before the first frame update
    void Start(){
        CanvasSetup = GameObject.Find("CanvasSetup");
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void Button1Pressed(){
        Debug.Log("Kliknuo si 1");
        NumeberOfPlayers = 1;
        CanvasSetup.gameObject.SetActive(false);
    }

    public void Button2Pressed(){
        Debug.Log("Kliknuo si 2");
        NumeberOfPlayers = 2;
        CanvasSetup.gameObject.SetActive(false);
    }

    public void Button3Pressed(){
        Debug.Log("Kliknuo si 3");
        NumeberOfPlayers = 3;
        CanvasSetup.gameObject.SetActive(false);
    }

    public void Button4Pressed(){
        Debug.Log("Kliknuo si 4");
        NumeberOfPlayers = 4;
        CanvasSetup.gameObject.SetActive(false);
    }
}
