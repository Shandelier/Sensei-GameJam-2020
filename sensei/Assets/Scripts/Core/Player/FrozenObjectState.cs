using UnityEngine;

namespace Core.Player
{
    public class FrozenObjectState : MonoBehaviour
    {
        private Vector3 savedVelocity;

        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                savedVelocity = rb.velocity;
                rb.isKinematic = true;
            }
        }

        private void OnDestroy()
        {
            var rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.velocity = savedVelocity;
                Debug.Log($"velocity {savedVelocity}");
            }
        }
    }
}
