using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Level Info")]
    public int levelAt;
    public Text txtQuestUpdate;
    public Text txtInteractMsg;

    [Header("Lvl1")]
    public bool isKeyCollected = false;

    [Header("Lvl2")]
    public int itemsCollected;

    [Header("Lvl3")]
    public bool isPillarActivatorCollected = false;
    public int pilarsActive;
    public bool isPillarQuestActive;

    [Header("Lvl4")]
    public bool isLvl4KeyCollected;
    public int onWhatCabinet;
    public GameObject keyLocation1;
    public GameObject keyLocation2;
    public GameObject keyLocation3;
    public bool isCabinetInteractive = false;

    [Header("Lvl5")]
    public bool isKeyHolesActivatorCollected = false;
    public int keyHolesActive;
    public string whatKeyShape;

    [Header("Lvl6")]
    public int playerHP = 0;
    public Image hpIndicator;
    public float lvl6Timer = 120f;

    [Header("Lvl7")]
    public string x;


    // Start is called before the first frame update
    void Start()
    {
        //start condition for level 4, key spawning *****************  
        if (levelAt == 4)
        {
            onWhatCabinet = Random.Range(1, 4);
            switch (onWhatCabinet)
            {
                case 1:
                    keyLocation1.gameObject.SetActive(true);
                    break;
                case 2:
                    keyLocation2.gameObject.SetActive(true);
                    break;
                case 3:
                    keyLocation3.gameObject.SetActive(true);
                    break;
            }
        }
        //end level 4 condition *************************************
    }

    // Update is called once per frame
    void Update()
    {
        //this is for level 2 - 5
        switch (levelAt)
        {
            case 1:
                break;
            case 2: //this updates the quest log for lvl2
                if (itemsCollected != 3)
                {
                    txtQuestUpdate.text = "Collect 3 important items. " + itemsCollected + "/3";
                }
                break;
            case 3: //this updates the quest log for lvl3
                if (itemsCollected != 3 && isPillarQuestActive)
                {
                    if (pilarsActive == 2)
                    {
                        txtQuestUpdate.text = "Open the Door";
                    }
                    else
                    {
                        txtQuestUpdate.text = "Activate Pillars " + pilarsActive + "/2";
                    }
                }
                break;
            case 4: //this updates the quest log for lvl4
                if (isLvl4KeyCollected)
                {
                    txtQuestUpdate.text = "Go to the door";
                }
                break;
            case 5: //this updates the quest log for lvl5
                if (keyHolesActive == 2)
                {
                    txtQuestUpdate.text = "Go to the door";
                }
                break;
            case 6:
                lvl6Timer -= Time.deltaTime;
                TimeFormat();
                if (lvl6Timer <= 0)
                {
                    txtInteractMsg.text = "You inhaled a lot of toxic gas and died... \n Reloading Level...";
                    hpIndicator = hpIndicator.GetComponent<Image>();
                    hpIndicator.color = new Color(hpIndicator.color.r, hpIndicator.color.g, hpIndicator.color.b, 0.90f);
                    Invoke("ReloadScene", 1f);
                }

                hpIndicator = hpIndicator.GetComponent<Image>();
                switch (playerHP)
                {
                    case 1:
                        hpIndicator.color = new Color(hpIndicator.color.r, hpIndicator.color.g, hpIndicator.color.b, 0.25f);
                        break;
                    case 2:
                        hpIndicator.color = new Color(hpIndicator.color.r, hpIndicator.color.g, hpIndicator.color.b, 0.5f);
                        break;
                    case 3:
                        hpIndicator.color = new Color(hpIndicator.color.r, hpIndicator.color.g, hpIndicator.color.b, 0.75f);
                        break;
                    case 4:
                        hpIndicator.color = new Color(hpIndicator.color.r, hpIndicator.color.g, hpIndicator.color.b, 1f);
                        break;
                }
                break;
            case 7:
                hpIndicator = hpIndicator.GetComponent<Image>();
                switch (playerHP)
                {
                    case 1:
                        hpIndicator.color = new Color(hpIndicator.color.r, hpIndicator.color.g, hpIndicator.color.b, 0.25f);
                        break;
                    case 2:
                        hpIndicator.color = new Color(hpIndicator.color.r, hpIndicator.color.g, hpIndicator.color.b, 0.5f);
                        break;
                    case 3:
                        hpIndicator.color = new Color(hpIndicator.color.r, hpIndicator.color.g, hpIndicator.color.b, 0.75f);
                        break;
                    case 4:
                        hpIndicator.color = new Color(hpIndicator.color.r, hpIndicator.color.g, hpIndicator.color.b, 1f);
                        break;
                }
                break;
        }

    }

    void TimeFormat()
    {
        float minutes = Mathf.Floor(lvl6Timer / 60);
        float seconds = lvl6Timer % 60;
        txtQuestUpdate.text = "Look for the door before the time runs out... " + minutes.ToString() + ":" + Mathf.RoundToInt(seconds);

    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Lvl" + levelAt);
    }
}
