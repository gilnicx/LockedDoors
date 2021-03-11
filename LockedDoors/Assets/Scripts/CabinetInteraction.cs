using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabinetInteraction : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

    public bool isChecked = false;
    public GameObject cabinetTray;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isChecked)
            {
                txtInteractMsg.text = "I already checked this...";
            }
            else
            {
                txtInteractMsg.text = "Press [E] to Interact";
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (gameManager.isCabinetInteractive)
                {
                    if (!isChecked)
                    {
                        cabinetTray.gameObject.SetActive(true);
                        //txtInteractMsg.text = "Its Empty...";
                        isChecked = true;
                    }
                }
                else
                {
                    txtInteractMsg.text = "I can't do this now...";
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
