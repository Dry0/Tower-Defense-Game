using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private float speed = 10;

    public static event Action OnNewProjectile;
    public static event Action OnHitEnemy;
    // Start is called before the first frame update
    void Start()
    {
        OnNewProjectile?.Invoke();
    }

    // Update is called once per frame
    void Update()
    { // if target == null it wont try to acces transform
        if (target == null) 
        {
            Destroy(gameObject); 
            return;
        }
        // makes the projectile move toward the target
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        //Debug.Log("test");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy") 
        {
            OnHitEnemy?.Invoke(); // zo kan je een event gebruiken

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
