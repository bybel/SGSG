using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input Keys
public enum InputKeyboard
{
    arrows = 0,
    wasd = 1
}

public enum InputColor
{
    blue = 0,
    purple = 1
}

public class MoveWithKeyboardBehavior : AgentBehaviour
{
    public InputKeyboard inputKeyboard;
    public InputColor inputColor;

    private static bool chColor = false;
    private static bool chCmd = false;

    public override Steering GetSteering()
    {
        GameMechanics gameScript = GameObject.FindGameObjectWithTag("GameMechanics").GetComponent<GameMechanics>();
        Steering steering = new Steering();

        if (gameScript.isPlaying)
        {
            //implement your code here

            float horizontal;
            float vertical;
            if(chCmd) {
                if (inputKeyboard == InputKeyboard.arrows)
                {
                    horizontal = Input.GetAxis("Horizontal");
                    vertical = Input.GetAxis("Vertical");
                }
                else
                {
                    horizontal = Input.GetAxis("H2");
                    vertical = Input.GetAxis("V2");
                }
            }
            else 
            {
                if (gameObject.tag.Equals("Player1"))
                {
                    horizontal = Input.GetAxis("Horizontal");
                    vertical = Input.GetAxis("Vertical");
                }
                else
                {
                    horizontal = Input.GetAxis("H2");
                    vertical = Input.GetAxis("V2");
                }
            }
            
            setColor();

            steering.linear = new Vector3(horizontal, 0, vertical) * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        }

        return steering;
    }

    private void setColor()
    {
        if(chColor){
            if (inputColor == InputColor.blue)
            {
                agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.blue, 0);
            }
            else
            {
                agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.magenta, 0);
            }
        }
        else 
        {
            if (gameObject.tag.Equals("Player1"))
            {
                agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.blue, 0);
            }
            else
            {
                agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.magenta, 0);
            }
        }

    }

    public void setCmdWASD(){
        inputKeyboard = InputKeyboard.wasd;
        chCmd = true;
    }
    
    public void setCmdArrows(){
        inputKeyboard = InputKeyboard.arrows;
        chCmd = true;
    }

    public void setColorBlue(){
        inputColor = InputColor.blue;
        chColor = true;
    }

    public void setColorPurple(){
        inputColor = InputColor.purple;
        chColor = true;
    }

    public void noChoice() {
        chCmd = false;
        chColor = false;
    }
}