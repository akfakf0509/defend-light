using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
	private UIDocument uiDocument;
    private VisualElement startButton;
    private VisualElement exitButton;

	private void Start()
	{
		uiDocument = GetComponent<UIDocument>();

		startButton = uiDocument.rootVisualElement.Q("PlayButton");
		startButton.RegisterCallback<ClickEvent>(PlayGame);

		exitButton = uiDocument.rootVisualElement.Q("ExitButton");
		exitButton.RegisterCallback<ClickEvent>(ExitGame);
	}

	private void PlayGame(ClickEvent _)
	{
		SceneManager.LoadScene(1);
	}
	private void ExitGame(ClickEvent _)
    {
        Application.Quit();
    }
}
