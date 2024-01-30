using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public bool dead;
    public bool jump;
    public bool attack;
    public int attackCooldown;
    public bool plungeAttack;
    public int jumpCooldown;
    public float jumpHeight;
    public int damage = 10;
    public float range = 0.4f;
    public float plungeRange = 0.6f;
    public int maxHp = 100;
    public int hp;
    public int maxMana = 20;
    public int mana;
    public int armor;
    public bool paused = false;
    public GameObject _effects;
    public Rigidbody2D myRigidbody;
    public Transform rangePoint;
    public Transform plungeRangePoint;
    public LayerMask enemyLayers;
    private Animator _anim;


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Animator is NULL!!");
        }
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead && !paused)
        {
            if (!jump)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    speed = 2;
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX == true) GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX = false;
                    myRigidbody.velocity = Vector2.right * speed;
                    _anim.SetFloat("speed", speed);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    speed = 2;
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX == false) GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX = true;
                    myRigidbody.velocity = Vector2.left * speed;
                    _anim.SetFloat("speed", speed);
                }
                else if (jumpCooldown == 0 && Input.GetKeyDown(KeyCode.UpArrow))
                {
                    jump = true;
                    jumpCooldown = 5;
                    StartCoroutine(waitForJump());
                    var jumpEffect = Instantiate(_effects);
                    jumpEffect.transform.position = myRigidbody.transform.position;
                    jumpHeight = 5;
                    myRigidbody.velocity = Vector2.up * jumpHeight;
                    _anim.SetBool("jump", jump);
                }
                else if (attackCooldown == 0 && Input.GetKeyDown(KeyCode.Space))
                {
                    attack = true;
                    Attack();
                    attackCooldown = 5;
                    _anim.SetBool("attack", attack);
                    StartCoroutine(waitForAttack());
                }
                else
                {
                    myRigidbody.velocity = Vector2.zero;
                    speed = 0;
                    _anim.SetBool("jump", jump);
                    _anim.SetBool("attack", attack);
                    _anim.SetBool("plungeAttack", plungeAttack);
                    _anim.SetFloat("speed", speed);
                    _anim.transform.position = myRigidbody.transform.position;
                }
            }
            if (jump && Input.GetKeyDown(KeyCode.Space))
            {
                plungeAttack = true;
                PlungeAttack();
                _anim.SetBool("plungeAttack", plungeAttack);
                myRigidbody.velocity = Vector2.down * jumpHeight/3;
            }
        }
    }

    IEnumerator waitForJump()
    {
        yield return new WaitForSecondsRealtime(2);
        jumpCooldown = 0;
        StopCoroutine(waitForJump());
    }
    IEnumerator waitForAttack()
    {
        attack = false;
        yield return new WaitForSecondsRealtime(2);
        attackCooldown = 0; 
        StopCoroutine(waitForAttack());
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(rangePoint.position, range, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    
    void PlungeAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(plungeRangePoint.position, plungeRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage*2);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(rangePoint.position, range);
        Gizmos.DrawWireSphere(plungeRangePoint.position, plungeRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Ground")
        {
            if(plungeAttack)
            {
                var jumpEffect = Instantiate(_effects);
                jumpEffect.transform.position = myRigidbody.transform.position;
            }
            jump = false;
            plungeAttack = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Game End")
        {
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        }
    }
}
