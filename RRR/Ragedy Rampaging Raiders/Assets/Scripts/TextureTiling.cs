using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureTiling : MonoBehaviour {
    public Renderer rend;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        float scaleX = Mathf.Cos(Time.time) * 0.5F + 1;
        float scaleY = Mathf.Sin(Time.time) * 0.5F + 1;
        rend.material.mainTextureScale = new Vector2(scaleX, scaleY);
    }
}
