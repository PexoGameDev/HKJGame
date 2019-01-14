using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiPiece : MonoBehaviour
{
    float fallSpeed = 0.075f;

    public enum PieceType
    {
        rice = 0,avocado = 1,salmon = 2,tuna = 3,cheese = 4,shrimp = 5,cucumber = 6 ,nori = 7 ,surimi= 8,ikura=9, grill_salmon=10, wasabi=11, ginger = 12

    }

    public PieceType type;

    void FixedUpdate()
    {
        transform.position += Vector3.down * fallSpeed;
    }
}
