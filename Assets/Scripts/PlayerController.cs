using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform startPos;


    private void Start() {
        transform.position = startPos.position;
    }
}
