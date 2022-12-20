using OpenTK.Graphics.OpenGL4;

namespace graphics.game {
  class Triangle {
    Mesh mesh;
    private MeshRenderer meshRenderer;

    public Triangle() {
      float[] _vertices = {
        // positions        // colors
        0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 0.0f,   // bottom right
        -0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f,   // bottom left
        0.0f,  0.5f, 0.0f,  0.0f, 0.0f, 1.0f    // top 
      };
      uint[] _indices = {  // note that we start from 0!
        0, 1, 2,   // first triangle
      };

      mesh = new Mesh(_vertices, _indices);
      meshRenderer = new MeshRenderer(mesh);

      meshRenderer.Create();
    }

    public void Render() {
      meshRenderer.Drawn();
    }
  }
}