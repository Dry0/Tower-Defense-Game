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
    [SerializeField] private float shootInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {  //If there are no targets there is no way for the tower to shoot at a target
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

        if (targets.Length == 0) // stops tower if there is no target
        {
            return;
        }

        float nearestDistance = 100; //  store the closest distance in a variable
        for (int i = 0; i < targets.Length; i++) 
        {
            float distance = Vector2.Distance(transform.position, targets[i].transform.position); // check what the distance is between the tower and target
            if (distance < nearestDistance)  // if the distance is smaller then the nearestDistance variabele
            {
                target = targets[i].transform; 
                nearestDistance = distance;
            }
        }
        target = targets[0].transform;

        LookAtTarget();
    }

    public void LookAtTarget() // btw this is a function
    { 
        Vector2 direction = target.position - transform.position; // looks for target
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction); // makes it rotate 
    }

    public IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval); // amount of time between shots
            GameObject projectileGameObject = Instantiate(projectilePrefab);

            Projectile projectile = projectileGameObject.GetComponent<Projectile>();
            projectileGameObject.transform.position = transform.position; // makes it so that if there are multiple towers in the lvl the projectiles wont spawn from only one tower but from all of them

            //Set the target of the Projectile to the target of the Tower
            projectile.target = target;
        }
    }
}
