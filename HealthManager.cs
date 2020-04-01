using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public float maxHealth;
    public float currHealth;

    public PlayerController thePlayer;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCount;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;

    public float respawnLength;

    public GameObject deathEffect;
    public Image blackScreen;
    private bool isFadeToBlack;
    private bool isFadeFromBlack;
    public float fadeSpeed;
    public float waitForFade;


    public Image healthBar;


    // Use this for initialization
    void Start () {
        currHealth = maxHealth;

        
        //thePlayer = FindObjectOfType<PlayerController>();


        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (invincibilityCounter >= 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCount -= Time.deltaTime;

            if (flashCount <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCount = flashLength;
            }
            if (invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }

        if (isFadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }

        if (isFadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }

        healthBar.fillAmount = (currHealth/maxHealth);

    }

    public void HurtPlayer(int damageValue, Vector3 direction)
    {
        if (invincibilityCounter<= 0)
        {
            currHealth -= damageValue;

            if (currHealth <= 0)
            {
                Respawn();
            }

            else
            {
                thePlayer.Knockback(direction);

                invincibilityCounter = invincibilityLength;

                playerRenderer.enabled = false;

                flashCount = flashLength;
            }
        }
    }

    public void Respawn()
    {

        //currHealth = maxHealth;
        //thePlayer.transform.position = respawnPoint;

        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
        
    }

    public IEnumerator RespawnCo()
    {

        isRespawning = true;
        thePlayer.gameObject.SetActive(false);
        Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);


        yield return new WaitForSeconds(respawnLength);

        isFadeToBlack = true;

        yield return new WaitForSeconds(waitForFade);

        isFadeToBlack = false;
        isFadeFromBlack = true;

        isRespawning = false;

        thePlayer.gameObject.SetActive(true);
        currHealth = maxHealth;
        thePlayer.transform.position = respawnPoint;

        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCount = flashLength;
    }

    public void HealPlayer(int heal)
    {
        currHealth += heal;

        if (currHealth > maxHealth)
            currHealth = maxHealth;
    }

    public void setSpawnPoint( Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }

}
