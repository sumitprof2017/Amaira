using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyBossController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject platForParent;
    public monkey monkey;
    void Start()
    {
        
    }
    float timeForMonkey;
    public IEnumerator coroutineShiftPositionForMonkeyandShoot()
    {
        yield return new WaitForSeconds(timeForMonkey);
        int platFormIndex = platForParent.transform.childCount;
        int randomChildCount = Random.Range(0, platFormIndex);
        monkey.transform.position = platForParent.transform.GetChild(randomChildCount).GetChild(0).transform.position;
        monkey.ShootAsBoss();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
