using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private PlayerMove player;
    [SerializeField]
    private PatternManager patternManager;

    public float beatsPerMinute;
    private bool playing;
	// Use this for initialization
	void Start () {
        patternManager.enabled = false;
        player.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(!playing && Input.GetKeyDown(KeyCode.S))
        {
            startPlaying();
        }
	}

    public void lose()
    {
        playing = false;
        patternManager.lose();
        player.lose();
    }

    public void startPlaying()
    {
        patternManager.StartOver();
        patternManager.enabled = true;
        player.enabled = true;
        player.StartOver();
    }
}
