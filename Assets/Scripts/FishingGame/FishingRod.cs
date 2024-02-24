using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    const int maxTries = 3;
    int triesRemaining = maxTries;
    int caughtFish = 0;
    [SerializeField] Hook hook;
    LineRenderer lineRenderer;
    Vector2 startPos = new Vector2(0.35f, 3.78f);
    float lineLength = 7.0f;
    float fishingTime = 0.2f;
    float waitTime = 1.0f;
    bool currentlyFishing = false;

    IEnumerator fishingCoroutine;
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, startPos);
    }
    void Update()
    {
        if (Input.GetKeyDown("space") && !currentlyFishing)
        {
            fishingCoroutine = Fish();
            StartCoroutine(fishingCoroutine);
            currentlyFishing = true;
        }
    }

    IEnumerator Fish()
    {
        float time = 0;
        Vector2 endPos = startPos + new Vector2(0, -lineLength);

        while (time < fishingTime)
        {
            time += Time.deltaTime;
            lineRenderer.SetPosition(0, startPos);

            Vector3 currentEndPos = Vector3.Lerp(startPos, endPos, time / fishingTime);

            hook.transform.position = currentEndPos;

            lineRenderer.SetPosition(1, currentEndPos);

            yield return null;
        }

        time = 0;
        while (time < waitTime)
        {
            time += Time.deltaTime;
            yield return null;
        }

        lineRenderer.SetPosition(1, startPos);

        currentlyFishing = false;

        triesRemaining--;

        CheckTriesRemaining();
    }

    public IEnumerator CatchFish()
    {
        StopCoroutine(fishingCoroutine);

        Inventory.Fish++;
        caughtFish++;

        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(2.0f);

        Time.timeScale = 1f;

        lineRenderer.SetPosition(1, startPos);
        currentlyFishing = false;

        triesRemaining--;

        CheckTriesRemaining();
    }

    void CheckTriesRemaining()
    {
        if (triesRemaining <= 0)
        {
            if (caughtFish > 0)
            {
                Debug.Log("You caught " + caughtFish + " fish!");
            }
            else
            {
                Debug.Log("You didn't catch any fish.");
            }
            triesRemaining = maxTries;
            caughtFish = 0;
        }
    }
}
