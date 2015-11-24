using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	public void _MainMenuScene()
	{
		Application.LoadLevel ("OpenScene");
	}

	public void _FirstLevelScene()
	{
		Application.LoadLevel ("test level version 1");
	}
}
