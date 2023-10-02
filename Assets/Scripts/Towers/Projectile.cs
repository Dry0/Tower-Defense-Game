using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { // makes the projectile move toward the target
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        Debug.Log("test");

        if (target == null) 
        {
            Destroy(gameObject); return;
        }
    }

    void onTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy") 
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
