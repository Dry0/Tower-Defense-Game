using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab; // stores the towerPrefab
    [SerializeField] private GameObject[] towerSlots; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { // checks if we clicked on one if the towerslots
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // shoot a Raycast from the mousePosition to the world
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        }

        //if (hit.collider != null) //checks if the raycast hits something in the scene
        //{

        //}
    }
}
