using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D rigidbody2D;

    // Awake is called immediately when the object is created
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // This prevent a lot of cogs move outside the view while game run
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if(e != null)
        {
            e.Fix();
        }
        Destroy(gameObject);
    }

}
