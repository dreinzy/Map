using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text fuelGauge;


    public int fuel = 0;
    private int lastFuel = 0;


    // Use this for initialization
    void Start()
    {
        lastFuel = fuel;
        fuelGauge.text = "Fuel: " + fuel;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (fuel != lastFuel)
            fuelGauge.text = "Fuel: " + fuel;
    }
}