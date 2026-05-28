using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damaage = 1;
    public bool isDropZone = false;
    public Vector2 teleport;
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Entered {other.name}");
    }
    */
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if(isDropZone)
            {
                other.transform.position = teleport;
            }
            other.GetComponent<Player>().TakeDamage(damaage);
        }
    }
    /*
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"Exit {other.name}");
    }
    */
}
