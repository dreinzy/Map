using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateFuelText : MonoBehaviour
{
    public Text txt;
    // Use this for initialization
    void Start()
    {
        txt = this.GetComponent<Text>();
        txt.text = "Fuel: ";
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }
}