using OpenTK.Graphics.OpenGL4;

namespace graphics.game {
  class Quad {
    Mesh mesh;
    private MeshRenderer meshRenderer;

    public Quad() {
      float[] _vertices = {
        // positions        // colors
        0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 0.0f,   // bottom right
        -0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f,   // bottom left
        -0.5f,  0.5f, 0.0f,  0.0f, 0.0f, 1.0f,    // top left
        0.5f,  0.5f, 0.0f,  1.0f, 1.0f, 1.0f    // top right
      };
      uint[] _indices = {  // note that we start from 0!
        2, 1, 0,   // first triangle
        3, 0, 2, 
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