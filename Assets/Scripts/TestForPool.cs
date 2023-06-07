using System.Collections;
using UnityEngine;

public class TestForPool : MonoBehaviour
{
    private void OnEnable()
    {
        this.StartCoroutine("LifeTime");
    }

    private void OnDisable()
    {
        this.StopCoroutine("LifeTime");
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(2);
        this.Deactivate();
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}