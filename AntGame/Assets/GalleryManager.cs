using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    public Image displayedImage;
    public Sprite[] galleryImages;
    private int pictureIndex;

    public GameObject galleryCanvas;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        pictureIndex = 0;
        displayedImage.sprite = galleryImages[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pictureIndex += 1;
            if (pictureIndex < galleryImages.Length)
                displayedImage.sprite = galleryImages[pictureIndex];
            else
                closeGallery();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (pictureIndex > 0)
                pictureIndex -= 1;
            displayedImage.sprite = galleryImages[pictureIndex];
        }
    }

    void closeGallery()
    {
        pictureIndex = 0;
        displayedImage.sprite = galleryImages[0];

        galleryCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}
