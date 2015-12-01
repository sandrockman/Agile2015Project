using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public Canvas PauseScreen;
    bool isPaused = false;

	// Use this for initialization
	void Start () {
        PauseScreen.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    void Pause()
    {
        if(isPaused)
        {
            PauseScreen.enabled = false;
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
            PauseScreen.enabled = true;
        }
    }

    public void _CallPause()
    {
        Pause();
    }
}
