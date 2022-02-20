using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnMouseDrag()
    {
        transform.localPosition = Vector2.MoveTowards(transform.position, Input.mousePosition, 1);
    }
}
