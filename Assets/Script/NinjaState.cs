using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaState
{
    public string name;
    protected NinjaController ninjaController;
    public NinjaState(string name, NinjaController ninjaController)
    {
        this.name = name;
        this.ninjaController = ninjaController;
    }

    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysic() { }
    public virtual void Exit() { }

}
