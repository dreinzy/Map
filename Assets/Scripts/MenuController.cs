using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject[] NodeMenus;
    public GameObject OptionsMenu;
    public GameObject GameFinishedMenu;
    public GameObject FuelGague;
    public GameObject NodeInfo;

    private GameObject[] nodes;
    private Node activeNode;
    private bool optionsToggle = false;

    void Awake()
    {
        if (NodeMenus != null)
            foreach (var menu in NodeMenus)
                menu.SetActive(false);

        if (OptionsMenu != null)
            OptionsMenu.SetActive(false);

        if (NodeInfo != null)
            NodeInfo.SetActive(false);

        if (GameFinishedMenu != null)
            GameFinishedMenu.SetActive(false);
        
        nodes = GameObject.FindGameObjectsWithTag("Node");

        if (nodes == null)
            //TODO: Handle possible error(no nodes in level)
            Debug.Log("No nodes found in scene");
        else
        {
            foreach (var node in nodes)
            {
                node.GetComponent<Node>().OnEntered += NodeEntered;
                node.GetComponent<Node>().OnHover += NodeHover;
                node.GetComponent<Node>().OnHoverExit += NodeExit;
                node.GetComponent<Node>().OnCompleted += NodeCompleted;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && OptionsMenu != null)
        {
            optionsToggle = OptionsMenu.activeSelf;
            OptionsMenu.SetActive(!optionsToggle);
        }
    }

    void NodeEntered(Node node)
    {
        if (node.type == Node.nodeType.Fuel)
            NodeMenus[0].SetActive(true);
        else if (node.type == Node.nodeType.Wreck)
            NodeMenus[1].SetActive(true);
        else if (node.type == Node.nodeType.Bonus)
            NodeMenus[2].SetActive(true);
        else if (node.type == Node.nodeType.End)
            GameFinishedMenu.SetActive(true);
        activeNode = node;
    }

    void NodeHover(Node node)
    {
        NodeInfo.SetActive(true);
        NodeInfo.GetComponentInChildren<Text>().text = "Distance: " + node.distance.magnitude.ToString("#.##") + "\n" + node.type;
        RectTransform rect = NodeInfo.GetComponent<RectTransform>();
        rect.transform.position = Input.mousePosition;
    }

    void NodeExit(Node node)
    {
        NodeInfo.SetActive(false);
    }

    public void NodeCompleted()
    {
        activeNode.complete = true;
        foreach (var menu in NodeMenus)
        {
            menu.SetActive(false);
        }
    }

    private void NodeCompleted(Node node)
    {
        node.gameObject.SetActive(false);
    }

    private void LevelFinished()
    {
        GameFinishedMenu.SetActive(true);
    }

    public void SelectLevel(int lvlNo)
    {
        SceneManager.LoadScene(lvlNo);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
