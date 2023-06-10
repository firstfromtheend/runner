using UnityEngine;

public class WallDeactivator : MonoBehaviour {
    //deactivate GM what touched this element
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }
}