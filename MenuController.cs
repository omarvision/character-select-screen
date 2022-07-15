using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI txtInfo = null;
    private List<GameObject> lstShips = new List<GameObject>();

    private void Start()
    {
        LoadPlayerShips();
    }
    private void LoadPlayerShips()
    {
        Globals.GetAllPlayerShipNames();

        //load all the ships into the scene
        foreach (string nameOnly in Globals.lstShipNames)
        {
            //1. load into memory  (Assets/Resources...")
            GameObject objPrefab = Resources.Load<GameObject>("Ships/" + nameOnly);

            //2. put it in the scene
            GameObject objShip = Instantiate(objPrefab, this.transform);
            objShip.name = nameOnly;
            objShip.transform.position = Vector3.zero;
            lstShips.Add(objShip);
        }

        //show current selected ship
        ShowSelectedShip();
    }
    private void ShowSelectedShip()
    {
        //loop thru list of scene ships, activate selected / de-activate unselected
        for (int i = 0; i < lstShips.Count; i++)
        {
            if (i == Globals.selectedShip)
                lstShips[i].SetActive(true);
            else
                lstShips[i].SetActive(false);
        }

        //show the ships info (name, speed)
        float speed = lstShips[Globals.selectedShip].GetComponent<Player>().Movespeed;
        txtInfo.text = string.Format("name: {0}\nspeed: {1}", lstShips[Globals.selectedShip].name, speed);
    }

    public void btnPrev_click()
    {
        Globals.selectedShip -= 1;
        if (Globals.selectedShip < 0)
            Globals.selectedShip = Globals.lstShipNames.Count - 1;
        ShowSelectedShip();
    }
    public void btnNext_click()
    {
        Globals.selectedShip += 1;
        if (Globals.selectedShip > Globals.lstShipNames.Count - 1)
            Globals.selectedShip = 0;
        ShowSelectedShip();
    }
    public void btnPlay_click()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
}
