using System;

namespace MonsterLab;

public class Arm : MonsterPart
{


    public Arm(string name, int hp, PartAction[] actions) : base(name, hp, actions)
    {

    }
}

public class Head : MonsterPart
{


    public Head(string name, int hp, PartAction[] actions) : base(name, hp, actions)
    {

    }
}

public class Leg : MonsterPart
{


    public Leg(string name, int hp, PartAction[] actions) : base(name, hp, actions)
    {

    }
}

public class Torso : MonsterPart
{
    public int energy;

    public Torso(string name, int hp, PartAction[] actions, int energy) : base(name, hp, actions)
    {
        this.energy = energy;
    }
}
