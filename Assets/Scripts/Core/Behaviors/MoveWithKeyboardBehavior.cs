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
        GMKMechanics game = theGame.GetComponent<GMKMechanics>();
        int timer = game.getTimer();
        agent.SetVisualEffect(VisualEffect.VisualEffectProgress, getColor(game.getColor(gameObject.tag)), (int)((timer-1) * 42.5));
    }

    public void setColor(int color){
        agent.SetVisualEffect(VisualEffect.VisualEffectConstAll, getColor(color), 0);
    }

    private Color getColor(int c){
        switch(c) {
            case 0: return Color.blue; 
            case 1: return Color.green; 
            case 2: return Color.yellow; 
            case 3: return Color.red; 
            case 4: return Color.magenta; 
            case 5: return new Color(1, 0.5f, 0, 1); 
            default: return Color.white;
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

    public void vibrate()
    {
        agent.SetSimpleVibrate(100f, 100f,100f, 0, 900); 
    }
}