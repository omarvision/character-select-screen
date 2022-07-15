using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    //Purpose: load ship player selected (at menu scene)

    private void Start()
    {
        //this is in case we run the level scene (we didnt run menun scene first)
        if (Globals.lstShipNames.Count == 0)
            Globals.GetAllPlayerShipNames();

        LoadPlayerShip();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    private void LoadPlayerShip()
    {
        //1. load into memory
        string nameOnly = Globals.lstShipNames[Globals.selectedShip];
        GameObject objPrefab = Resources.Load<GameObject>("Ships/" + nameOnly);

        //2. put into scene
        GameObject objShip = Instantiate(objPrefab);
        objShip.name = nameOnly;
        objShip.transform.position = Vector3.zero;
    }
}
