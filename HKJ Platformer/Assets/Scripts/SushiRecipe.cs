using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiRecipe : MonoBehaviour
{
    public List<SushiPiece.PieceType> recipe;
    public string Name;
    public string JpName;
    public List<Sprite> Images;
    public Sprite FinalImage;

    public bool Contains(SushiPiece.PieceType piece)
    {
        return recipe.Contains(piece);
    }
}
