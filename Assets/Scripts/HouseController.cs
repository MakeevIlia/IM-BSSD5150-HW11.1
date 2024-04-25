using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class HouseController : MonoBehaviour
{
    [SerializeField]
    Transform projectileSpawnPoint;

    Rigidbody2D m_Rigidbody;

    int treesLeft = 3;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (treesLeft > 0)
            {
                GameObject pan = GameObject.Find("Panel");
                Image[] hudTrees = pan.GetComponentsInChildren<Image>();
                Destroy(hudTrees[hudTrees.Length - 1]);
                GameObject tree = Instantiate(Resources.Load("Projectile"),
                    projectileSpawnPoint.transform.position,
                    transform.rotation) as GameObject;
            }
        }
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        m_Rigidbody.rotation += -1 * h;
    }
}
