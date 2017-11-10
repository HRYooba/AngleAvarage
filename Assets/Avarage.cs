using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avarage : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject blendObj;

    [Range(0, 1)]
    public float blendRate;
    private float inRate;
    public Vector3 controlAngle1;
    public Vector3 controlAngle2;
    [Space(20)]
    public Vector3 display1;
    public Vector3 display2;
    public Vector3 blendAngle;
    public Vector3 display3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inRate = 1.0f - blendRate;

        obj1.transform.eulerAngles = controlAngle1;
        obj2.transform.eulerAngles = controlAngle2;
        display1 = obj1.transform.eulerAngles;
        display2 = obj2.transform.eulerAngles;

        // float x = BlendAngle(display1.x, display2.x);
        // float y = BlendAngle(display1.y, display2.y);
        // float z = BlendAngle(display1.z, display2.z);
        // blendAngle = new Vector3(x, y, z);
        // blendAngle = display1 * inRate + display2 * blendRate;
        // blendObj.transform.eulerAngles = blendAngle;

        float x = obj1.transform.rotation.x * inRate + obj2.transform.rotation.x * blendRate;
        float y = obj1.transform.rotation.y * inRate + obj2.transform.rotation.y * blendRate;
        float z = obj1.transform.rotation.z * inRate + obj2.transform.rotation.z * blendRate;
        float w = obj1.transform.rotation.w * inRate + obj2.transform.rotation.w * blendRate;
        blendObj.transform.rotation = new Quaternion(x, y, z, w);

        display3 = blendObj.transform.eulerAngles;
    }

    float BlendAngle(float angle1, float angle2)
    {
        float sin1 = Mathf.Sin(angle1 / 180.0f * Mathf.PI);
        float cos1 = Mathf.Cos(angle1 / 180.0f * Mathf.PI);
        float sin2 = Mathf.Sin(angle2 / 180.0f * Mathf.PI);
        float cos2 = Mathf.Cos(angle2 / 180.0f * Mathf.PI);

        float blendSin = sin1 * inRate + sin2 * blendRate;
        float blendCos = cos1 * inRate + cos2 * blendRate;

        Vector2 blendVector = new Vector2(blendCos, blendSin);
        float blendAngle = Mathf.Atan2(blendSin, blendCos) * 180.0f / Mathf.PI;

        return blendAngle;
    }
}
