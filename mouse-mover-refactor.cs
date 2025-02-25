using System;
using System.Runtime.InteropServices;
using System.Threading;

class MouseMover {
  [DllImport("user32.dll")]
  private static extern bool SetCursorPos(int X, int Y);
  [DllImport("user32.dll")]
  private static extern int GetSystemMetrics(int nIndex);

  static void Main() {
    while (true) {
      DrawCircle();
      Console.WriteLine("5 min waiting... Crtl + C to exit.");
      Thread.Sleep(5 * 60 * 1000); // 5分待機
    }
  }

  static void DrawCircle(){
    int radius = 100; // 円の半径
    int points = 100; // 円の滑らかさ（分割数）

    // 画面の幅・高さを取得
    int screenWidth = GetSystemMetrics(0); // SM_CXSCREEN (画面の幅)
    int screenHeight = GetSystemMetrics(1); // SM_CYSCREEN (画面の高さ)

    int centerX = screenWidth / 2;
    int centerY = screenHeight / 2;

    for (int i = 0; i <= points; i++){
      double angle = 2 * Math.PI * i / points;
      int x = centerX + (int)(radius * Math.Cos(angle));
      int y = centerY + (int)(radius * Math.Sin(angle));
      SetCursorPos(x, y);
      Thread.Sleep(10); // マウス移動の速度調整
    }
  }
}