using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSwitcher : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private List<Transform> childrenimages = new List<Transform>();
    private const int numofChild = 2;

    private bool initOK = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        bool init = true;
        foreach(Transform t in transform)
        {
            childrenimages.Add(t);
        }
        while (init)
        {
            if (childrenimages.Count == numofChild)
            {
                init= false;
                yield return null;
            }
            else
            {
                Debug.Log("pas le bon nombre d'images");
                yield return null;
            }
            yield return null;
        }
        initOK = true;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (initOK)
        {
            childrenimages[1].gameObject.SetActive(false);
            childrenimages[0].gameObject.SetActive(true);
        }
        Debug.Log("dedans");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (initOK)
        {
            childrenimages[1].gameObject.SetActive(true);
            childrenimages[0].gameObject.SetActive(false);
        }
        Debug.Log("dehors");
    }

}
