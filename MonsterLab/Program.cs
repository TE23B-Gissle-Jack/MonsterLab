using System.Numerics;
using MonsterLab;
using Raylib_cs;

//makes the window called "Slap" with a target fps of 60
Raylib.InitWindow(1500, 1000, "Frank");
Raylib.SetTargetFPS(60);
Raylib.SetExitKey(KeyboardKey.Null); //Disable ESC as exit key

// Example actions just so the constructor works
PartAction[] exampleActions = new PartAction[]
{
    new PartAction("Punch", [20,10,0,0],["Head","LeftArm","RightLeg"]),
    new PartAction("Leg Sweep", [12,20,0,0],["RightLeg","LeftLeg"]),
    new PartAction("Bite",[15,45,0,0],["Head","Torso"]),
    new PartAction("Tail Whip",[10,20,0,0],["Torso","LeftLeg"]),
    new PartAction("Body Slam",[30,65,0,0],["Torso"]),
    new PartAction("Kick",[18,35,0,0],["LeftLeg","RightLeg"]),
    new PartAction("Headbutt",[25,50,0,0],["Head"]),
    new PartAction("Claw Strike",[12,25,0,0],["LeftArm","RightArm"]),
    new PartAction("First Aid",[10,0,30,0],["Torso"]),
    new PartAction("Shield Bash",[20,25,0,20],["Head","Torso"]),
    new PartAction("Guard",[5,0,0,40],["Torso","Head"])
};

PartAction[] RandomActions()
{
    PartAction[] something = new PartAction[]{
    new PartAction(exampleActions[Random.Shared.Next(exampleActions.Length)]),
    new PartAction(exampleActions[exampleActions.Length-1])//[Random.Shared.Next(exampleActions.Length)];
    };
    return something;
}


Monster CreateMonster()
{
    Arm rightArm = new Arm("Arm", 50, RandomActions());
    Arm leftArm = new Arm("Arm", 50, RandomActions());
    Head head = new Head("Head", 100, RandomActions());
    Leg rightLeg = new Leg("Leg", 60, RandomActions());
    Leg leftLeg = new Leg("Leg", 60, RandomActions());
    Torso torso = new Torso("Torso", 120, RandomActions(), 100);
    return new Monster(head,leftArm,rightArm,leftLeg,rightLeg,torso);
}

Monster wow = CreateMonster();

Monster en = CreateMonster();

wow.enemy = en;
en.enemy = wow;

Button myButton = new Button(
    new Vector2(500, 500), // position
    150,                   // width
    70,                    // height
    Color.Blue,            // button color
    Color.White,           // text color
    wow.parts["Head"].actions[0].name,             // button text
    wow.parts["Head"].actions[0]
);
Button myButton2 = new Button(
    new Vector2(700, 500), // position
    150,                   // width
    70,                    // height
    Color.Blue,            // button color
    Color.White,           // text color
    wow.parts["Head"].actions[1].name,             // button text
    wow.parts["Head"].actions[1]
);

Button myButton3 = new Button(
    new Vector2(500, 700), // position
    150,                   // width
    70,                    // height
    Color.Red,            // button color
    Color.White,           // text color
    en.parts["Head"].actions[0].name,             // button text
    en.parts["Head"].actions[0]
);
Button myButton4 = new Button(
    new Vector2(700, 700), // position
    150,                   // width
    70,                    // height
    Color.Red,            // button color
    Color.White,           // text color
    en.parts["Head"].actions[1].name,             // button text
    en.parts["Head"].actions[1]
);

while (!Raylib.WindowShouldClose())
{
    Raylib.ClearBackground(Color.Black);
    Raylib.BeginDrawing();

    wow.DisplayCondition(new(100, 100), 0.5f);

    en.DisplayCondition(new(500, 100), 0.5f);

    //exampleActions[0].Use(en, wow);

    myButton.draw();
    myButton.Update();
    myButton2.draw();
    myButton2.Update();

    myButton3.draw();
    myButton3.Update();
    myButton4.draw();
    myButton4.Update();

    Raylib.EndDrawing();
}
Console.ReadLine();