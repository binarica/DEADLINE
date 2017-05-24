using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UITextWeapon : MonoBehaviour 
{
	// private MotherShip motherShip;
	//public int msEnergy;
	//public int energyNeeded;

    PlayerShooter playerShooter;
    public int ammoCount;
    public int ammoLimit;

    void Awake () 
	{
        playerShooter = GameObject.Find("Player").GetComponentInChildren<PlayerShooter>();
        //motherShip = GameObject.Find("MotherShip").GetComponent<MotherShip>();
    }
	
	void OnGUI () 
	{
        /*
		msEnergy = motherShip.collectedEnergy;
		energyNeeded = motherShip.neededEnergy;
        */

        ammoCount = playerShooter.currentAmmo;
        ammoLimit = playerShooter.maxAmmo;

        GetComponent<Text>().text = ammoCount.ToString() + " / " + ammoLimit.ToString();;

        //GetComponent<Text>().text = ammoCount.ToString();
    }
}
