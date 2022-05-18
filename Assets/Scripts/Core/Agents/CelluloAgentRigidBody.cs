using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// This class adds rigid body to a cellulo and manages the consequences of this: steering vector is now a force input on the rigid body, the velocities are then updated correspondingly. 
/// </summary>
public class CelluloAgentRigidBody : CelluloAgent
{
    public bool hasLongPressed;///////////////////////////LIGNE RAJOUTEE
    private Rigidbody _rigidBody;
    private CelluloAgent agent;
    public GameObject ghost;
    private GhostSheepBehavior gSB;

    protected override void Awake()
    {
        base.Awake();
        _rigidBody = GetComponent<Rigidbody>();
        /*/if(!gameObject.tag.Equals("Sheep")){
         ////    gSB = ghost.GetComponent<GhostSheepBehavior>();
            agent.ClearHapticFeedback();
            agent.SetCasualBackdriveAssistEnabled(true);
        }*/
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (steering.linear.sqrMagnitude == 0.0f)
            _rigidBody.velocity = Vector3.zero; 
        else
        {   //apply force only if we are not at the maximum speed
            if(_rigidBody.velocity.sqrMagnitude<maxSpeed*maxSpeed)
                _rigidBody.AddForce(Vector3.ClampMagnitude(steering.linear, maxAccel));
            else //else break a bit
            {
                float brakeSpeed = _rigidBody.velocity.magnitude - maxSpeed;  // calculate the speed decrease
            
                Vector3 normalisedVelocity = _rigidBody.velocity.normalized;
                Vector3 brakeVelocity = normalisedVelocity * maxAccel;  // make the brake Vector3 value
                _rigidBody.AddForce(-brakeVelocity);  // apply opposing brake force
            }
        }
        if(!gameObject.tag.Equals("Sheep")){
            if(gSB.isSheep){
                agent.ClearHapticFeedback();
                agent.SetCasualBackdriveAssistEnabled(true);
                agent.MoveOnIce();
            } else{
                agent.MoveOnStone();
            }
        }
    }
    public override void LateUpdate()
    {

        rotation += steering.angular * Time.deltaTime;
        rotation = rotation > maxRotation ? maxRotation : rotation;
        
        rotation = steering.angular == 0.0f ? 0.0f : rotation;
        velocity = transform.parent.InverseTransformDirection(_rigidBody.velocity);

    }

    void OnCelluloLongTouch() {
        hasLongPressed = true;
    }

    

}
