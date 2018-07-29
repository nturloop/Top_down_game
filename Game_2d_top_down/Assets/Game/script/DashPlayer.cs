using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayer : MonoBehaviour
{
    private PlayerMovement mvt;

    public float DashSpeed;
    private float dashTimer;
    public float startDashTime;
    private float tempSpeed;

    private float dashCooldown;
    public float dashCooldownTime;
    public bool isdashing;

    

    private void Start()
    {
        mvt = GetComponent<PlayerMovement>();
        dashTimer = startDashTime;

    }

    private void Update()
    {    
        }
    

public IEnumerator Dash()
    {
        tempSpeed = mvt.movementSpeed;
        mvt.movementSpeed = DashSpeed;
        isdashing = true;
        yield return new WaitForSeconds(dashTimer);
        mvt.movementSpeed = tempSpeed;
        isdashing = false;
        
    }
}


