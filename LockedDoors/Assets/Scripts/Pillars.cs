using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pillars : MonoBehaviour
{
    public GameManager gameManager;
    public bool isPillarInteractive = false;
    public bool isPillarActivated;
    public GameObject activeIndicator;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

    public GameObject collectedIndicator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtInteractMsg.text = "Press [E] to Interact";
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!isPillarInteractive)
                {
                    txtInteractMsg.text = "I think i need to put something here...";
                }
                if(gameManager.isPillarActivatorCollected && !isPillarInteractive && !isPillarActivated)
                {
                    gameManager.pilarsActive += 1;
                    txtInteractMsg.text = "";
                    gameManager.isPillarQuestActive = true;
                    isPillarActivated = true;
                    activeIndicator.gameObject.SetActive(true);
                    gameManager.isPillarActivatorCollected = false;
                    collectedIndicator.gameObject.SetActive(false);
                }

                if (isPillarActivated)
                {
                    txtInteractMsg.text = "This is already activated";
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtInteractMsg.text = "";
        }
    }
}
