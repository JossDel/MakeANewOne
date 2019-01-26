using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public int playerIndex = 1;
    public float speed = 10;
    [Range(0,1)]
    public float rotateSpeed = 0.25f;
}
