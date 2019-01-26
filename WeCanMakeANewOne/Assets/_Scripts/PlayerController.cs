using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterInfo))]
[RequireComponent(typeof(MovementController))]
public class PlayerController : MonoBehaviour
{
    private CharacterInfo info_;

    void Start() {
        info_ = GetComponent<CharacterInfo>();
    }

    void Update() {

    }
}
