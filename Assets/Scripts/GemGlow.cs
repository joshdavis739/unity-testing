using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GemGlow : MonoBehaviour
{
    public float Brightness;

    private float _xValue = 0F;
    private float _step = Mathf.PI / 1000;
    private bool _isGlowing = true;

    private Gem _gem;

    // Start is called before the first frame update
    void Start()
    {
        _gem = transform.parent.gameObject.GetComponent<Gem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_xValue > Mathf.PI) {
            _xValue = 0F;

            if (_gem.IsCollected) {
                _isGlowing = false;
            }
        }

        if (_isGlowing) {
            _xValue += _step;
            Brightness = (Mathf.Sin(_xValue)) / 3;
            this.GetComponent<Light2D>().intensity = 2*Brightness;
            this.GetComponent<Light2D>().pointLightOuterRadius = Brightness/3;
        }
    }
}
