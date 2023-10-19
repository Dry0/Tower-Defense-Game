using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private Tower towerPrefab; // stores the towerPrefab
    [SerializeField] private TowerSlot[] towerSlots; 

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

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // checks if the mouse button is pressed

            if (hit.collider != null) //checks if the raycast hits something in the scene
            {

                int towerSlotIndex = Array.IndexOf(towerSlots, hit.collider.GetComponent<TowerSlot>()); // if you click on the towerslot it will proceed with this function
                
                if (towerSlotIndex != -1) //returns -1 if you dont click on the towerslot
                {
                    //PlaceTower(towerSlotIndex); // calls the function tower

                    if (towerSlots[towerSlotIndex].tower != null) // checks if it can put the towerPrefab in the towerSlot
                    {
                        return;
                    }

                    PlaceTower(towerSlotIndex); // calls the function tower 
                }
            }
        }

      
    }

    void PlaceTower(int towerSlotIndex) 
    {
        Tower tower = Instantiate(towerPrefab) as Tower; // change the return type of the Instantiate function to be the Tower class by casting it to the Tower class 
        towerSlots[towerSlotIndex].tower = tower; // instantiate the towerPrefab we instantly store it in a Tower tower variable 
        tower.transform.position = towerSlots[towerSlotIndex].transform.position; // transforms the towerslot in the prefab tower/ GameObject Tower
    }



    //int PlaceTower()
    //{
        //towerSlots.Add(Instantiate(towerPrefab));
        //int towerSlotIndex = towerSlots.Count - 1;
        //return towerSlotIndex;

    //}
}
