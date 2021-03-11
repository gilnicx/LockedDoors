using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObstacleTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public Text txtInteractMsg;

    public void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            gameManager.playerHP += 1;
            if (gameManager.playerHP == 4)
            {
                txtInteractMsg.text = "You Died, Reloading Level...";
                Invoke("ReloadScene", 1f);
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Lvl6");
    }
}
