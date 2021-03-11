using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectKey : MonoBehaviour
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
                gameManager.isKeyCollected = true;
                txtQuestUpdate.text = "Look for the door";
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
