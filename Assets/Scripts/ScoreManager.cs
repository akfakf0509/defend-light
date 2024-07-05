using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
	public static UnityEvent<int> scoreAddEvent = new();

	[SerializeField] private UIDocument scoreUIDocument;
	private Label scoreTextElement;

	private int score = 0;

	private void Awake()
	{
		scoreAddEvent.AddListener(HandleScoreUpdateEvent);
		scoreTextElement = scoreUIDocument.rootVisualElement.Q<Label>("ScoreLabel");
	}

	private void HandleScoreUpdateEvent(int value)
	{
		score += value;
		scoreTextElement.text = "Score: " + score;
	}
}
