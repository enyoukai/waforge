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
    Vector2 startPos = new Vector2(0.35f, 5.74f);
    Vector2 hookOffset = new Vector2(-0.225f, -0.43f);
    float lineLength = 10.0f;
    float fishingTime = 0.2f;
    float waitTime = 0.5f;
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

            hook.transform.position = currentEndPos + (Vector3)hookOffset;

            lineRenderer.SetPosition(1, currentEndPos);

            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        time = 0;
        endPos = lineRenderer.GetPosition(1);

        hook.GetComponent<CircleCollider2D>().enabled = false;

        while (time < fishingTime)
        {
            time += Time.deltaTime;
            lineRenderer.SetPosition(0, startPos);

            Vector3 currentEndPos = Vector3.Lerp(endPos, startPos, time / fishingTime);

            lineRenderer.SetPosition(1, currentEndPos);
            hook.transform.position = currentEndPos + (Vector3)hookOffset;

            yield return null;
        }

        hook.GetComponent<CircleCollider2D>().enabled = true;

        currentlyFishing = false;

        triesRemaining--;

        CheckTriesRemaining();
    }

    public IEnumerator CatchFish()
    {
        StopCoroutine(fishingCoroutine);

        hook.GetComponent<CircleCollider2D>().enabled = false;

        Inventory.Fish++;
        caughtFish++;

        yield return new WaitForSeconds(waitTime);

        float time = 0;
        Vector3 endPos = lineRenderer.GetPosition(1);

        while (time < fishingTime)
        {
            time += Time.deltaTime;
            lineRenderer.SetPosition(0, startPos);

            Vector3 currentEndPos = Vector3.Lerp(endPos, startPos, time / fishingTime);

            lineRenderer.SetPosition(1, currentEndPos);

            hook.transform.position = currentEndPos + (Vector3)hookOffset;

            yield return null;
        }

        hook.GetComponent<CircleCollider2D>().enabled = true;
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
