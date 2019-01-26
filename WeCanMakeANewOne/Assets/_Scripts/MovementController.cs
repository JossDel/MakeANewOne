using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterInfo))]
public class MovementController : MonoBehaviour {

    private float speed_;
    private float rotateSpeed_;

    private Vector3 movement_;
    private float requestedMovementX_;
    private float requestedMovementY_;
    private Quaternion targetRotation_;

    private Rigidbody playerRB_;

    private MovementState state = MovementState.GROUNDED;

    private void Start() {
        speed_ = GetComponent<CharacterInfo>().speed;
        rotateSpeed_ = GetComponent<CharacterInfo>().rotateSpeed;
        playerRB_ = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        switch (state) {
            case MovementState.GROUNDED:
                if (!CheckIfGrounded()) {
                    state = MovementState.AIRBORNE;
                    break;
                }
                Move();
                RotateTowards();
                break;
            case MovementState.AIRBORNE:
                break;
            default:
                break;
        }
    }

    public void RequestMoveX(float movement) { requestedMovementX_ = movement; }
    public void RequestMoveY(float movement) { requestedMovementY_ = movement; }
    public void RequestRotateTowards(Vector3 direction) {
        if(direction != Vector3.zero) {
            direction.y = 0.0f;
            targetRotation_ = Quaternion.LookRotation(direction);
        }
    }

    private void Move() {
        movement_.Set(requestedMovementX_, 0.0f, requestedMovementY_);

        movement_ = movement_.normalized * speed_ * Time.deltaTime;

        playerRB_.MovePosition(transform.position + movement_);
    }
    private void RotateTowards() {
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation_, rotateSpeed_);

        playerRB_.MoveRotation(newRotation);
    }

    private bool CheckIfGrounded() {

        return true;
    }

}
