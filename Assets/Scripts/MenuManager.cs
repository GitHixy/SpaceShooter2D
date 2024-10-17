using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 2f;

    private void Start()
    {
        FadeIn();
    }

    private void FadeIn()
    {
        // Start with the image fully black
        fadeImage.color = new Color(0f, 0f, 0f, 1f);

        // Use DOTween to fade the image to transparent
        fadeImage.DOFade(0f, fadeDuration).SetEase(Ease.InOutQuad);
    }

    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("GameScene");
    }

    public void OpenOptions()
    {
        // Placeholder for opening options
        Debug.Log("Options opened!");
    }
}

