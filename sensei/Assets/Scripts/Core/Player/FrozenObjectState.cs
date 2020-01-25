using UnityEngine;

namespace Core.Player
{
    public class FrozenObjectState : MonoBehaviour
    {
        private Vector3 savedVelocity;
        private Vector3 savedAngularVelocity;

        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                savedVelocity = rb.velocity;
                savedAngularVelocity = rb.angularVelocity;
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
                rb.angularVelocity = savedAngularVelocity;
                Debug.Log($"velocity {savedVelocity}");
            }
        }
    }
}
