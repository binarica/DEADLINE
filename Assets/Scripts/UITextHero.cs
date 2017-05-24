using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UITextHero : MonoBehaviour 
{
    /*
	private PlayerInventory playerInventory;
    private MotherShip motherShip;
    public int playerEnergy;
    public int energyNeeded;
    */

    PlayerHealth playerHealth;
    public float health;

    void Awake () 
	{
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
     
        /*
		playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        motherShip = GameObject.Find("MotherShip").GetComponent<MotherShip>();
        */
    }
	
	void OnGUI () 
	{
        /*
		playerEnergy = playerInventory.collectedEnergy;
        energyNeeded = motherShip.neededEnergy;
        */

        health = playerHealth.currentHealth;

        GetComponent<Text>().text = health.ToString();
    }
}
