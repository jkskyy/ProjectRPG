using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp = 30;
    int hp;
    int damage;
    private Animator _anim;
    private Rigidbody2D enemyRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        hp = maxHp;
        _anim.SetBool("dead", false);
    }

    private void Update()
    {
        if(enemyRigidbody.position.y < -6)
        {
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        _anim.SetBool("dead", true);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}

