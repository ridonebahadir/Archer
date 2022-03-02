using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create ArrowColorData",fileName = "ArrowColorData",order =0)]

public class ArrowColorData : ScriptableObject
{
    public List<Color> arrowColor;
}
public class EnemyArrowColor : MonoBehaviour
{
    public Material ArrowColor;
    public ArrowColorData colorData;
    int random;

    void Start()
    {
        random = Random.Range(0, colorData.arrowColor.Count);
        ArrowColor.color = colorData.arrowColor[random];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
