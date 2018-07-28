using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovePiece : MonoBehaviour {
	public int turn = 0;
	public int max;

	public bool isMoving = false;
	public bool isMoved = false;
	public bool turnEnds = false;

	public Piece currentPiece;
	public Button diceButton;
	public Button endTurnButton;
	public Dice dice;

	private GameSettings gameManager;
	private BoardSettings gameBoard;
	private UISettings gameUI;
	private CameraView cam;

	// Use this for initialization
	void Awake () {
		GameObject go = GameObject.FindGameObjectWithTag ("GameController");
		gameManager = go.GetComponent<GameSettings> ();
		max = gameManager.playerList.Count - 1;
		go = GameObject.FindGameObjectWithTag ("Board");
		gameBoard = go.GetComponent<BoardSettings> ();
		go = GameObject.Find ("UIManager");
		gameUI = go.GetComponent<UISettings> ();
		cam = Camera.main.gameObject.GetComponent<CameraView> ();
	}

	void Start () {
		if (currentPiece.isBot) {
			BotMove ();
		}
	}
	
	// Update is called once per frame
	void Update () {

        UpdatePlayerInfo();

		if (currentPiece.isBot && isMoved) {
			EndTurn ();
		}

		if (turnEnds && !gameManager.GameIsOver) {
			if (turn < max) {
				++turn;
			} else {
				turn = 0;
			}

			currentPiece.spr.sortingOrder = 0;
			currentPiece = gameManager.playerList [turn];
			currentPiece.spr.sortingOrder = 1;

			cam.target = currentPiece.transform;

			diceButton.interactable = true;
			turnEnds = false;
            gameUI.turnStartPanel.SetActive(true);
			if (currentPiece.isBot) {
				BotMove ();
			}
		}
	}

	public void RollDice(){
		if (!isMoving && !gameManager.GameIsOver && !isMoved) {
			turnEnds = false;
			isMoving = true;
			StartCoroutine (Move ());
		}
	}
    private IEnumerator BotWait()
    {
        yield return new WaitForSeconds(2f);
        gameUI.turnStartPanel.SetActive(false);
        RollDice();
    }

	private IEnumerator Move() {
		if (currentPiece.status == Status.Stunned) {
		} else {
			endTurnButton.interactable = false;

			int target = currentPiece.position;

			// randomize dice face sprite before actually getting the value to get the "rolling" effect.
			for (int i = 0; i < 5; i++) {
				dice.value = Random.Range (1, 7) - currentPiece.moveModifier;
                if (dice.value <= 0) dice.value = 1;
				diceButton.image.sprite = dice.diceFaces [dice.value - 1];
				yield return new WaitForSeconds (0.2f);
			}

            if(currentPiece.status == Status.Confused)
            {
                int rand;
                do
                {
                    rand = Random.Range(-1, 2);
                    Debug.Log("confuse value: " + rand);
                } while (rand == 0);
                dice.value *= rand;
                Debug.Log("Dice value: " + dice.value);
            }

            if (dice.value > 0)
            {
                for (int i = 0; i < dice.value; i++)
                {
                    if (gameManager.GameIsOver)
                        break;

                    currentPiece.position++;
                    target++;

                    if (GoalReached(target))
                    {
                        target = 99;
                    }

                    currentPiece.UpdatePosition(target);
                    //cam.FollowTarget();
                    yield return new WaitForSeconds(1f);
                }
            }
            else if(dice.value < 0)
            {
                for (int i = dice.value; i < 0; i++)
                {
                    if (gameManager.GameIsOver)
                        break;

                    currentPiece.position--;
                    target--;

                    if (target <= 0)
                    {
                        target = 0;
                    }

                    currentPiece.UpdatePosition(target);
                    //cam.FollowTarget();
                    yield return new WaitForSeconds(1f);
                }
            }
			CheckForEvent ();
            //yield return new WaitForSeconds(1f);
        }

		isMoved = true;
		isMoving = false;
		endTurnButton.interactable = true;
	}

	public void MoveAmount(int steps)
	{
		currentPiece.position += steps;

		if (GoalReached (currentPiece.position)) {
			currentPiece.position = 99;
		}
		if (currentPiece.position < 0) {
			currentPiece.position = 0;
		}

		currentPiece.UpdatePosition (currentPiece.position);
		//cam.FollowTarget ();
	}

	private void CheckForEvent() {
		// check win/lose condition
		if (currentPiece.currentTile == gameBoard.tileList [gameBoard.tileList.Count-1]) {
			gameManager.GameIsOver = true;
			gameManager.winner = currentPiece;
			return;
		}

		if (currentPiece.currentTile.head != null) {
			if (currentPiece.currentTile.head.type == TileType.Snake || currentPiece.currentTile.head.type == TileType.Ladder) {
				currentPiece.currentTile = currentPiece.currentTile.connectedTile;
				currentPiece.UpdatePosition ();
			}
			return;
		} else {
			if (currentPiece.currentTile.type == TileType.Chance) {

                
				if (currentPiece.currentTile.chance == null) {
					return;
				}
                

				Chance chance = currentPiece.currentTile.GetComponent<Chance> ();
				int effect = Random.Range (0, (int)Effect.Treasure + 1);
				chance.GetMovement (this);
				chance.ExecuteEffect (effect);
			}
		}
        
        UpdatePlayerInfo ();
        //cam.FollowTarget();
    }
		
	public void EndTurn() {
		if (isMoved || currentPiece.status == Status.Stunned) {
			WaitForStatus ();

			isMoved = false;
			turnEnds = true;
		}
	}

	private void UpdatePlayerInfo() {
		gameUI.playerName.text = currentPiece.username;
		gameUI.playerSpriteImage.sprite = currentPiece.spr.sprite;
		gameUI.coinText.text = currentPiece.coin.ToString ();
		CheckPlayerStatus ();
	}

	private void BotMove() {
        StartCoroutine(BotWait());
		//RollDice ();
	}

	private bool GoalReached(int pos)
	{
		if (pos > 99) {
			return true;
		} else
			return false;
	}

	private void CheckPlayerStatus()
	{
        int duration = currentPiece.statusDuration;
		switch (currentPiece.status) {
		    case Status.Normal:
			    gameUI.statusText.text = "";
			    gameUI.statusText.color = Color.white;
			    break;

		    case Status.Slow:
			    gameUI.statusText.text = "SLOW (" + duration + ")";
			    gameUI.statusText.color = Color.blue;
			    break;

		    case Status.Stunned:
			    gameUI.statusText.text = "STUN (" + duration + ")";
			    gameUI.statusText.color = Color.yellow;
			    break;

            case Status.Confused:
                gameUI.statusText.text = "CONFUSE (" + duration + ")";
                gameUI.statusText.color = Color.green;
                break;
        }
    }

	private void WaitForStatus()
	{
		currentPiece.statusDuration--;
		if (currentPiece.statusDuration <= 0) {
			currentPiece.statusDuration = 0;
			currentPiece.status = Status.Normal;
		} else {
			return;
		}
	}
}
