using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowColorChange : MonoBehaviour
{
    private Renderer arrowMaterial;
    public ArrowColor arrowColor;
    int random;
    private TrailRenderer trailRenderer;
    private void Awake()
    {
        arrowMaterial=transform.GetChild(0).GetComponent<Renderer>();
        trailRenderer = transform.GetChild(1).GetComponent<TrailRenderer>();
    }
    void Start()
    {

        random = Random.Range(0, arrowColor.arrowColor.Count);
        arrowMaterial.material.color = arrowColor.arrowColor[random];
        trailRenderer.material.color=arrowColor.arrowColor[random];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
