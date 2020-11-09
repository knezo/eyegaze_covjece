using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public Sprite[] diceSides;
    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("Dice");
        rend.sprite = diceSides[5];
    }

    void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

    IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;
        for (int i = 0; i < 12; i++)
        {
            randomDiceSide = Random.Range(0,6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.1f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
