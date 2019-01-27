using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterInfo))]
public class MovementController : MonoBehaviour {

    private float speed_;
    private float rotateSpeed_;
    private float dashForce_;
    private float jumpForce_;

    private bool shouldJump, shouldDash;

    private Vector3 velocity_;
    private Vector3 movement_;
    private float requestedMovementX_;
    private float requestedMovementY_;
    private Quaternion targetRotation_;

    private float dashTimer = 0.0f, dashDuration = .15f;

    private Rigidbody playerRB_;

    private MovementState state = MovementState.GROUNDED;

    private void Start() {
        speed_ = GetComponent<CharacterInfo>().speed;
        rotateSpeed_ = GetComponent<CharacterInfo>().rotateSpeed;
        dashForce_ = GetComponent<CharacterInfo>().dashForce;
        jumpForce_ = GetComponent<CharacterInfo>().jumpForce;
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
                if (shouldDash) {
                    Dash();
                    state = MovementState.DASHING;
                }
                if (shouldJump) {
                    Jump();
                }
                break;
            case MovementState.AIRBORNE:
                if (CheckIfGrounded()) {
                    velocity_ = Vector3.zero;
                    state = MovementState.GROUNDED;
                    break;
                }
                RotateTowards();
                break;
            case MovementState.DASHING:
                dashTimer += Time.deltaTime;
                if(dashTimer >= dashDuration) {
                    dashTimer = 0.0f;
                    state = MovementState.AIRBORNE;
                }
                RotateTowards();
                break;
            default:
                break;
        }
        ResetRequests();
    }

    public void RequestMoveX(float movement) { requestedMovementX_ = movement; }
    public void RequestMoveY(float movement) { requestedMovementY_ = movement; }
    public void RequestRotateTowards(Vector3 direction) {
        if(direction != Vector3.zero) {
            direction.y = 0.0f;
            targetRotation_ = Quaternion.LookRotation(direction);
        }
    }
    public void RequestJump() { shouldJump = true; }
    public void RequestDash() { shouldDash = true; }

    private void Move() {
        movement_.Set(requestedMovementX_, 0.0f, requestedMovementY_);

        movement_ = movement_.normalized * speed_ * Time.deltaTime;
        velocity_ = movement_;

        playerRB_.MovePosition(transform.position + movement_);
    }
    private void RotateTowards() {
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation_, rotateSpeed_);

        playerRB_.MoveRotation(newRotation);
    }

    private void Jump() {
        playerRB_.AddForce(Vector3.up * jumpForce_);
        playerRB_.velocity += velocity_ * 30;
    }
    private void Dash() {
        playerRB_.AddForce(velocity_.normalized * dashForce_);
    }

    private bool CheckIfGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, GetComponent<CapsuleCollider>().bounds.extents.y + 0.1f);
    }

    private void ResetRequests() {
        shouldJump = false;
        shouldDash = false;
    }
}
