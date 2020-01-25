using System;
using Core.Player;
using Core.SoundManager;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;

    private Material defaultMaterial;
    private Transform _selection;

    private Vector3 mOffset;
    private float mZCoord;
    
    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null && !selectionRenderer.GetComponent<Rigidbody>().isKinematic)
                {
                    defaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                }

                if (Input.GetKeyDown("f"))
                {
                    SoundManager.PlaySound(SoundManager.Sound.Gong1);
                    if (hit.transform.gameObject.GetComponent<FrozenObjectState>() == null)
                    {
                        hit.transform.gameObject.AddComponent<FrozenObjectState>();
                        Debug.Log("freeze");
                    }
                    else
                    {
                        Destroy(hit.transform.gameObject.GetComponent<FrozenObjectState>());
                        Debug.Log("unnnfreeze");
                    }
                }

                if (Input.GetMouseButtonDown(0))
                {
                    mZCoord = Camera.main.WorldToScreenPoint(selectionRenderer.transform.position).z;
                    mOffset = selectionRenderer.transform.position - GetMouseWorldPos();
                }

                _selection = selection;
            }
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}