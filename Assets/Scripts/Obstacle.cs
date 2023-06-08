using UnityEngine;

public class Obstacle : MonoBehaviour {
    
    [SerializeField] private float _moveSpeed = 3f;

    private void Update() {
        transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
    }
}