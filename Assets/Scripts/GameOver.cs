using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Player player;

    private Vector3 startPosition=Vector3.zero;
    private Rigidbody2D rb;
    private bool isGameOver = false;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        player.OnHealthChange += CheckHealth;
    }

    void CheckHealth()
    {
        if (player.currentHp <= 0 && !isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0f;
        }
    }

    void OnGUI()
    {
        if (!isGameOver) return;

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 36;

        float btnW = 200f;
        float btnH = 60f;
        float x = (Screen.width - btnW) / 2f;
        float y = (Screen.height - btnH) / 2f;

        if (GUI.Button(new Rect(x, y, btnW, btnH), "Retry", buttonStyle))
        {
            Retry();
        }
    }

    void Retry()
    {
        isGameOver = false;
        player.transform.position = startPosition;
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
        player.ResetPlayer();
        Time.timeScale = 1f;
    }
}
