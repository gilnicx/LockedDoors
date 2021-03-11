using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AIFollow : MonoBehaviour
{
    public GameManager gameManager;
    public Text txtInteractMsg;

    public Rigidbody aiRigidBody;
    public NavMeshAgent navMeshAgent;

    public GameObject player;

    public bool isAIActive = false;
    // Start is called before the first frame update
    void Start()
    {
        aiRigidBody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isAIActive)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
        
    }

    public void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            isAIActive = true;
        }
    }
    public void OnTriggerExit(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            isAIActive = false;
        }
    }

    public void OnCollisionEnter(Collision actor)
    {
        if (actor.gameObject.CompareTag("Player"))
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
        SceneManager.LoadScene("Lvl7");
    }

}
