using UnityEngine;
using System.Collections;

public class SpawnNodes : MonoBehaviour
{
    public GameObject[] tier1;
    public GameObject[] tier2;
    public GameObject[] tier3;
    public GameObject[] tier4;
    public GameObject[] tier5;
    public GameObject[] tier6;
    public GameObject[] tier7;
    public GameObject[] tier8;
    public GameObject endNode;
    public int per1, per2, per, per4, per5, per6, per7, per8;
    private static readonly System.Random random = new System.Random();
    public Sprite[] sprites;
    private GameObject[] nodes;

    // Use this for initialization
    void Start()
    {
        endNode.SetActive(false);
        nodes = GameObject.FindGameObjectsWithTag("Node");
        foreach (var node in nodes)
            node.GetComponent<Node>().OnCompleted += NodeCompleted;
        AssignSprites();
        SpawnTier(0);
    }

    private void AssignSprites()
    {
        int l = sprites.Length;
        foreach (var node in nodes)
        {
            int r = random.Next(0, l);
            node.GetComponent<SpriteRenderer>().sprite = sprites[r];
            node.SetActive(false);
        }
    }

    void NodeCompleted(Node node)
    {
        SpawnTier(node.Tier + 1);
    }

    void SpawnTier(int tierNo)
    {
        int r = 0;
        int count = 0;
        switch (tierNo)
        {            
            case 0:
                do
                {
                    r = random.Next(0, tier1.Length);
                    if (!tier1[r].activeSelf)
                    {
                        tier1[r].SetActive(true);
                        count++;
                    }
                } while(count < per1);
                foreach (GameObject node in tier1)
                {
                    node.GetComponent<Node>().Tier = tierNo;
                }                
                break;
            case 1:
                count = 0;
                do
                {
                    r = random.Next(0, tier2.Length);
                    if (!tier2[r].activeSelf)
                    {
                        tier2[r].SetActive(true);
                        count++;
                    }
                } while(count < per2);
                foreach (GameObject node in tier2)
                {
                    node.GetComponent<Node>().Tier = tierNo;
                }   
                break;
            case 2:
                count = 0;
                do
                {
                    r = random.Next(0, tier3.Length);
                    if (!tier3[r].activeSelf)
                    {
                        tier3[r].SetActive(true);
                        count++;
                    }
                } while(count < per);
                foreach (GameObject node in tier3)
                {
                    node.GetComponent<Node>().Tier = tierNo;
                }  
                break;
            case 3:
                count = 0;
                do
                {
                    r = random.Next(0, tier4.Length);
                    if (!tier4[r].activeSelf)
                    {
                        tier4[r].SetActive(true);
                        count++;
                    }
                } while(count < per4);
                foreach (GameObject node in tier4)
                {
                    node.GetComponent<Node>().Tier = tierNo;
                }  
                break;
            case 4:
                count = 0;
                do
                {
                    r = random.Next(0, tier5.Length);
                    if (!tier5[r].activeSelf)
                    {
                        tier5[r].SetActive(true);
                        count++;
                    }
                } while(count < per5);
                foreach (GameObject node in tier5)
                {
                    node.GetComponent<Node>().Tier = tierNo;
                }  
                break;
            case 5:
                count = 0;
                do
                {
                    r = random.Next(0, tier6.Length);
                    if (!tier6[r].activeSelf)
                    {
                        tier6[r].SetActive(true);
                        count++;
                    }
                } while(count < per6);
                foreach (GameObject node in tier6)
                {
                    node.GetComponent<Node>().Tier = tierNo;
                }  
                break;
            case 6:
                count = 0;
                do
                {
                    r = random.Next(0, tier7.Length);
                    if (!tier7[r].activeSelf)
                    {
                        tier7[r].SetActive(true);
                        count++;
                    }
                } while(count < per7);
                foreach (GameObject node in tier7)
                {
                    node.GetComponent<Node>().Tier = tierNo;
                }  
                break;
            case 7:
                count = 0;
                do
                {
                    r = random.Next(0, tier8.Length);
                    if (!tier8[r].activeSelf)
                    {
                        tier8[r].SetActive(true);
                        count++;
                    }
                } while(count < per8);
                foreach (GameObject node in tier8)
                {
                    node.GetComponent<Node>().Tier = tierNo;
                }  
                break;
            case 8:
                endNode.SetActive(true);
                break;
            default:
                break;
        }
    }
}
