using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject followPointOne;
    public GameObject followPointTwo;

    // Update is called once per frame
    void Update()
    {
        if (followPointOne.activeSelf == false) {
            transform.position = followPointTwo.transform.position;
        } else {
            transform.position = followPointOne.transform.position;
        }
    }
}
