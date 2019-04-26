using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text dayNumber;

    [SerializeField]
    private Text popularityRating;

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

    private int daysUntilBill = 7;
    private int popularity = 0;
    private int money = 350;
    private int supplies = 10;

    private int spaceArt = 5;
    private int characterArt = 5;
    private int chibiArt = 5;

    private void Start()
    {
        spaceArtInventory.text = spaceArt.ToString();
        characterArtInventory.text = spaceArt.ToString();
        chibiArtInventory.text = spaceArt.ToString();
    }

    private void Update()
    {
        UpdateStats();   
    }

    private void UpdateStats()
    {
        dayNumber.text = "Days until bills: " + daysUntilBill;
        popularityRating.text = "Popularity rating: " + popularity;
        moneyAmount.text = "Money: " + money;
        supplyAmount.text = "Supplies left: " + supplies;
    }

    public void BuySupplies()
    {
        money -= 20;
        supplies += 10;
    }

    public void MakeSpaceArt()
    {
        supplies -= 5;
        spaceArt++;
        spaceArtInventory.text = spaceArt.ToString();
    }

    public void MakeCharacterArt()
    {
        supplies -= 3;
        characterArt++;
        characterArtInventory.text = characterArt.ToString();
    }

    public void MakeChibiArt()
    {
        supplies -= 1;
        chibiArt++;
        chibiArtInventory.text = chibiArt.ToString();
    }

}
