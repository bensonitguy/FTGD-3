using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [SerializeField]  private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private Vector2 healthBarOriginalSize;

    public int coinsCollected = 0;
    public float health = 100;
    public float maxHealth = 100;
    public Text coinsText;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        coinsText = GameObject.Find("Coins").GetComponent<Text>();
        healthBarOriginalSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Coin Collected");
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);

        if (Input.GetButtonDown("Jump") && grounded) {
            velocity.y = jumpPower;
        }
    }

    // Update UI Elements
    public void UpdateUI()
    {
        coinsText.text = coinsCollected.ToString();

        //set the healthbar to a percentage of its original value

        healthBar.rectTransform.sizeDelta = new Vector2(healthBarOriginalSize.x * (health / maxHealth), healthBar.rectTransform.sizeDelta.y);

        //Set HealthBar width to 100
        //healthBar.rectTransform.sizeDelta = new Vector2(100, healthBar.rectTransform.sizeDelta.y);
    }
}
