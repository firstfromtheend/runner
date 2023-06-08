using UnityEngine;

public class WallDeactivator : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SetActive(false);
    }
}