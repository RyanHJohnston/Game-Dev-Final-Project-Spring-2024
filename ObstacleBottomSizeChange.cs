using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBottomSizeChange : MonoBehaviour
{
    public Vector2 targetScale = new Vector2(2.0f, 2.0f);
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Vector3 scaleChange = Vector3.Lerp(transform.localScale, new Vector3(targetScale.x, targetScale.y, transform.localScale.z), speed * Time.deltaTime); */
        /* transform.localScale = scaleChange; */
    }
}
