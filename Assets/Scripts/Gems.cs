using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    public int TotalGemsCollected = 0;

    private ICollection<Gem> _allGems = new List<Gem>();
    private ICollection<Gem> _collectedGems = new List<Gem>();

    // Start is called before the first frame update
    void Start()
    {
        _allGems = this.GetComponentsInChildren<Gem>();
    }

    internal void OnCollection(Gem gem) {
        if (!_collectedGems.Contains(gem)) {
            _collectedGems.Add(gem);
            TotalGemsCollected++;
        }
    }

    // // // Update is called once per frame
    // // void Update()
    // // {
        
    // // }
}
