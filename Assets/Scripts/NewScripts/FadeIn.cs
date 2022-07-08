using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

    public float startTrans;
    public float endTrans;
    public float speedTrans = 0.75f;

	private Material startMat;
    private Shader startShade;

	// Use this for initialization
	void Start () {

		startMat = this.gameObject.GetComponent<Renderer> ().material;
        startShade = this.gameObject.GetComponent<Renderer>().material.shader;
        this.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
        this.gameObject.GetComponent<Renderer>().material.color = new Vector4 (1, 1, 1, startTrans);


    }
	
	// Update is called once per frame
	void Update () {

        if (endTrans != 1)
        {
            endTrans += speedTrans*Time.deltaTime;

            if (endTrans > 1)
            {
                this.gameObject.GetComponent<Renderer>().material.shader = startShade;
				this.gameObject.GetComponent<Renderer> ().material = startMat;
                endTrans = 1;
				Destroy (this);
            }

            this.gameObject.GetComponent<Renderer>().material.color = new Vector4(1, 1, 1, endTrans);

        }

    }
}
