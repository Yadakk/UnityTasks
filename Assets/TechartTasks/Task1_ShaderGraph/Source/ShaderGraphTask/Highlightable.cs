using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShaderGraphTask
{
    public class Highlightable : MonoBehaviour
    {
        [SerializeField]
        private Material defaultMaterial;

        [SerializeField]
        private Material highlightedMaterial;

        private new Renderer renderer;

        private void Awake()
        {
            renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            renderer.material = defaultMaterial;
        }

        private void OnMouseEnter()
        {
            renderer.material = highlightedMaterial;
        }

        private void OnMouseExit()
        {
            renderer.material = defaultMaterial;
        }
    }
}
