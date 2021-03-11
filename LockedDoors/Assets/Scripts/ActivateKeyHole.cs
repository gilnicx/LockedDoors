using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateKeyHole : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

    public bool isCubeKeyHole;
    public bool isCylinderKeyHole;

    public Material activeIndicator;

    public bool isThisKeyHoleActive = false;

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
            if (Input.GetKey(KeyCode.E) && gameManager.isKeyHolesActivatorCollected)
            {
                if(isCubeKeyHole && gameManager.whatKeyShape == "cube")
                {
                    this.gameObject.GetComponent<Renderer>().material = activeIndicator;
                    gameManager.keyHolesActive += 1;
                    txtQuestUpdate.text = "Find a way to open the door";
                    txtInteractMsg.text = "";
                    gameManager.whatKeyShape = "";
                    gameManager.isKeyHolesActivatorCollected = false;
                    isThisKeyHoleActive = true;
                }
                if (isCylinderKeyHole && gameManager.whatKeyShape == "cylinder")
                {
                    this.gameObject.GetComponent<Renderer>().material = activeIndicator;
                    gameManager.keyHolesActive += 1;
                    txtQuestUpdate.text = "Find a way to open the door";
                    txtInteractMsg.text = "";
                    gameManager.whatKeyShape = "";
                    gameManager.isKeyHolesActivatorCollected = false;
                    isThisKeyHoleActive = true;
                }
                if (isCubeKeyHole && gameManager.whatKeyShape != "cube" || isCylinderKeyHole && gameManager.whatKeyShape != "cylinder")
                {
                    txtInteractMsg.text = "The shape doesn't fit";
                }
            }
            if (Input.GetKey(KeyCode.E) && !gameManager.isKeyHolesActivatorCollected)
            {
                txtInteractMsg.text = "I think i need to find a shape that will fit...";
            }

            if (Input.GetKey(KeyCode.E) && isThisKeyHoleActive)
            {
                txtInteractMsg.text = "I've already activated this...";
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
