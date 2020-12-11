using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    private static GameObject player1, player2, player3, player4, dice;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static int player3StartWaypoint = 0;
    public static int player4StartWaypoint = 0;

    public static bool gameOver = false;

    public static int numOfPlayers = 0;
    public Text whosMoveText;


    // Start is called before the first frame update
     void Start () {

        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        whosMoveText = GameObject.Find("Canvas/WhosMoveText").GetComponent<Text>();
        // whosMoveText.gameObject.SetActive(false);

        // GameObject gs = GameObject.Find("GameSetup");
        // controllerScript cs = gs.GetComponent
        // numberOfPlayers = GameObject.Find("GameSetup").GetComponent<GameSetup>.numberOfPlayers;
        

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        dice = GameObject.Find("Dice");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;
        
        player3.GetComponent<FollowThePath>().moveAllowed = false;
        player4.GetComponent<FollowThePath>().moveAllowed = false;

        whoWinsTextShadow.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);

        numOfPlayers = GameSetup.numberOfPlayers;
        // Debug.Log(numOfPlayers);

        //disable unused players
        switch (numOfPlayers) { 
            case 1:
                player2.gameObject.SetActive(false);
                player3.gameObject.SetActive(false);
                player4.gameObject.SetActive(false);
                break;

            case 2:
                player3.gameObject.SetActive(false);
                player4.gameObject.SetActive(false);
                break;

            case 3:
                player4.gameObject.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;

            // if (dice.GetComponent<Dice>().whosTurn == 2){ //change text whos turn is next
            //     player1MoveText.gameObject.SetActive(false);
            //     player2MoveText.gameObject.SetActive(true);
            // }
            
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;

            // if (dice.GetComponent<Dice>().whosTurn == 1){
            //     player1MoveText.gameObject.SetActive(true);
            //     player2MoveText.gameObject.SetActive(false);
            // }
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        // igrac 3
        if (player3.GetComponent<FollowThePath>().waypointIndex >
            player3StartWaypoint + diceSideThrown)
        {
            player3.GetComponent<FollowThePath>().moveAllowed = false;

            // if (dice.GetComponent<Dice>().whosTurn == 1){
            //     player1MoveText.gameObject.SetActive(true);
            //     player2MoveText.gameObject.SetActive(false);
            // }
            player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        // igrac 4
        if (player4.GetComponent<FollowThePath>().waypointIndex >
            player4StartWaypoint + diceSideThrown)
        {
            player4.GetComponent<FollowThePath>().moveAllowed = false;

            // if (dice.GetComponent<Dice>().whosTurn == 1){
            //     player1MoveText.gameObject.SetActive(true);
            //     player2MoveText.gameObject.SetActive(false);
            // }
            player4StartWaypoint = player4.GetComponent<FollowThePath>().waypointIndex - 1;
        }




        //game ends
            //player1 wins
        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            // whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            gameOver = true;
        }

            //player2 wins
        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            // whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
            gameOver = true;
        }


        //whos turn text
        if (dice.GetComponent<Dice>().whosTurn == 0){ //change text whos turn is next
            // player1MoveText.gameObject.SetActive(true);
            // player2MoveText.gameObject.SetActive(false);
            whosMoveText.text = "Igra igrač 1";
        } else if (dice.GetComponent<Dice>().whosTurn == 1){
            // player1MoveText.gameObject.SetActive(false);
            // player2MoveText.gameObject.SetActive(true);
            whosMoveText.text = "Igra igrač 2";
        } else if (dice.GetComponent<Dice>().whosTurn == 2){
            whosMoveText.text = "Igra igrač 3";
        } else if (dice.GetComponent<Dice>().whosTurn == 3){
            whosMoveText.text = "Igra igrač 4";
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        // Debug.Log("Sada smo u 2.update");

        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            
            case 3:
                player3.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 4:
                player4.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }
}

