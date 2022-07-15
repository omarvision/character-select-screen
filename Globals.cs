using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Globals
{
    public static List<string> lstShipNames = new List<string>();
    public static int selectedShip = 0;

    public static void GetAllPlayerShipNames()
    {
        //populate the ship names by reading from the assets/resources folder
        foreach (string file in Directory.EnumerateFiles(Application.dataPath + "/Resources/Ships", "*.prefab"))
        {
            string nameOnly = Path.GetFileNameWithoutExtension(file);
            if (Globals.lstShipNames.Contains(nameOnly) == false)
                Globals.lstShipNames.Add(nameOnly);
        }
    }
}
