using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text fuelGauge;
    public Image fuelMeter;
    public AudioClip move;
    public AudioClip bonus;
    public AudioClip wreck;
    public AudioClip refuel;

    private AudioSource audio;
    public int fuel;
    private int lastFuel = 0;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        lastFuel = fuel;
        fuelGauge.text = "Fuel: " + fuel;
    }

    void Update()
    {
        if (fuel != lastFuel)
        {
            fuelGauge.text = "Fuel: " + fuel;
            fuelMeter.fillAmount = fuel / 30.0f;
        }
    }

    public void FaceDirection(Node node)
    {
        //TODO: Rotate ship to look at node, this doesn't work:
        this.transform.LookAt(node.transform);
        audio.clip = move;
        audio.Play();
    }

    public void AddFuel(int fuelFound)
    {
        audio.clip = refuel;
        audio.Play();
        fuel += fuelFound;
        if (fuel > 30)
            fuel = 30;
    }

    public void Bonus()
    {
        audio.clip = bonus;
        audio.Play();
    }

    public void Wreck()
    {
        audio.clip = wreck;
        audio.Play();
    }
}