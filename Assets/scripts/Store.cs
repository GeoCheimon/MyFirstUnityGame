using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Store : MonoBehaviour
{
    // References to the panels
    public GameObject energyDrinksPanel;
    public GameObject proteinBarsPanel;
    public GameObject productsPanel;
    public GameObject dietProgramsPanel;
    public GameObject details1Panel;
    public GameObject details2Panel;
    public GameObject messagePanel;

    // References to the buttons
    public Button energyDrinksButton;
    public Button proteinBarsButton;
    public Button productsButton;
    public Button dietProgramButton;
    public Button buyButton;
    public Button closeButton;

   
    // Protein bars Buttons, text and quantity
    public Button[] decreaseProteinBarButtons;
    public Button[] increaseProteinBarButtons;
    public Text[] proteinBarQuantityTexts;
    private int[] proteinBarQuantities;
    private List<string> shoppingCart = new List<string>();


    // Energy drinks Buttons, text and quantity
    public Button[] decreaseEnergyDrinkButtons;
    public Button[] increaseEnergyDrinkButtons;
    public Text[] energyDrinkQuantityTexts;
    private int[] energyDrinkQuantities;

    // Energy drinks Buttons, text and quantity
    public Button[] decreaseProductsButtons;
    public Button[] increaseProductsButtons;
    public Text[] productsQuantityTexts;
    private int[] productsQuantities;

    // Diet Plan Buttons
    public Button shoppingCart1Btn;
    public Button details1Btn;
    public Button shoppingCart2Btn;
    public Button details2Btn;

    public Text messageText;

    void Start()
    {
        // Ensure all panels are inactive at the start
        energyDrinksPanel.SetActive(false);
        proteinBarsPanel.SetActive(false);
        productsPanel.SetActive(false);
        dietProgramsPanel.SetActive(false);
        details1Panel.SetActive(false);
        details2Panel.SetActive(false);
        messagePanel.SetActive(false);

        // Initialize quantities array
        proteinBarQuantities = new int[proteinBarQuantityTexts.Length];
        energyDrinkQuantities = new int[energyDrinkQuantityTexts.Length];
        productsQuantities = new int[productsQuantityTexts.Length];

        // Add listeners to the buttons
        energyDrinksButton.onClick.AddListener(OpenEnergyDrinksPanel);
        proteinBarsButton.onClick.AddListener(OpenProteinBarsPanel);
        productsButton.onClick.AddListener(OpenProductsPanel);
        buyButton.onClick.AddListener(OpenBuyPanel);
        closeButton.onClick.AddListener(CloseBuyPanel);
        shoppingCart1Btn.onClick.AddListener(() => AddToCart("loose weight"));
        shoppingCart2Btn.onClick.AddListener(() => AddToCart("gain muscle"));
        details1Btn.onClick.AddListener(() => ToggleDetailsPanel(details1Panel));
        details2Btn.onClick.AddListener(() => ToggleDetailsPanel(details2Panel));
        dietProgramButton.onClick.AddListener(OpenDietProgramsPanel);

        // Assign listeners to increase and decrease buttons for Protein Bars dynamically
        for (int i = 0; i < decreaseProteinBarButtons.Length; i++)
        {
            int index = i; // Capture the current value of i
            decreaseProteinBarButtons[i].onClick.AddListener(() => ChangeProteinBarQuantity(index, -1));
            increaseProteinBarButtons[i].onClick.AddListener(() => ChangeProteinBarQuantity(index, 1));
        }

        // Assign listeners to increase and decrease buttons for EnergyDrinks dynamically
        for (int i = 0; i < decreaseEnergyDrinkButtons.Length; i++)
        {
            int index = i; // Capture the current value of i
            decreaseEnergyDrinkButtons[i].onClick.AddListener(() => ChangeEnergyDrinksQuantity(index, -1));
            increaseEnergyDrinkButtons[i].onClick.AddListener(() => ChangeEnergyDrinksQuantity(index, 1));
        }

        // Assign listeners to increase and decrease buttons for EnergyDrinks dynamically
        for (int i = 0; i < decreaseProductsButtons.Length; i++)
        {
            int index = i; // Capture the current value of i
            decreaseProductsButtons[i].onClick.AddListener(() => ChangeProductsQuantity(index, -1));
            increaseProductsButtons[i].onClick.AddListener(() => ChangeProductsQuantity(index, 1));
        }

        // Update all quantity texts at the start
        InitializeQuantityAndTexts();
    }

    private void AddToCart(string item)
    {
        // Check if the item is already in the cart
        if (shoppingCart.Contains(item))
        {
            Debug.Log(item + " is already in the cart.");
            return;
        }

        // Check if the cart is full
        if (shoppingCart.Count >= 2)
        {
            Debug.Log("Cart can only hold up to 2 items.");
            return;
        }

        // Add the item to the shopping cart list
        shoppingCart.Add(item);
        Debug.Log(item + " added to the cart.");

        // Display the current cart contents
        Debug.Log("Current Shopping Cart: " + string.Join(", ", shoppingCart));
    }   

    public void ToggleDetailsPanel(GameObject panel) {
        // Check if the panel is currently active
        if (panel.activeSelf) {
            // If it is active, deactivate it
            panel.SetActive(false);
        } else {
            // If it is not active, activate it
            panel.SetActive(true);
        }
    }

    public void OpenEnergyDrinksPanel()
    {
        Debug.Log("First Layer Button Clicked");
        CloseAllStorePanels();
        energyDrinksPanel.SetActive(true);
    }

    public void OpenProteinBarsPanel()
    {
        Debug.Log("Second Layer Button Clicked");
        CloseAllStorePanels();
        proteinBarsPanel.SetActive(true);
    }

    public void OpenProductsPanel() {
        Debug.Log("Third Layer Button Clicked");
        CloseAllStorePanels();
        productsPanel.SetActive(true);
    }

    public void OpenDietProgramsPanel() {
        Debug.Log("dietProgramsPanel Button Clicked");
        CloseAllStorePanels();
        dietProgramsPanel.SetActive(true);
    }

    public void OpenBuyPanel()
    {
        CloseAllStorePanels();
        messagePanel.SetActive(true);

        messageText.fontSize = 20;
        string message = "You bought:\n";

        for (int i = 0; i < proteinBarQuantities.Length; i++)
        {
            if (proteinBarQuantities[i] > 0)
            {
                message += proteinBarQuantities[i] + " Protein Bar(s) of type " + (i + 1) + "\n";
            }
        }

        for (int i = 0; i < energyDrinkQuantities.Length; i++)
        {
            if (energyDrinkQuantities[i] > 0)
            {
                message += energyDrinkQuantities[i] + " Energy Drink(s) of type " + (i + 1) + "\n";
            }
        }

        for (int i = 0; i < productsQuantities.Length; i++)
        {
            if (productsQuantities[i] > 0)
            {
                message += productsQuantities[i] + " Gym Product(s) of type " + (i + 1) + "\n";
            }
        }

        if (shoppingCart.Contains("gain muscle")) { // shopping cart contains "gain muscle"
            message += " A diet program for building muscle\n"; 
        }

        if (shoppingCart.Contains("loose weight")) { 
            message += " A diet program for loosing weight\n"; 
        }

        messageText.text = message;
        LayoutRebuilder.ForceRebuildLayoutImmediate(messagePanel.GetComponent<RectTransform>());
   
    }

    public void CloseBuyPanel() {
        CloseAllStorePanels();
        messagePanel.SetActive(false);
    }

    private void CloseAllStorePanels()
    {
        Debug.Log("Closing All Store Panels");
        energyDrinksPanel.SetActive(false);
        proteinBarsPanel.SetActive(false);
        productsPanel.SetActive(false);
        dietProgramsPanel.SetActive(false);
        details1Panel.SetActive(false);
        details2Panel.SetActive(false);
        messagePanel.SetActive(false);
    }

    private void ChangeProteinBarQuantity(int index, int change)
    {
        proteinBarQuantities[index] = Mathf.Max(0, proteinBarQuantities[index] + change);
        UpdateProteinBarQuantityText(index);
    }

    private void UpdateProteinBarQuantityText(int index)
    {
        proteinBarQuantityTexts[index].text = proteinBarQuantities[index].ToString();
    }

   
    private void ChangeEnergyDrinksQuantity(int index, int change)
    {
        energyDrinkQuantities[index] = Mathf.Max(0, energyDrinkQuantities[index] + change);
        UpdateEnergyDrinksQuantityText(index);
    }
    
    private void UpdateEnergyDrinksQuantityText(int index)
    {
        energyDrinkQuantityTexts[index].text = energyDrinkQuantities[index].ToString();
    }

    private void ChangeProductsQuantity(int index, int change)
    {
        productsQuantities[index] = Mathf.Max(0, productsQuantities[index] + change);
        UpdateProductsQuantityText(index);
    }
    
    private void UpdateProductsQuantityText(int index)
    {
        productsQuantityTexts[index].text = productsQuantities[index].ToString();
    }


    private void InitializeQuantityAndTexts()
    {
        for (int i = 0; i < proteinBarQuantities.Length; i++)
        {
           proteinBarQuantities[i] = 0;
           proteinBarQuantityTexts[i].text = proteinBarQuantities[i].ToString();
        }

        for (int i=0; i < energyDrinkQuantities.Length; i++) {
            energyDrinkQuantities[i] = 0;
            energyDrinkQuantityTexts[i].text = energyDrinkQuantities[i].ToString();
        }

        for (int i=0; i < productsQuantities.Length; i++) {
            productsQuantities[i] = 0;
            productsQuantityTexts[i].text = productsQuantities[i].ToString();
        }
    }
}
