using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{
    public delegate void Completed(Node node);

    public delegate void Entered(Node node);

    public event Completed OnCompleted;
    public event Entered OnEntered;

    private int tier;
    public bool complete = false;

    public bool Complete{ get; set; }

    public int Tier { get; set; }

    void Start()
    {
        this.tag = "Node";
    }

    void Update()
    {
        if (complete && OnCompleted != null)
        {
            OnCompleted(this);
            complete = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (OnEntered != null)
                OnEntered(this);
            
//            if (OnCompleted != null)
//                OnCompleted(this);
        }
    }

    void OnMouseDown()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, 1f);
        player.GetComponent<Player>().fuel--;
    }

    public void NodeCompleted()
    {
        if (OnCompleted != null)
            OnCompleted(this);
    }


    // ** Only relevant for 2D hereafter ** //

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(this.name + " entered");
        if (OnCompleted != null)
            OnCompleted(this);
    }
}
