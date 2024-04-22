using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

  

    public List<Card> deck;
    public TextMeshProUGUI deckSizeText;

    public Transform[] cardSlots;
    public bool[] availableCardSlots;


    public List<Card> discardPile;
    public TextMeshProUGUI discardPileSizeText;

    public TextMeshProUGUI moneyText;

    private Animator camAnim;
    private int playerMoney;

    private int playerCoins; // New variable to track player coins
    public List<string> playerInventory;
    public List<ShopItem> shopItems;
    public GameObject inventorySlotPrefab;
    public Transform inventoryPanel;

    private void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();

        // Initialize player money and coins
        playerMoney = 10;
        playerCoins = 0;
        // Initialize player money and inventory
        playerInventory = new List<string>();
        // Call a method to initialize your deck and card slots if needed
        // InitializeDeck();
        // InitializeCardSlots();

        // Initialize shop items
        InitializeShopItems();

        // Update shop UI
        UpdateShopUI();

        // Display initial state
        UpdateMoneyDisplay();
        DisplayInventorySlots();
        DisplayShopItems();
    }

   
    // Example method to initialize the shop items
    private void InitializeShopItems()
    {
        // Populate the shop items list with items
        shopItems = new List<ShopItem>
        {
            new ShopItem("Upgrade", 3),
            new ShopItem("Animal", 3),
            new ShopItem("Consumable", 1)
        };
    }

    private void UpdateShopUI()
    {
        moneyText.text = "Money: " + playerMoney;
        // Update shop UI to display shop items and prices
        // For example, you can update a shop UI panel with buttons and text to display shop items and prices
    }

    public void PurchaseItem(ShopItem item)
    {
        if (playerMoney >= item.price)
        {
            // Deduct item price from player money
            playerMoney -= item.price;

            // Perform actions based on purchased item
            // For example, add the item to the player's inventory, activate a power-up, etc.

            // Update shop UI
            UpdateShopUI();
        }
        else
        {
            Debug.Log("Not enough money to purchase " + item.name);
        }
    }

    // Method to earn coins
    public void EarnCoins(int amount)
    {
        playerCoins += amount;

        // Update UI to reflect the change in coins
        // For example, update a UI text element displaying the number of coins
    }

    // Method to spend coins
    public void SpendCoins(int amount)
    {
        if (playerCoins >= amount)
        {
            playerCoins -= amount;

            // Update UI to reflect the change in coins
            // For example, update a UI text element displaying the number of coins
        }
        else
        {
            Debug.Log("Not enough coins to spend");
        }
    }

    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            camAnim.SetTrigger("shake");

            Card randomCard = deck[Random.Range(0, deck.Count)];
            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i])
                {
                    randomCard.gameObject.SetActive(true);
                    randomCard.handIndex = i;
                    randomCard.transform.position = cardSlots[i].position;
                    randomCard.hasBeenPlayed = false;
                    deck.Remove(randomCard);
                    availableCardSlots[i] = false;
                    return;
                }
            }
        }
    }

    public void Shuffle()
    {
        if (discardPile.Count >= 1)
        {
            foreach (Card card in discardPile)
            {
                deck.Add(card);
            }
            discardPile.Clear();
        }
    }

    private void Update()
    {
        deckSizeText.text = deck.Count.ToString();
        discardPileSizeText.text = discardPile.Count.ToString();
    }
 

   

        void DisplayInventorySlots()
    {
        // Instantiate inventory slots based on the number of slots needed
        for (int i = 0; i < 16; i++)
        {
            Instantiate(inventorySlotPrefab, inventoryPanel);
        }
    }

    void DisplayShopItems()
    {
        // Display shop items and buttons
        foreach (ShopItem item in shopItems)
        {
            // Instantiate UI elements for shop items and buttons
            // Handle button click events to purchase items
        }
    }
/*
     void PurchaseItem(ShopItem item)
    {
        if (playerMoney >= item.price)
        {
            playerMoney -= item.price;
            playerInventory.Add(item.name);

            // Update UI to reflect the purchase
            UpdateMoneyDisplay();
            // Update inventory display
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }
*/

    [System.Serializable]
    public class ShopItem
    {
        public string name;
        public int price;

        public ShopItem(string _name, int _price)
        {
            name = _name;
            price = _price;
        }
    }
    public void UpdateMoneyDisplay()
    {
        moneyText.text = "Money: " + playerMoney;
    }

}