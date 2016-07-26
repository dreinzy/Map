using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject[] NodeMenus;
    public GameObject OptionsMenu;

    private GameObject[] nodes;
    private Node activeNode;

    void Awake()
    {
        if (NodeMenus != null)
        {
            foreach (var menu in NodeMenus)
            {
                menu.SetActive(false);
            }
        }

        nodes = GameObject.FindGameObjectsWithTag("Node");

        if (nodes == null)
            //TODO: Handle possible error(no nodes in level)
            Debug.Log("No nodes found in scene");
        
        foreach (var node in nodes)
            node.GetComponent<Node>().OnEntered += NodeEntered;
        
    }

    void NodeEntered(Node node)
    {
        NodeMenus[0].SetActive(true);
        activeNode = node;
    }

    public void NodeCompleted()
    {
        activeNode.Complete = true;
        activeNode.complete = true;
        NodeMenus[0].SetActive(false);
    }
}
