using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Bonus : MonoBehaviour
{    
    // Start is called before the first frame update
    protected void Reset()
    {
        var rig = GetComponent<Rigidbody>();
        rig.isKinematic = true;

        var sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.56f;
    }

    // Update is called once per frame
    protected void Update()
    {
        transform.Translate(
            Time.deltaTime * 2f * Vector3.back, Space.World);
    }

    protected void OnMouseDown()
    {
        PickUpBonus();
    }

    protected void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player)
        {
            PickUpBonus();
        }
    }

    protected virtual void PickUpBonus()
    {
        StartCoroutine(MoveUp());
        var sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider)
        {
            sphereCollider.enabled = false;
        }
    }

    protected IEnumerator MoveUp()
    {
        var height = 0f;
        while (height < 10f)
        {
            height += Time.deltaTime * 10f;
            var pos = transform.position;
            pos.y = height;
            transform.position = pos;
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
