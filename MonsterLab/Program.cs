using MonsterLab;

// Example actions just so the constructor works
PartAction[] exampleActions = new PartAction[]
{
    new PartAction("Punch", 10,[]),
    new PartAction("Kick", 12,[])
};

// Create instances
Arm arm = new Arm("Left Arm", 50, exampleActions);
Head head = new Head("Head", 80, exampleActions);
Leg leg = new Leg("Right Leg", 60, exampleActions);
Torso torso = new Torso("Torso", 120, exampleActions, 100);


Monster wow = new Monster(head,arm,arm,leg,leg,torso);