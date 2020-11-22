using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    public GameObject Win;
    // Start is called before the first frame update
    void Start()
    {
        Win.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Win.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
