using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectingPieces : MonoBehaviour
{
    public CollectedIngridients collectedIngridients;
    public GameObject CollectVFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SushiPiece piece;
        if((piece=collision.GetComponent<SushiPiece>() )!= null)
        {
            collectedIngridients.CollectPiece(piece.type);
            Destroy(Instantiate(CollectVFX, piece.gameObject.transform.position, Quaternion.identity),2f);
            Destroy(piece.gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
