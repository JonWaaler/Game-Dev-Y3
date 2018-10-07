using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSetVars : MonoBehaviour {

    public Material mat;
    public AnimationCurve t;
    private float t_Material = 0;

    // Update is called once per frame
    void Update()
    {
        t_Material += Time.deltaTime;

        mat.SetFloat("_offset", t.Evaluate(t_Material));

        if (t_Material >= 1)
        {
            mat.SetFloat("_offset", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            t_Material = 0.88f;
        }

    }
}
