﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public Sprite[] diceSides;
    public SpriteRenderer rend;
    public int whosTurn = 0;
    private bool coroutineAllowed = true;
    public int numberOfPlayers = 0;

    // Start is called before the first frame update
    private void Start()
    {
        numberOfPlayers = GameSetup.numberOfPlayers;
        
        whosTurn = 0;
        // Debug.Log("dice start:" + whosTurn);
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("Dice");
        rend.sprite = diceSides[5];

    }

    private void OnMouseDown()
    {
        // Debug.Log("dice onmouse:" + whosTurn);
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        // Debug.Log("dice roll:" + whosTurn);
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i < 12; i++)
        {
            randomDiceSide = Random.Range(0,6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.1f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;

        if (whosTurn == 0){
            GameControl.MovePlayer(1);
            // Debug.Log("bok");

            if (randomDiceSide != 5){
                whosTurn = (whosTurn+1)%numberOfPlayers;
                // Debug.Log(whosTurn);
            }

        } else if (whosTurn == 1){
            GameControl.MovePlayer(2);
            if (randomDiceSide != 5){
                whosTurn = (whosTurn+1)%numberOfPlayers;
            }
        } else if (whosTurn == 2){
            GameControl.MovePlayer(3);
            if (randomDiceSide != 5){
                whosTurn = (whosTurn+1)%numberOfPlayers;
            }
        } else if (whosTurn == 3){
            GameControl.MovePlayer(4);
            if (randomDiceSide != 5){
                whosTurn = (whosTurn+1)%numberOfPlayers;
            }
        }

        Debug.Log("na kraju"+whosTurn);
        
        coroutineAllowed = true;

    }
}