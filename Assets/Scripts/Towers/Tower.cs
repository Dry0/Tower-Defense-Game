using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    //Transform target;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  //If there are no targets there is no way for the tower to shoot at a target
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

        if (targets.Length == 0) // stops tower if there is no target
        {
            return;
        }

        target = targets[0].transform;

        LookAtTarget();
    }

    public void LookAtTarget()
    {
        Vector2 direction = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    //public bool IEnumerator Shoot()  
    //{
        //StartCoroutine(Shoot());
    //}
}
