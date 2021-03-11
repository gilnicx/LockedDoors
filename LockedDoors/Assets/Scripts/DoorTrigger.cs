using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public GameManager gameManager;

    public Text txtInteractMsg;
    public Text txtQuestUpdate;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
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
                //level conditions
                switch (gameManager.levelAt)
                {
                    case 1:
                        if (!gameManager.isKeyCollected)
                        {
                            txtQuestUpdate.text = "Look for the key";
                            txtInteractMsg.text = "The door is locked, I need to find a key...";
                        }
                        else
                        {
                            txtInteractMsg.text = "Loading next level";
                            Invoke("LoadNextLevel", 0.5f);
                        }
                        break;
                    case 2:
                        if (gameManager.itemsCollected != 3)
                        {
                            txtInteractMsg.text = "I need to find more items...";
                        }
                        else
                        {
                            txtInteractMsg.text = "Loading next level";
                            Invoke("LoadNextLevel", 0.5f);
                        }
                        break;
                    case 3:
                        if (gameManager.pilarsActive != 2)
                        {
                            txtInteractMsg.text = "I need to activate the pillars...";
                            gameManager.isPillarQuestActive = true;
                        }
                        else
                        {
                            txtInteractMsg.text = "Loading next level";
                            Invoke("LoadNextLevel", 0.5f);
                        }
                        break;
                    case 4:
                        if (!gameManager.isLvl4KeyCollected)
                        {
                            txtInteractMsg.text = "I need to find a key...";
                            gameManager.isCabinetInteractive = true;
                        }
                        else
                        {
                            txtInteractMsg.text = "Loading next level";
                            Invoke("LoadNextLevel", 0.5f);
                        }
                        break;
                    case 5:
                        if(gameManager.keyHolesActive == 2)
                        {
                            txtInteractMsg.text = "Loading next level";
                            Invoke("LoadNextLevel", 0.5f);
                        }
                        else
                        {
                            txtInteractMsg.text = "I need to find something to open it...";
                        }
                        break;
                    case 6:
                        txtInteractMsg.text = "Loading next level";
                        Invoke("LoadNextLevel", 0.5f);
                        break;
                    case 7:
                        if (!gameManager.isKeyCollected)
                        {
                            txtQuestUpdate.text = "Look for the key";
                            txtInteractMsg.text = "The door is locked, I need to find a key...";
                        }
                        else
                        {
                            txtInteractMsg.text = "Loading next level";
                            Invoke("LoadNextLevel", 0.5f);
                        }
                        break;
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

    //loads the next level based on the current level
    void LoadNextLevel()
    {
        int LvlToLoad = gameManager.levelAt + 1;
        SceneManager.LoadScene("Lvl" + LvlToLoad);
    }
}
