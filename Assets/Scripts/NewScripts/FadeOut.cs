using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

    public float myTrans = 1;
    public float speedTrans = 0.75f;
    public bool startFade = false;

    private bool isShaderChange = false;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (startFade && myTrans > 0.01f)
        {
            if (!isShaderChange)
            {
                this.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
                isShaderChange = true;
            }

            myTrans -= speedTrans * Time.deltaTime;

            this.gameObject.GetComponent<Renderer>().material.color = new Vector4(1, 1, 1, myTrans);

        }

    }
}
