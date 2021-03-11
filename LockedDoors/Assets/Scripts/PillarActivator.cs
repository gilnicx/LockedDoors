using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillarActivator : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

    public GameObject collectedIndicator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtInteractMsg.text = "Press [E] to Pickup";
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!gameManager.isPillarActivatorCollected)
                {
                    gameManager.isPillarActivatorCollected = true;
                    gameManager.isPillarQuestActive = false;
                    txtQuestUpdate.text = "Put this on the Pillar";
                    txtInteractMsg.text = "";
                    this.gameObject.SetActive(false);
                    collectedIndicator.gameObject.SetActive(true);
                }
                else
                {
                    txtInteractMsg.text = "I cant carry more than one";
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
