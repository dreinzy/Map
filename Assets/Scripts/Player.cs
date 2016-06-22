using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public delegate void FuelUsed();

    public event FuelUsed OnFuelUsed;

    private int fuel = 0;

    public int Fuel { get; set; }

    // Use this for initialization
    void Start()
    {
        fuel = 30;
    }
	
    // Update is called once per frame
    void Update()
    {
    }
}
