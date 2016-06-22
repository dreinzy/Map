using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{
    public delegate void Completed(Node node);

    public event Completed OnCompleted;

    private bool complete = false;
    private int tier;

    public bool Complete{ get; set; }

    public int Tier { get; set; }

    // Use this for initialization
    void Start()
    {
        this.tag = "Node";
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(this.name + " entered");
        if (OnCompleted != null)
            OnCompleted(this);
    }

    void OnMouseDown()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, 1f);
    }
}
