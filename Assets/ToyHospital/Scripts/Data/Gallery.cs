using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour
{
    public SaveManager saveManager;
    [Space]
    public List<Image> imageGallery;
    public List<Sprite> spritePlayer;

    [Header("Instance")]
    [SerializeField] private Image parentSpriteInstance;
    [SerializeField] private Image spriteInstance;

    [Header("Position Instance's")]
    [SerializeField] private Transform positionContentGalleryInstance;

    private Image parenRefGallerySpritePlayer;
    private Image refGallerySpritePlayer;

    private void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>();
    }
    private void Start()
    {
        foreach (var item in saveManager.changer)
        {
            spritePlayer.Add(item.GetComponent<ChangerPlayer>().bodyPart.sprite);
        }

            parenRefGallerySpritePlayer = Instantiate(parentSpriteInstance);
            parenRefGallerySpritePlayer.transform.position = positionContentGalleryInstance.position;
            parenRefGallerySpritePlayer.transform.SetParent(positionContentGalleryInstance);
            parenRefGallerySpritePlayer.transform.localScale = Vector3.one;

            for (int i = 0; i < spritePlayer.Count; i++)
            {
                refGallerySpritePlayer = Instantiate(spriteInstance);
                refGallerySpritePlayer.transform.position = parenRefGallerySpritePlayer.transform.position;
                refGallerySpritePlayer.transform.SetParent(parenRefGallerySpritePlayer.transform);
                refGallerySpritePlayer.transform.localScale = Vector3.one;

                imageGallery.Add(refGallerySpritePlayer); 
            }

            for (int i = 0; i < imageGallery.Count; i++)
            {
                imageGallery[i].sprite = saveManager.changer[i].GetComponent<ChangerPlayer>().bodyPart.sprite;
            }
        }
    }
