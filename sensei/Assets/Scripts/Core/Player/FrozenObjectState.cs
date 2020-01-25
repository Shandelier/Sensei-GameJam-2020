using UnityEngine;
using UniRx.Async;
using System;

namespace Core.Player
{
    public class FrozenObjectState : MonoBehaviour
    {
        private Vector3 savedVelocity;
        private Vector3 savedAngularVelocity;
    
        Material objMaterial;
        Material originalMateial;
        Color originalColor;

        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                savedVelocity = rb.velocity;
                savedAngularVelocity = rb.angularVelocity;
                rb.isKinematic = true;
            }

            this.startBlinking();
        }


        public async UniTask startBlinking() {
            this.objMaterial = GetComponent<MeshRenderer>().material;
            this.originalMateial = GetComponent<MeshRenderer>().material;
            this.originalColor = GetComponent<MeshRenderer>().material.color;

            await blinkForSeconds(2f);
            await blinkForSeconds(1.6f);
            await blinkForSeconds(0.5f);
            await blinkForSeconds(0.3f);
            await blinkForSeconds(0.2f);
            await blinkForSeconds(0.1f);
            await blinkForSeconds(0.1f);
            await blinkForSeconds(0.1f);
            await blinkForSeconds(0.1f);
            await blinkForSeconds(0.1f);
            await blinkForSeconds(0.1f);
            await blinkForSeconds(0.1f);
            await blinkForSeconds(0.1f);

            Destroy(this);
        }

    private async UniTask blinkForSeconds(float firstColor, float secondColor = 0.05f) {
        objMaterial.color = Color.magenta;

        await UniTask.Delay(TimeSpan.FromSeconds(firstColor), ignoreTimeScale: false);

        objMaterial.color = this.originalColor;

        await UniTask.Delay(TimeSpan.FromSeconds(secondColor), ignoreTimeScale: false);

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
