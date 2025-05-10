using UnityEngine;

public class Planet : Singleton<Planet>
{
    //variables

    //properties
    protected override bool persistent => false;

    //methods
    protected override void Awake()
    {
        base.Awake();
    }
}
