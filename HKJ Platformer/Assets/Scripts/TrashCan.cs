using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SushiPiece piece;
        if ((piece = collision.GetComponent<SushiPiece>()) != null)
            Destroy(piece.gameObject);
    }
        
}
