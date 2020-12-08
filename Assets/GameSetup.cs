using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSetup : MonoBehaviour
{
    
    public static int numberOfPlayers = 0;

    // private GameObject CanvasSetup;

    
    // Start is called before the first frame update
    void Start(){
        // CanvasSetup = GameObject.Find("CanvasSetup");

    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void Button1Pressed(){
        Debug.Log("Kliknuo si 1");
        numberOfPlayers = 1;
        SceneManager.LoadScene(1);
        // CanvasSetup.gameObject.SetActive(false);
        // GameControl.numberOfPlayers = numberOfPlayers;
    }

    public void Button2Pressed(){
        Debug.Log("Kliknuo si 2");
        numberOfPlayers = 2;
        SceneManager.LoadScene(1);
        // CanvasSetup.gameObject.SetActive(false);
        // GameControl.numberOfPlayers = numberOfPlayers;
    }

    public void Button3Pressed(){
        Debug.Log("Kliknuo si 3");
        numberOfPlayers = 3;
        SceneManager.LoadScene(1);
        // CanvasSetup.gameObject.SetActive(false);
        // GameControl.numberOfPlayers = numberOfPlayers;
    }

    public void Button4Pressed(){
        Debug.Log("Kliknuo si 4");
        numberOfPlayers = 4;
        SceneManager.LoadScene(1);
        // CanvasSetup.gameObject.SetActive(false);
        // GameControl.numberOfPlayers = numberOfPlayers;
    }
}
