using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private MapGen boardScript;

    void Awake()
    {
        if (instance == null)
            instance = this;
        boardScript = GetComponent<MapGen>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.createGrid();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
