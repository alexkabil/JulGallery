using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDissolve : MonoBehaviour
{
    // à la main car flemme ici
    public Renderer DissolveRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DissolveOverTime(2.0f));
        
    }

    // Update is called once per frame
    void Update()
    {
        var value = Mathf.PingPong(Time.time * 0.2f, 1f);
        DissolveRenderer.material.SetFloat("_Dissolve", value);
    }

    public IEnumerator DissolveOverTime(float f)
    {
        float timer = 0;
        float value = 0;
        bool init = true;

        while (init)
        {
            if (timer <= 0)
            {
                timer += Time.deltaTime;
                value = Mathf.Lerp(value, 1, Time.deltaTime);
                DissolveRenderer.material.SetFloat("_Dissolve", value);
                yield return null;
            }
            
            if (timer >= f)
            {
                timer -= Time.deltaTime;
                value = Mathf.Lerp(value, 0, Time.deltaTime);
                DissolveRenderer.material.SetFloat("_Dissolve", value);
                yield return null;
            }
        }

        yield return null;
    }
}
