using UnityEngine;

/*[RequireComponent(typeof(Rigidbody))]
*/public class CoinCollision : MonoBehaviour
{/*

    private Rigidbody _rigidbody;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody>();*/

    private void OnCollisionEnter(Collision collision)
    {
        for (var i = 0; i < collision.contactCount; i++)
            if (collision.contacts[i].otherCollider.CompareTag("Coin"))
                Debug.Log("Coin!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Fake Coin!");
            Destroy(other.gameObject);
            return;
        }//instantiate, destroy= enable, disable
        if (other.CompareTag("Coin"))
            Debug.Log("Fake Coin!");
    }
}
