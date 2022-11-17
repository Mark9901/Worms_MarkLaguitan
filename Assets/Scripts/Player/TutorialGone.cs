using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGone : MonoBehaviour
{
    public GameObject tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RemoveAfterSeconds(5, gameObject));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(5);
        obj.SetActive(false);
    }

}
