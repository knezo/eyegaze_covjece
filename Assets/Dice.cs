using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public Sprite[] diceSides;
    public SpriteRenderer rend;
    public int whosTurn = 1;
    private bool coroutineAllowed = true;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("Dice");
        rend.sprite = diceSides[5];
    }

    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i < 12; i++)
        {
            randomDiceSide = Random.Range(0,6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.1f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;

        if (whosTurn == 1){
            GameControl.MovePlayer(1);

            if (randomDiceSide != 5){
                whosTurn *= -1;
            }

        } else if (whosTurn == -1){
            GameControl.MovePlayer(2);
            if (randomDiceSide != 5){
                whosTurn *= -1;
            }
        }

        Debug.Log(whosTurn);
        
        coroutineAllowed = true;

    }
}