using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, IInteractable
{
    public bool IsCollected = false;

    public void OnInteract() {
        var renderer = GetComponent<SpriteRenderer>(); 
        renderer.color = new Color(
            renderer.color.r,
            renderer.color.g,
            renderer.color.g,
            renderer.color.a * 0F);
            
        var collider = GetComponent<Collider2D>(); 
        IsCollected = true;
        collider.enabled = false;

        var parentGems = GetComponentInParent<Gems>();
        parentGems.OnCollection(this);
    }
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
