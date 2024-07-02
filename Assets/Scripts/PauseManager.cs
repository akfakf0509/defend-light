using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseManager : MonoBehaviour
{
	private UIDocument uiDocument;
	private VisualElement mainContainer;
	private VisualElement resumeButton;
	private VisualElement quitButton;

	private void Awake()
	{
		uiDocument = GetComponent<UIDocument>();
		mainContainer = uiDocument.rootVisualElement.Q("MainContainer");
		resumeButton = uiDocument.rootVisualElement.Q("ResumeButton");
		resumeButton.RegisterCallback<ClickEvent>(ResumeGame);
		quitButton = uiDocument.rootVisualElement.Q("QuitButton");
		quitButton.RegisterCallback<ClickEvent>(LoadMenuScene);
	}
	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			PauseGame();
        }
    }

	private void PauseGame()
	{
		Time.timeScale = 0;
		mainContainer.style.display = DisplayStyle.Flex;
	}
	private void ResumeGame(ClickEvent _)
	{
		Time.timeScale = 1;
		mainContainer.style.display = DisplayStyle.None;
	}
	private void LoadMenuScene(ClickEvent _)
	{
		SceneManager.LoadScene(0);
	}
}
