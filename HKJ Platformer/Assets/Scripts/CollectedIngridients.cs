using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedIngridients : MonoBehaviour
{
    public GameManager gameManager;
    public Image[] UIIngredients;

    [SerializeField] Sprite rice;
    [SerializeField] Sprite avocado;
    [SerializeField] Sprite salmon;
    [SerializeField] Sprite grill_salmon;
    [SerializeField] Sprite tuna;
    [SerializeField] Sprite cheese;
    [SerializeField] Sprite nori;
    [SerializeField] Sprite ikura;
    [SerializeField] Sprite shrimp;
    [SerializeField] Sprite cucumber;
    [SerializeField] Sprite surimi;

    List<SushiRecipe> recipies;
    SushiRecipe currentRecipe;

    void Start()
    {
        recipies = new List<SushiRecipe>();
        SushiRecipe[] allRecipies = GetComponentsInChildren<SushiRecipe>();
        foreach (SushiRecipe rec in allRecipies)
        {
            recipies.Add(rec);
        }

        currentRecipe = recipies[Random.Range(0, recipies.Count)];
        print(currentRecipe.recipe[0]);
        print(currentRecipe.recipe[1]);
        print(currentRecipe.recipe[2]);
        recipies.Remove(currentRecipe);
        UpdateUI();
    }

    public void CollectPiece(SushiPiece.PieceType piece)
    {
        if (piece == SushiPiece.PieceType.ginger)
        {
            Fail();
            return;
        }

        if (currentRecipe.Contains(piece))
        {
            print("Collected: " + piece);
            currentRecipe.recipe.Remove(piece);
            UpdateUI();

            if (currentRecipe.recipe.Count < 1)
            {
                gameManager.SushiCompleted(currentRecipe);
                ChooseNewRecipe();
            }
        }
        else
        {
            Fail();
        }
    }


    void ChooseNewRecipe()
    {
        if (recipies.Count < 1)
        {
            gameManager.GameOver();
            gameManager.NameEng.text = "You Won!";
        }
        else
        {
            currentRecipe = recipies[Random.Range(0, recipies.Count)];
            recipies.Remove(currentRecipe);
            UpdateUI();
        }
    }

    void Fail()
    {
        gameManager.GameOver();
    }

    void UpdateUI()
    {
        ResetUI();
        for(int i = 0; i < currentRecipe.recipe.Count; i++)
        {
            switch(currentRecipe.recipe[i])
            {
                default:
                case SushiPiece.PieceType.rice:
                    UIIngredients[i].sprite = rice;
                    break;
                case SushiPiece.PieceType.avocado:
                    UIIngredients[i].sprite = avocado;
                    break;
                case SushiPiece.PieceType.salmon:
                    UIIngredients[i].sprite = salmon;
                    break;
                case SushiPiece.PieceType.grill_salmon:
                    UIIngredients[i].sprite = grill_salmon;
                    break;
                case SushiPiece.PieceType.tuna:
                    UIIngredients[i].sprite = tuna;
                    break;
                case SushiPiece.PieceType.cheese:
                    UIIngredients[i].sprite = cheese;
                    break;
                case SushiPiece.PieceType.shrimp:
                    UIIngredients[i].sprite = shrimp;
                    break;
                case SushiPiece.PieceType.cucumber:
                    UIIngredients[i].sprite = cucumber;
                    break;
                case SushiPiece.PieceType.nori:
                    UIIngredients[i].sprite = nori;
                    break;
                case SushiPiece.PieceType.surimi:
                    UIIngredients[i].sprite = surimi;
                    break;
                case SushiPiece.PieceType.ikura:
                    UIIngredients[i].sprite = ikura;
                    break;
            }

            UIIngredients[i].gameObject.SetActive(true);
        }
    }

    void ResetUI()
    {
        foreach(Image img in UIIngredients)
        {
            img.sprite = null;
            img.gameObject.SetActive(false);
        }
    }
}
