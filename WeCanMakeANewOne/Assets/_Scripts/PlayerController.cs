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
        GetComponent<MovementController>().RequestMoveX(GamePadManager.GamePad(info_.playerIndex).LeftStick.X);
        GetComponent<MovementController>().RequestMoveY(GamePadManager.GamePad(info_.playerIndex).LeftStick.Y);
        GetComponent<MovementController>().RequestRotateTowards(new Vector3(GamePadManager.GamePad(info_.playerIndex).RightStick.X, 0.0f, GamePadManager.GamePad(info_.playerIndex).RightStick.Y));
    }
}
