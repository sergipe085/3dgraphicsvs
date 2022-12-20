using OpenTK.Graphics.OpenGL4;

namespace graphics.game {
  class MeshRenderer {
    private Mesh mesh;

    int VertexBufferObject;
    int VertexArrayObject;
    int ElementBufferObject;

    public MeshRenderer(Mesh mesh) {
      this.mesh = mesh;
    }

    public void Create() {
      VertexBufferObject = GL.GenBuffer();
      VertexArrayObject = GL.GenVertexArray();
      ElementBufferObject = GL.GenBuffer();

      GL.BindVertexArray(VertexArrayObject);

      GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
      GL.BufferData(BufferTarget.ElementArrayBuffer, mesh.indices.Length * sizeof(uint), mesh.indices, BufferUsageHint.StaticDraw);

      GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
      GL.BufferData(BufferTarget.ArrayBuffer, mesh.vertices.Length * sizeof(float), mesh.vertices, BufferUsageHint.StaticDraw);
    }

    public void Drawn() {
      GL.BindVertexArray(VertexArrayObject);
      GL.DrawElements(PrimitiveType.Triangles, mesh.indices.Length, DrawElementsType.UnsignedInt, 0);
      // GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }
  }
}