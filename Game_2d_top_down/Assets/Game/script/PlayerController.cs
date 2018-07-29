using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    #region component
    private Rigidbody2D rgb;
    private PlayerMovement plyMVT;
    private DashPlayer dPly;
    private PlayerAttack plyAttack;
    #endregion

    #region statuts Variable
    private bool escapePress = false;
    public bool isDead = false;
    public bool isAttacking = false;
    public bool isMoving = false;
    public bool isDashing = false;

    private bool startDashing = false;
    private bool startMoving = false;
    private bool startAttacking = false;

    public bool inAction;

    #endregion

    private float xInput;
    private float yInput;

    
    public Vector3 MousePos2d;
    public Vector3 MousePosition;
    public int PlyDirection;



    public int damage;

 

    public float dashCD;
    // Use this for initialization
    void Start() {
        rgb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        plyMVT = GameObject.Find("Player").GetComponent<PlayerMovement>();
        dPly = GameObject.Find("Player").GetComponent<DashPlayer>();
        plyAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }
	
	// Update is called once per frame
	void Update () {
        GetInput();
        GetStatut();
    }

    private void FixedUpdate()
    {

        //GetDirection();
        GetMouseFacingPosition();
        PlayerControl();

        if (escapePress)
        { Application.Quit(); }  

    }

    private void GetInput()
    {

        MousePosition = Input.mousePosition;

        escapePress = Input.GetKeyDown(KeyCode.Escape);

            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
            startMoving = (xInput !=0f || yInput !=0f);

        startDashing = Input.GetKeyDown(KeyCode.LeftShift);
        startAttacking = Input.GetKey(KeyCode.Space);
        
    }

   
    
    private void GetMouseFacingPosition()
    {
        MousePos2d = MousePosition - Camera.main.WorldToScreenPoint(rgb.transform.position);
    }



    private void PlayerControl()
    {    
        plyMVT.Move(xInput, yInput);
        
        
        if (startAttacking && !inAction)
        {
            StartCoroutine( plyAttack.Attack(damage));
        }

        DashManagement(); 



    }

    public float Xinput()
    {
        return xInput;
    }
    public float Yinput()
    {
        return yInput;
    }

    private void GetStatut()
    {
        isAttacking = plyAttack.isAttacking;
        isMoving = plyMVT.confIsMoving;
        isDashing = dPly.isdashing;
        PlyDirection = plyMVT.playerDirection;

        if (isAttacking || isDashing)
        {
            inAction = true;
        }
        else
        {
            inAction = false;
        }

    }


    private void DashManagement()
    {
        if (dashCD >= -1)
        {
            dashCD -= Time.deltaTime;
        }
        
        if (startDashing && !inAction)
        {

            if (dashCD <= 0)
            {

                StartCoroutine(dPly.Dash());
                dashCD = 5.0f;


            }


        }
    }
}
