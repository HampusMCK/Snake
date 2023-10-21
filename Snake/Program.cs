using System.Numerics;
using Raylib_cs;

Raylib.SetTargetFPS(60);
Raylib.InitWindow(1400, 900, "SnakeAI");
int pcSc = Raylib.GetCurrentMonitor();
int width = Raylib.GetMonitorHeight(pcSc) - Raylib.GetMonitorHeight(pcSc) / 10;
int height = Raylib.GetMonitorHeight(pcSc) - Raylib.GetMonitorHeight(pcSc) / 10;
int wpx = (Raylib.GetMonitorWidth(pcSc) - width) / 2;
int wpy = (Raylib.GetMonitorHeight(pcSc) - height) / 2;
Raylib.SetWindowSize(width, height);
Raylib.SetWindowPosition(wpx, wpy);
int PWidth = height / 25;
int x = (width / 2) - (PWidth * 10);
int y = (height / 2) - (PWidth * 10);
int font = PWidth / 3;
Vector2[] Platform = new Vector2[400];
Vector2[] center = new Vector2[400];
int cc = PWidth / 2;
Random gen = new();
int fc = 0;
bool IsFo = false;
List<int> fp = new List<int>();
List<int> fs = new List<int>();
float timer = 0;
Vector2 pp = new Vector2(190, 190);
Vector2 speed = new Vector2(-1, 0);
Vector2 lp = new Vector2(0, 0);
Vector2[] ll = new Vector2[400];
int score = 0;
int f = 399;
bool scorebreach = false;
for (var i = 0; i < 400; i++)
{
    Platform[i] = new Vector2(x, y);
    center[i] = new Vector2(Platform[i].X + cc, Platform[i].Y + cc);
    x += PWidth;
    if ((i + 1) % 20 == 0)
    {
        y += PWidth;
        x = (width / 2) - (PWidth * 10);
    }
}

while (!Raylib.WindowShouldClose())
{
    Rectangle[] Player = new Rectangle[400];
    Vector2 startPos = new Vector2(Platform[(int)pp.X].X, Platform[(int)pp.Y].Y);

    move();
    Player[0] = new Rectangle(startPos.X, startPos.Y, PWidth, PWidth);
    Vector2 mousePos = Raylib.GetMousePosition();
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);
    for (var i = 0; i < Platform.Length; i++)
    {
        Rectangle square = new(Platform[i].X, Platform[i].Y, PWidth, PWidth);
        Raylib.DrawRectangleRec(square, Color.GREEN);
        Raylib.DrawRectangleLinesEx(square, 1, Color.WHITE);
    }
    int c = 0;
    if (!IsFo && fc == 0)
    {
        fp.Add(1);
        fp.Add(1);
        fp.Add(1);
        fp.Add(1);
        fp.Add(1);
        fp.Add(1);
        fp.Add(1);
        fp.Add(1);
        fp.Add(1);
        fp.Add(1);
        fs.Add(1);
        fs.Add(1);
        fs.Add(1);
        fs.Add(1);
        fs.Add(1);
        fs.Add(1);
        fs.Add(1);
        fs.Add(1);
        fs.Add(1);
        fs.Add(1);
        c = 0;
        for (var i = 0; i < 10; i++)
        {
            int l = gen.Next(30, 390);
            if ((l - 10) % 20 == 0)
            {
                fp[i] = l;
            }
            if (fp[i] == 1 || fp[8] == 1)
            {
                c++;
            }
            int j = gen.Next(180, 199);
            fs[i] = j;
        }
        if (c == 0)
        {
            IsFo = true;
            fc = 10;
        }
    }
    if (IsFo)
    {
        for (var i = 0; i < fc; i++)
        {
            Rectangle food = new(center[fs[i]].X - 10, center[fp[i]].Y - 10, 20, 20);
            Raylib.DrawRectangleRec(food, Color.BLUE);
            if (Raylib.CheckCollisionRecs(Player[0], food))
            {
                fp.RemoveAt(i);
                fs.RemoveAt(i);
                fc--;
                score += 1;
            }
        }
        if (fc <= 0)
        {
            IsFo = false;
        }
    }
    Raylib.DrawText($"Score:{score}/400", 10, 10, 30, Color.WHITE);
    Raylib.DrawText("SnakeAI", (width / 2) - (Raylib.MeasureText("SnakeAI", height / 8) / 2), 5, height/8, Color.VIOLET);
    for (var i = 0; i < score + 1; i++)
    {
        if (i > 0)
        {
            Player[i] = new Rectangle(Platform[(int)ll[i - 1].X].X, Platform[(int)ll[i - 1].Y].Y, PWidth, PWidth);
        }
    }
    for (var i = 0; i < Player.Length; i++)
    {
        if (i < 200)
        {
            Color q = new(255 - i, 0, 0 + i, 255);
            Raylib.DrawRectangleRec(Player[i], q);
        }
        else if (i < 400)
        {
            Color q = new(0 + (i / 2), 0, 255 - (i / 2), 255);
            Raylib.DrawRectangleRec(Player[i], q);
        }
        else
        {
            Color q = new(255, 0, 255, 255);
            Raylib.DrawRectangleRec(Player[i], q);
        }
        Raylib.DrawRectangleRec(Player[0], Color.YELLOW);
        Raylib.DrawRectangleLinesEx(Player[i], 1, Color.BLACK);
    }
    Raylib.EndDrawing();
}

void move()
{
    timer += Raylib.GetFrameTime();
    if (timer > 0.201f)
    {
        lp = pp;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[f] = ll[f - 1];
        f--;
        ll[0] = lp;
        lp += speed;
        if (score < 50 && IsFo)
        {
            Vector2 target = new(190, fp[0]);
            if (lp.Y < 10 || lp.Y > 390)
            {

            }
            else if (pp.Y < target.Y)
            {
                lp -= speed;
                speed = new(0, 20);
                pp += speed;
            }
            else if (pp.Y > target.Y)
            {
                lp -= speed;
                speed = new(0, -20);
                pp += speed;
            }
            else if (pp.Y == target.Y && pp.X == 199)
            {
                lp -= speed;
                speed = new(-1, 0);
                pp += speed;
            }
            else if (pp.Y == target.Y && pp.X == 180)
            {
                lp -= speed;
                speed = new(1, 0);
                pp += speed;
            }
            else if (pp.Y == target.Y && speed.X == 0)
            {
                lp -= speed;
                speed = new(1, 0);
                pp += speed;
            }
            else if (pp.Y == 10)
            {
                lp -= speed;
                speed = new(1, 0);
                pp += speed;
            }
            else
            {
                lp -= speed;
                pp += speed;
            }
        }
        if (score >= 50)
        {
            if (!scorebreach)
            {
                if ((pp.Y - 10) % 40 == 0)
                {
                    speed = new(1, 0);
                    scorebreach = true;
                }
                else if (!((pp.Y - 10) % 40 == 0))
                {
                    speed = new(-1, 0);
                    scorebreach = true;
                }
            }
            if (lp.X == 200)
            {
                lp -= speed;
                speed = new(0, 20);
                pp += speed;
                speed = new(-1, 0);
            }
            else if (lp.X == 180 && lp.Y / pp.Y == 1 && lp.Y != 390)
            {
                lp -= speed;
                speed = new(0, 20);
                pp += speed;
                speed = new(1, 0);
            }
            else if (lp.X == 179 && lp.Y != -10)
            {
                lp -= speed;
                speed = new(0, -20);
                pp += speed;
            }
            else if (lp.X == 180 && lp.Y == -10)
            {
                lp -= speed;
                speed = new(1, 0);
                pp += speed;
            }
            else
            {
                pp += speed;
            }
        }
        timer = 0.2f;
        f = 399;
    }
}