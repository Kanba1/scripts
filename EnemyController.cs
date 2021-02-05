using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D enemyrb;
    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = enemyrb.position;
        position.x += Time.deltaTime * speed;
        enemyrb.MovePosition(position);//syntax is [ a.b(c); ]
    }
}
