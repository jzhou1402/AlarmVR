using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightScroller : MonoBehaviour

{
    public Material highlightSmall;
    public Material highlightLarge;

    private float scrollerSmall = 0f;
    private float scrollerLarge = 0f;

    // Start is called before the first frame update
    void Start()
    {
        scrollerSmall = 0f;
        scrollerLarge = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        highlightSmall.SetTextureOffset("_MainTex", new Vector2(scrollerSmall, 0));

        scrollerSmall += 0.001f;

        highlightLarge.SetTextureOffset("_MainTex", new Vector2(scrollerLarge, 0));

        scrollerLarge += 0.001f;
    }
}
