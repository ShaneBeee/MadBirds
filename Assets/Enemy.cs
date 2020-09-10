using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision) {
        bool didHitBird = collision.collider.GetComponent<Bird>() != null;
        
        if (didHitBird) {
            Die();
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null) {
            return;
        }

        if (collision.contacts[0].normal.y < -0.5) {
            Die();
        }
    }

    private void Die() {
        Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}