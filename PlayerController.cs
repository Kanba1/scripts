using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    float horizontal;
    float vertical;
    public float movespeed = 3.0f;
    public float timeInvincible = 2.0f;
    //health
    public int maxHealth = 5;

    bool isInvincible;
    float invincibleTimer;

    public int health { get { return currentHealth; } } //Properties are used like variables, not like functions.
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        rb = GetComponent<Rigidbody2D>();

        currentHealth = 4;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //A private float called invincibleTimer. 
        //This will store how much time Ruby has left being invincible before reverting to being hurtable. 
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.x = position.x + movespeed * horizontal * Time.deltaTime;
        position.y = position.y + movespeed * vertical * Time.deltaTime;

        rb.MovePosition(position);
        
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)//since -1(negastive numbers) does health damage
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);//public static float Clamp(float value, float min, float max); 
        //Clamps the given value between the given minimum float and maximum float values. Returns the given value if it is within the min and max range
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(currentHealth + "/" + maxHealth);
        
    }
}
