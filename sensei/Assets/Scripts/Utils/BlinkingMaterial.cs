using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx.Async;
using System;

public class BlinkingMaterial : MonoBehaviour {

    Material objMaterial;
    Material originalMateial;
    Color originalColor;

    public void Start() {
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

    }

    private async UniTask blinkForSeconds(float firstColor, float secondColor = 0.05f) {
        objMaterial.color = Color.magenta;

        await UniTask.Delay(TimeSpan.FromSeconds(firstColor), ignoreTimeScale: false);

        objMaterial.color = this.originalColor;

        await UniTask.Delay(TimeSpan.FromSeconds(secondColor), ignoreTimeScale: false);

    }

}
