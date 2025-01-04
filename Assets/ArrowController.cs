using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // Start is called before the first frame update
    
    void OnEnable()
    {
        StartCoroutine(CoroutineForArrowPop());
    }
    public float arrowTriggerTime;

    public float distanceToMoveInX;
    public float distanceToMoveInY;
    public IEnumerator CoroutineForArrowPop()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.GetSiblingIndex() == 0)
            {
                child.gameObject.LeanMoveY(child.transform.position.y + distanceToMoveInY, 0.1f);
                child.gameObject.LeanMoveX(child.transform.position.x + distanceToMoveInX, 0.1f);
                yield return new WaitForSeconds(arrowTriggerTime);
                continue;
            }
            child.gameObject.LeanMoveY(child.transform.position.y + distanceToMoveInY, 0.1f);
            yield return new WaitForSeconds(arrowTriggerTime);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
