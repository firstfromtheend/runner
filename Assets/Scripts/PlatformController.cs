using System.Collections;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private float _platfromMovementSpeed = 3f;
    private bool _moving = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MovePlatfromAway");
    }

    IEnumerator MovePlatfromAway()
    {
        new WaitForSeconds(1);
        _moving = true;
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (_moving) transform.Translate(Vector3.left * Time.deltaTime * _platfromMovementSpeed);
    }
}
