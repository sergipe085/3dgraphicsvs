using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace graphics.game {
  public class Game : GameWindow {
    public static event Action? OnLoadEvent;
    public static event Action<KeyboardState>? OnUpdateEvent;
    public static event Action? OnRenderEvent;
    public static event Action? OnUnLoadEvent;
    public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { 
      Renderer renderer = new Renderer();
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
      base.OnUpdateFrame(args);

      KeyboardState input = KeyboardState;

      OnUpdateEvent?.Invoke(input);

      if (input.IsKeyDown(Keys.Escape)) {
        Close();
      }
    }

    protected override void OnLoad()
    {
      base.OnLoad();

      OnLoadEvent?.Invoke();
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
      base.OnRenderFrame(args);

      GL.Clear(ClearBufferMask.ColorBufferBit);

      //CODE
      OnRenderEvent?.Invoke();

      SwapBuffers();
    }

    protected override void OnResize(ResizeEventArgs e)
    {
      base.OnResize(e);

      GL.Viewport(0, 0, e.Width, e.Height);
    }

    protected override void OnUnload()
    {
      base.OnUnload();
      
      OnUnLoadEvent?.Invoke();
    }
  }
}
