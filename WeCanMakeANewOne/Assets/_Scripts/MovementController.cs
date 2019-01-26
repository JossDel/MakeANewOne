using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterInfo))]
public class MovementController : MonoBehaviour {

    private float speed_;
    private float rotateSpeed_;

    private Vector2 movement_;
    private Vector2 requestedMovement_;
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

    public void RequestMove(Vector2 movement) { requestedMovement_ = movement; }
    public void RequestRotateTowards(Vector3 direction) {
        direction.y = 0.0f;
        targetRotation_ = Quaternion.LookRotation(direction);
    }

    private void Move() {
        movement_ = requestedMovement_;

        movement_ = movement_.normalized * speed_ * Time.deltaTime;

        playerRB_.MovePosition(transform.position + new Vector3(movement_.x, 0.0f, movement_.y));
    }
    private void RotateTowards() {
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation_, rotateSpeed_);

        playerRB_.MoveRotation(newRotation);
    }

    private bool CheckIfGrounded() {

        return true;
    }

}
