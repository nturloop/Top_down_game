using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {


    [SerializeField]
    protected float speed;

    [SerializeField]
    protected Rigidbody2D rgb;

    [SerializeField]
    protected Vector2 velo;
    protected bool isMoving;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {
        Move();
	}

    public void Move()
    {
        rgb.velocity = new Vector2(Speed, Speed) * velo;
    }


    public bool IsMoving {
    get {
            return isMoving;
        }
        set
        {
            isMoving = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
}
