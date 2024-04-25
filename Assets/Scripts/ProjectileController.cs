using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private Rigidbody2D rb2d;

    private int hits = 3;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnBecameVisible()
    {
        rb2d.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            TextMeshProUGUI score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
            int score_val = int.Parse(score.text);
            score.text = (score_val + 2).ToString();
        }
        if (collision.gameObject.tag == "Tree")
        {
            TextMeshProUGUI score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
            int score_val = int.Parse(score.text);
            score.text = (score_val - 1).ToString();
        }
        transform.up = Vector2.Reflect(transform.up, collision.contacts[0].normal);
        rb2d.velocity = transform.up * speed;

        hits--;
        if (hits == 0)
        {
            Destroy(gameObject);
        }
    }
}
