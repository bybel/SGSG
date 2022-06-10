using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputKeyboard {
    wasd = 1, arrows = 0
};

public class MoveWithKeyboardBehavior : AgentBehaviour {
    public InputKeyboard inputKeyboard;
    public GameObject theGame;

    private static bool chCmd = false;

    public override Steering GetSteering()
    {   
        Steering steering = new Steering();
        if (theGame.GetComponent<GMKMechanics>().isPlaying || theGame.GetComponent<Tutorials>().active)
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
                }else{
                     horizontal = Input.GetAxis("H2");
                    vertical = Input.GetAxis("V2");
                }
            }

            steering.linear = new Vector3(horizontal, 0, vertical) * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear, agent.maxAccel));
        }

        return steering;
    }

    public void setColor()
    { 
        int timer = theGame.GetComponent<GMKMechanics>().getTimer();
        agent.SetVisualEffect(VisualEffect.VisualEffectProgress, Color.white, (int)((timer-1) * 42.5));
        Debug.Log(timer + ", " + (int)(255 - timer * 42.5));
    }

    public void setColor(int color){

        switch(color) {
            case 0: agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.blue, 0); break;
            case 1: agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.green, 0); break;
            case 2: agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.yellow, 0); break;
            case 3: agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.red, 0); break;
            case 4: agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, Color.magenta, 0); break;
            default: agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, new Color(1, 0.5f, 0, 1), 0); break;
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

    public void noChoice() {
        chCmd = false;
    }
}