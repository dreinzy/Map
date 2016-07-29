using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Node : MonoBehaviour
{
    public delegate void NodeEventHandler(Node node);

    public event NodeEventHandler OnCompleted;
    public event NodeEventHandler OnEntered;
    public event NodeEventHandler OnHover;
    public event NodeEventHandler OnHoverExit;

    public Vector3 distance;
    public bool complete = false;

    public enum nodeType
    {
        Wreck,
        Fuel,
        Bonus,
        End}

    ;

    private int tier;
    private GameObject player;

    public nodeType type = nodeType.Fuel;

    public int Tier { get; set; }

    void Start()
    {
        this.tag = "Node";

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (complete && OnCompleted != null)
        {
            OnCompleted(this);
            complete = false;
        }
        distance = this.transform.position - player.transform.position;
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
        player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, 1f);
        player.GetComponent<Player>().FaceDirection(this);
        player.GetComponent<Player>().fuel--;
    }

    void OnMouseOver()
    {
        if (OnHover != null)
        {
            OnHover(this);
        }
    }

    public void OnMouseExit()
    {
        if (OnHoverExit != null)
        {
            OnHoverExit(this);
        }
    }

    public void NodeCompleted()
    {
        if (OnCompleted != null)
            OnCompleted(this);
    }


    // ** Only relevant for 2D ** //

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(this.name + " entered");
        if (OnCompleted != null)
            OnCompleted(this);
    }
}
