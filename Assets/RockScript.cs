using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public float rangeDestroy = 6.5f;    
    private Rigidbody2D rb;

    private float initX = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - initX) >= rangeDestroy)
            Destroy(gameObject);
    }
}
