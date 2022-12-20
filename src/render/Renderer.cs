using OpenTK.Graphics.OpenGL4;

namespace graphics.game {
  public class Renderer {
    private Shader shader;
    private Triangle? triangle;
    private Quad? quad;
    int VertexBufferObject;
    int VertexArrayObject;
    int ElementBufferObject;
    int vertexColorUniformLocation;

    double time = 0.0f;

    public Renderer() {
      Game.OnLoadEvent += HandleOnLoadEvent;
      Game.OnRenderEvent += HandleOnRenderEvent;
      Game.OnUnLoadEvent += HandleOnUnloadEvent;

      shader = new Shader("src/render/shaders/shader.vert", "src/render/shaders/shader.frag");
    }

    private void HandleOnLoadEvent() {
      shader.Use();

      GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

      //CODE
      VertexBufferObject = GL.GenBuffer();
      VertexArrayObject = GL.GenVertexArray();
      ElementBufferObject = GL.GenBuffer();

      triangle = new Triangle();
      quad = new Quad();

      GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
      GL.EnableVertexAttribArray(0);

      GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
      GL.EnableVertexAttribArray(1);

      vertexColorUniformLocation = GL.GetUniformLocation(shader.Handle, "ourColor");
    }

    private void HandleOnRenderEvent() {
      float green = (float)Math.Sin(time);
      float red = (float)Math.Cos(time);
      float blue = (float)Math.Tan(time);
      
      GL.Uniform4(vertexColorUniformLocation, red, green, blue, 1.0f);

      // triangle?.Render();
      quad?.Render();
    }

    private void HandleOnUnloadEvent() {
      shader.Dispose();
    }
  }
}