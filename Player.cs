using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Movespeed = 6;

    private void Update()
    {
        //move the ship
        float vert = Input.GetAxis("Vertical");     // -1..0..1
        float horz = Input.GetAxis("Horizontal");
        this.transform.Translate(new Vector3(horz * Movespeed * Time.deltaTime, vert * Movespeed * 0.5f * Time.deltaTime, 0));
    }
}
