using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedIngridients : MonoBehaviour
{
    public Image[] UIIngredients;

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
        recipies.Remove(currentRecipe);
        UpdateUI();
    }

    void Update()
    {
        
    }

    public void CollectPiece(SushiPiece.PieceType piece)
    {
        if (piece == SushiPiece.PieceType.ginger)
        {
            Fail();
            return;
        }

        if(currentRecipe.Contains(piece))
        {
            print("Collected: " + piece);
            currentRecipe.Images.RemoveAt(currentRecipe.recipe.IndexOf(piece));
            currentRecipe.recipe.Remove(piece);
            UpdateUI();

            if (currentRecipe.recipe.Count < 1)
                ChooseNewRecipe();

            //delete from ui, delete from list, add to sprites
        }
    }

    void ChooseNewRecipe()
    {
        if (recipies.Count < 1)
        {
            print("GameWon");
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
        print("Game Over");
    }

    void UpdateUI()
    {
        ResetUI();
        for(int i = 0; i < currentRecipe.Images.Count; i++)
        {
            UIIngredients[i].sprite = currentRecipe.Images[i];
        }
    }

    void ResetUI()
    {
        foreach(Image img in UIIngredients)
        {
            img.sprite = null;
        }
    }
}
