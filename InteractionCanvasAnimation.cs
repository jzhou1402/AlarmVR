using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionCanvasAnimation : MonoBehaviour
{

    private bool startAnimation = true;

    private float tester = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (startAnimation)
        {
            if (tester < 1f)
            {
                tester += 0.1f;
                transform.localScale = new Vector3(tester, tester, tester);
            }
        }

        else if (!startAnimation)
        {
            if (tester > 0f)
            {
                tester -= 0.1f;

                transform.localScale = new Vector3(tester, tester, tester);
            }

            else if (tester == 0f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void UpAnimation()
    {
        this.gameObject.SetActive(true);

        startAnimation = true;
    }

    public void DownAnimation()
    {
        startAnimation = false;
    }
}
