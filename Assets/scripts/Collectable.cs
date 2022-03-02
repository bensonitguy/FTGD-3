using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update

    enum ItemType { Coin, Health, Ammo } //Creates Enum for collectables.
    [SerializeField] private ItemType itemType;
    NewPlayer newPlayer;

    void Start()
    {
        if (itemType == ItemType.Coin)
        {
            Debug.Log("i am a coin");
        }

        newPlayer = GameObject.Find("Player").GetComponent<NewPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (itemType == ItemType.Coin)
            {
                newPlayer.coinsCollected++;
                Debug.Log("i am a coin");
            }
            else if(itemType == ItemType.Health)
            {
                if (newPlayer.health < 100)
                {
                    newPlayer.health += 10;
                }
            }

            newPlayer.coinsCollected++;
            // Update Coins Collected UI
            newPlayer.UpdateUI();
            Destroy(gameObject);
        }
    }
}
