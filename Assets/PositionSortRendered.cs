using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSortRendered : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 5000;
    [SerializeField]
    private int offset = 0;

    [SerializeField]
    private bool runOnlyOnce = false;

    private float timer,timerMax = .1f;


    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if(timer<=0f)
        {
            timer = timerMax;
            renderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
            if (runOnlyOnce)
            {
                Destroy(this);
            }
        }
        
    }
}
