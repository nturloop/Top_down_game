using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    // Use this for initialization

    private PlayerMovement mvt;    
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public float TimeForAnimation;

    public Transform attacPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public bool isAttacking;


    private IEnumerator attack;

    void Start () {
        mvt = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
      
		
	}

    public IEnumerator Attack(int damage)
    {
        isAttacking = true;
        
        // if (timeBtwAttack <= 0)
        // {

        Collider2D[] enemyToDamage = Physics2D.OverlapCircleAll(attacPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemyToDamage.Length; i++)
                {
                    enemyToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    Debug.Log("hit player attack");
                }
        //timeBtwAttack = startTimeBtwAttack;



        yield return new WaitForSeconds(TimeForAnimation);
        isAttacking = false;
        //}
        //else
        //{
        // timeBtwAttack -= Time.deltaTime;
        // }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attacPos.position,attackRange);
    }
}
