using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressDaysPhase : MonoBehaviour, TurnPhase
{
    public int daysRemaining;
    private Camera camera;
    private TurnMaster turnMaster;

    public void turnStart() {
        daysRemaining--;
        Debug.Log("Days remaining:" + daysRemaining);
    }
    public void DoPhase() { }
    public void RecieveCameraControl(Camera cam) { this.camera = cam;  }
    public void informOfRealDad(TurnMaster master) { this.turnMaster = master; }
    public bool amIDone() { return true; }

}
