using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Transform camTrans;

    public float shakeTime;
    public float shakeRange;

    Vector3 originalCamPosition;

    // Start is called before the first frame update
    void Start()
    {
        camTrans = Camera.main.transform;
        originalCamPosition = camTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShakeCamera());
        }
    }

    IEnumerator ShakeCamera()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeTime)
        {
            Vector3 pos = originalCamPosition + Random.insideUnitSphere * shakeRange;

            pos.z = originalCamPosition.z;

            camTrans.position = pos;

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        
        camTrans.position = originalCamPosition;
    }
}
