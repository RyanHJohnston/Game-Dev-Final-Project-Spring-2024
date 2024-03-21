using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float objectWidth;
    [SerializeField] float objectHeight;

    /*
     * Awake() is used to init variables or states before the application starts
     * Like BEGIN {} in awk
     */
    void Awake()
    {
        mainCamera = Camera.main;
        
        // boutta calculate object size
        if (GetComponent<SpriteRenderer>() != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            objectWidth = spriteRenderer.bounds.extents.x; // half of the object width 
            objectHeight = spriteRenderer.bounds.extents.y; // half of the object height
        }

        // possibly might need more conditions for different types of renderers
        // this will come later tho
    }
    
    void LateUpdate()
    {
        Vector3 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        Vector3 viewPosition = transform.position;

        // clamp the object's position within the camera view, accounting for the object's size to
        // avoid clipping
        viewPosition.x = Mathf.Clamp(viewPosition.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPosition;
    }
}
