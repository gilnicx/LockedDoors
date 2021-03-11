using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectShapeKeys : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

    public bool isCubeKey;
    public bool isCylinderKey;

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
                if (isCubeKey)
                {
                    gameManager.isKeyHolesActivatorCollected = true;
                    txtQuestUpdate.text = "Put this on the cube-shaped key hole";
                    this.gameObject.SetActive(false);
                    txtInteractMsg.text = "";
                    gameManager.whatKeyShape = "cube";
                }
                if (isCylinderKey)
                {
                    gameManager.isKeyHolesActivatorCollected = true;
                    txtQuestUpdate.text = "Put this on the cylindrical key hole";
                    this.gameObject.SetActive(false);
                    txtInteractMsg.text = "";
                    gameManager.whatKeyShape = "cylinder";
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