using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectLvl4Key : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

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
                gameManager.isLvl4KeyCollected = true;
                txtInteractMsg.text = "";
                this.gameObject.SetActive(false);
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
