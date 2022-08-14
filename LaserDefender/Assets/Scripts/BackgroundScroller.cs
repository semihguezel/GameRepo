using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float backgroundScrollSpeed = 0.2f;
    Material _myMaterial;

    private Vector2 offSet;
    // Start is called before the first frame update
    void Start()
    {
        _myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0,backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        _myMaterial.mainTextureOffset +=offSet * Time.deltaTime;
    }
}
