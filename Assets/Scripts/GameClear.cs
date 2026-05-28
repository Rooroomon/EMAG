using UnityEngine;

public class GameClear : MonoBehaviour
{
	public Player player;
	public GameObject goalObject;

	private Collider2D playerCollider;
	private Collider2D goalCollider;
	private bool isClear = false;

	void Start()
	{
		playerCollider = player.GetComponent<Collider2D>();
		goalCollider = goalObject.GetComponent<Collider2D>();
	}

	void Update()
	{
		if (!isClear && playerCollider.IsTouching(goalCollider))
		{
			isClear = true;
			Time.timeScale = 0f;
		}
	}
    
	void OnGUI()
	{
		if (!isClear) return;

		GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
		labelStyle.fontSize = 48;
		labelStyle.fontStyle = FontStyle.Bold;
		labelStyle.alignment = TextAnchor.MiddleCenter;

		float labelW = 320f;
		float labelX = (Screen.width - labelW) / 2f;
		float labelY = (Screen.height - 70f) / 2f;

		GUI.Label(new Rect(labelX, labelY, labelW, 70f), "Game Clear!", labelStyle);
	}
}
