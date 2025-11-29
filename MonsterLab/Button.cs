using System;
using System.Numerics;
using Raylib_cs;

namespace MonsterLab;

public class Button
{
    Vector2 position;

    int width;
    int height;

    Color color;

    string text;
    Color textColor;

    int size = 40;

    bool hover = false;

    Something theThing;

    public Button(Vector2 location, int width, int height, Color buttonColor, Color textColor, string text, Something theThing)
    {
        this.position = location;
        this.width = width;
        this.height = height;
        this.color = buttonColor;
        this.textColor = textColor;
        this.text = text;
        this.theThing = theThing;
    }

    public void draw()
    {

        while (Raylib.MeasureText(text, size) > width - 20)
        {
            size--;
        }

        int thingie = Raylib.MeasureText(text, size);
        int middleX = (width - thingie)/2;
        int middleY = (int)position.Y + (height / 4);

        if (hover) Raylib.DrawRectangleV(position - new Vector2(2, 2), new(width + 4, height + 4), Color.White);
        Raylib.DrawRectangleV(position, new(width, height), color);
        Raylib.DrawText(text, (int)position.X+middleX, middleY, size, textColor);
    }
    public void Update()
    {
        bool isMouseOver = Raylib.GetMouseX() > position.X &&Raylib.GetMouseX() < position.X + width &&Raylib.GetMouseY() > position.Y &&Raylib.GetMouseY() < position.Y + height;
        if (isMouseOver)
        {
            hover = true;
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                Use();
            }
        }
        else hover = false;
    }
    void Use()
    {
        theThing.Use();
        Console.WriteLine("use");
    }
}
