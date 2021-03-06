﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	#region serializedFields
	[SerializeField]
    private Text dayNumber;

    [SerializeField]
    private Text moneyAmount;

    [SerializeField]
    private Text supplyAmount;

    [SerializeField]
    private Text spaceArtInventory;
    [SerializeField]
    private Text characterArtInventory;
    [SerializeField]
    private Text chibiArtInventory;

	[SerializeField]
	private Text popularArtDaily;

	[SerializeField]
	private Text priceText1;
	[SerializeField]
	private Text priceText2;
	[SerializeField]
	private Text priceText3;
	#endregion

	public Button spaceArtButton;
	public Button characterArtButton;
	public Button cuteArtButton;
	public Canvas gameplayCanvas;
	public Canvas resultsCanvas;
	public Text resultsText;
    public Text billCostText;

	private bool spaceIsPopular;
	private bool characterIsPopular;
	private bool cuteIsPopular;

	private int daysUntilBill = 7;
    private int popularity = 0;
    private int money = 20;
    private int supplies = 0;

    private int spaceArt = 3;
    private int characterArt = 3;
    private int chibiArt = 3;

	private int price1;
	private int price2;
	private int price3;

	private bool endCondition = false;


	private void Start()
    {
		StartCoroutine("DayPassing");
        spaceArtInventory.text = spaceArt.ToString();
        characterArtInventory.text = spaceArt.ToString();
        chibiArtInventory.text = spaceArt.ToString();
		spaceIsPopular = true;
		resultsCanvas.enabled = false;
		popularArtDaily.text = "Currently popular: Space";
        billCostText.text = "Bills cost: $130";
		UpdatePrices();
    }

    private void Update()
    {
        UpdateStats();
		UpdatePrices();
    }

    private void UpdateStats() // method used to update the HUD with all the info the player needs to know.
    {
        dayNumber.text = "Days until bills: " + daysUntilBill;
        moneyAmount.text = "Money: " + money;
        supplyAmount.text = "Supplies left: " + supplies;
    }

    public void BuySupplies()
    {
        money -= 35;
        supplies += 10;
    }

    public void MakeSpaceArt()
    {
		if(supplies >= 10)
		{
			supplies -= 10;
			spaceArt++;
			spaceArtInventory.text = spaceArt.ToString();
			spaceArtButton.interactable = true;
		}
    }

    public void MakeCharacterArt()
    {
		if(supplies >= 5)
		{
			supplies -= 5;
			characterArt++;
			characterArtInventory.text = characterArt.ToString();
			characterArtButton.interactable = true;
		}
	}

    public void MakeChibiArt()
    {
		if(supplies >= 2)
		{
			supplies -= 2;
			chibiArt++;
			chibiArtInventory.text = chibiArt.ToString();
			cuteArtButton.interactable = true;
		}
	}

	public void UpdatePrices() // updates prices of each artwork depending on the popular subject of the day.
	{
		price1 = 25;
		priceText1.text = "$" + price1.ToString();
		price2 = 15;
		priceText2.text = "$" + price2.ToString();
		price3 = 10;
		priceText3.text = "$" + price3.ToString();

		if (spaceIsPopular == true)
		{
			price1 = 40;
			priceText1.text = "$" + price1.ToString();
			price2 = 15;
			priceText2.text = "$" + price2.ToString();
			price3 = 10;
			priceText3.text = "$" + price3.ToString();
		}
		if (characterIsPopular == true)
		{
			price1 = 25;
			priceText1.text = "$" + price1.ToString();
			price2 = 25;
			priceText2.text = "$" + price2.ToString();
			price3 = 10;
			priceText3.text = "$" + price3.ToString();
		}
		if (cuteIsPopular == true)
		{
			price1 = 25;
			priceText1.text = "$" + price1.ToString();
			price2 = 15;
			priceText2.text = "$" + price2.ToString();
			price3 = 25;
			priceText3.text = "$" + price3.ToString();
		}
	}

	private void UpdatePopularSubject() // randomizes the order of what's popular on any given day.
	{
		int randomizer = Random.Range(1, 3);
		if(randomizer == 0)
		{
			spaceIsPopular = true;
			popularArtDaily.text = "Currently popular: Space";
			UpdatePrices();
		}
		if (randomizer == 1)
		{
			characterIsPopular = true;
			popularArtDaily.text = "Currently popular: Character design";
			UpdatePrices();
		}
		if (randomizer == 2)
		{
			cuteIsPopular = true;
			popularArtDaily.text = "Currently popular: Cute art";
			UpdatePrices();
		}
	}

	public void SellSpaceArt()
	{
		if(spaceArt >= 1)
		{
			spaceArtButton.interactable = true;
			spaceArt--;
			money = money + price1;
			spaceArtInventory.text = spaceArt.ToString();
		}
		else if (spaceArt < 1)
		{
			spaceArtButton.interactable = false;
			priceText1.text = "Out of stock";
		}
	}

	public void SellCharacterArt()
	{
		if(characterArt >= 1)
		{
			characterArtButton.interactable = true;
			characterArt--;
			money = money + price2;
			characterArtInventory.text = characterArt.ToString();
		}
		else if (characterArt < 1)
		{
			characterArtButton.interactable = false;
		}
	}

	public void SellCuteArt()
	{
		if(chibiArt >= 1)
		{
			cuteArtButton.interactable = true;
			chibiArt--;
			money = money + price3;
			chibiArtInventory.text = chibiArt.ToString();
		}
		else if (chibiArt < 1)
		{
			cuteArtButton.interactable = false;
		}
	}

	private IEnumerator DayPassing() // counts down a certain amount of time before counting down the day count
	{
		while (endCondition == false)
		{
			yield return new WaitForSeconds(10);
			daysUntilBill--;
			dayNumber.text = daysUntilBill.ToString();
			UpdatePopularSubject();
			if(daysUntilBill == 0)
			{
				endCondition = true;
				EndGame();
			}
		}
	}

	private void EndGame() //the end results that occur when the 7 "days" countdown to 0.
	{
		gameplayCanvas.enabled = false;
		resultsCanvas.enabled = true;

		if(money < 150)
		{
			resultsText.text = "Despite your wildest efforts, you unfortunately could not get the money you needed, and were evicted from your apartment. Maybe next time consider selling something else.";
		}
		else if (money < 450)
		{
			resultsText.text = "Just scraping by, you made just enough to make it through this week. Keep this pace and you should be fine.";
		}
		else if (money > 451)
		{
			resultsText.text = "Miraculously, your art took you off, making well more than your normal job ever could. Maybe it's time for an occupation change after all.";
		}
	}

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
