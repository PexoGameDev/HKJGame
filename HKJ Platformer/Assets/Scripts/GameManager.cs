using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] ingredientsPrefabs;
    public GameObject Player;
    public Vector3[] spawnOrigins;
    public Image FinalImage;
    public Text NameEng;
    public Text NameJp;
    public Button ButtonReset;
    public Button ButtonQuit;

    void Start()
    {
        ButtonReset.onClick.AddListener(delegate { Time.timeScale = 1; SceneManager.LoadScene("Main"); });
        ButtonQuit.onClick.AddListener(delegate { SceneManager.LoadScene("Menu"); });
        InvokeRepeating("SpawnPieces",2f,1.2f);
    }

    void SpawnPieces()
    {
        int randOrigin = Random.Range(0, spawnOrigins.Length);
        Instantiate(ingredientsPrefabs[Random.Range(0, ingredientsPrefabs.Length)], spawnOrigins[randOrigin], Quaternion.identity);
        Instantiate(ingredientsPrefabs[Random.Range(0, ingredientsPrefabs.Length)], spawnOrigins[(randOrigin+1)%spawnOrigins.Length], Quaternion.identity);
    }
    
    public void SushiCompleted(SushiRecipe rec)
    {
        StartCoroutine(ShowSushiImageAndPauseTheGame(rec));
    }

    IEnumerator ShowSushiImageAndPauseTheGame(SushiRecipe rec)
    {
        CancelInvoke();
        Player.SetActive(false);
        FinalImage.gameObject.SetActive(true);
        FinalImage.sprite = rec.FinalImage;
        NameEng.gameObject.SetActive(true);
        NameEng.text = rec.Name;
        NameJp.gameObject.SetActive(true);
        NameJp.text = rec.JpName;
        yield return new WaitForSeconds(3f);
        Player.SetActive(true);
        FinalImage.gameObject.SetActive(false);
        NameEng.gameObject.SetActive(false);
        NameJp.gameObject.SetActive(false);
        InvokeRepeating("SpawnPieces", 1f, 1.2f);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        NameEng.gameObject.SetActive(true);
        NameEng.text = "Game Over!";
        ButtonReset.gameObject.SetActive(true);
        ButtonQuit.gameObject.SetActive(true);
    }
}
