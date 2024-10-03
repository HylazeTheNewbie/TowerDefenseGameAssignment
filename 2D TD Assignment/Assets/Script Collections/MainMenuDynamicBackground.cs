using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuDynamicBackground : MonoBehaviour
{
    
    [SerializeField] private float speed = 1.5f;
    private RectTransform rectTransform;
    private Vector2 imageResolution;
    private Vector2 cameraResolution;
    private float horizontalBoundary;
    private float distanceMoved;
    private Vector3 startPositionX, currentPositionX;
    private CanvasScaler scaler;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        scaler = GetComponentInParent<CanvasScaler>();
        // get referenceResolution
        Vector2 referenceResolution = scaler.referenceResolution;
        rectTransform = GetComponent<RectTransform>();
        cameraResolution = getCameraPos();
        imageResolution = getBGImagePos();
        //horizontalBoundary = 0.3f + ((imageResolution.x - cameraResolution.x) / 128);
        //Adjust the boundary according to the reference resolution to ensure that the movement range of the background is appropriate under different resolutions
        horizontalBoundary = 0.3f + ((imageResolution.x - cameraResolution.x) / 128) * (cameraResolution.x / referenceResolution.x);
        //The initial position of the initial background
        startPositionX = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DynamicBackgroundMovement();
    }

    Vector2 getCameraPos()
    {
        cameraResolution = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);

        return cameraResolution;
    }

    Vector2 getBGImagePos()
    {
        UnityEngine.UI.Image image = GetComponent<UnityEngine.UI.Image>();
        //Image image = GetComponent<Image>();

        if (image.sprite != null && image.sprite.texture != null)
        {
            //imageResolution = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
            imageResolution = new Vector2(rectTransform.rect.width, rectTransform.rect.height);

        }
        else
            Debug.Log("Image or texture is missing!");
       
        return imageResolution;
    }

    void DynamicBackgroundMovement()
    {
        // Calculate the movement frame
        Vector3 movementFrame = Vector3.right * speed * Time.deltaTime;

        // Move the background
        if (movingRight)
            transform.Translate(movementFrame);
        else
            transform.Translate(-movementFrame);

        // Update distance moved
        distanceMoved = transform.position.x - startPositionX.x;
 
        // Change direction if boundaries are reached
        if (distanceMoved >= horizontalBoundary)
            movingRight = false;
        else if (distanceMoved <= -horizontalBoundary)
            movingRight = true;
    }
}
