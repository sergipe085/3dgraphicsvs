using OpenTK.Graphics.OpenGL4;

namespace graphics.game {
  public class Shader : IDisposable {
    public int Handle;

    public Shader(string vertexPath, string fragPath) {
      int VertexShader;
      int FragShader;

      string VertexShaderSource = File.ReadAllText(vertexPath);
      string FragShaderSource = File.ReadAllText(fragPath);

      VertexShader = GL.CreateShader(ShaderType.VertexShader);
      GL.ShaderSource(VertexShader, VertexShaderSource);

      FragShader = GL.CreateShader(ShaderType.FragmentShader);
      GL.ShaderSource(FragShader, FragShaderSource);

      GL.CompileShader(VertexShader);
      GL.GetShader(VertexShader, ShaderParameter.CompileStatus, out int successVertex);
      if (successVertex == 0) {
        string infoLog = GL.GetShaderInfoLog(VertexShader);
        Console.WriteLine(infoLog);
      }

      GL.CompileShader(FragShader);
      GL.GetShader(FragShader, ShaderParameter.CompileStatus, out int successFrag);
      if (successFrag == 0) {
        string infoLog = GL.GetShaderInfoLog(FragShader);
        Console.WriteLine(infoLog);
      }

      Handle = GL.CreateProgram();

      GL.AttachShader(Handle, VertexShader);
      GL.AttachShader(Handle, FragShader);

      GL.LinkProgram(Handle);

      GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out int successLink);
      if (successLink == 0) {
        string infoLog = GL.GetProgramInfoLog(Handle);
        Console.WriteLine(infoLog);
      }

      GL.DetachShader(Handle, VertexShader);
      GL.DetachShader(Handle, FragShader);
      GL.DeleteShader(VertexShader);
      GL.DeleteShader(FragShader);
    }

    public void Use() {
      GL.UseProgram(Handle);
    }

    private bool disposedValue = false;

    protected virtual void Dispose(bool disposing) {
      if (!disposedValue) {
        GL.DeleteProgram(Handle);

        disposedValue = true;
      }
    }

    ~Shader() {
      GL.DeleteProgram(Handle);
    }

    public void Dispose() {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}