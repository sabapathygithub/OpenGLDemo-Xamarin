using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.ES20;

namespace Opengl_Sample.Shaders
{
    public abstract class Shader
    {
        public bool Bind { get; set; }

        public bool Compiled { get; set; }

        public int DrawArraySize { get; set; }

        public int DrawArrayMode { get; set; }

        public virtual object Render(object geometry, object renderoption, object camera)
        {
            if(!Compiled)
            {
                Compile();
            }
            if(!Bind)
            {
                BindGeometry(geometry);
            }
            return RenderGeometry(geometry, renderoption, camera);
        }

        public abstract bool Compile();

        public abstract bool BindGeometry(object geometry);

        public abstract bool RenderGeometry(object geometry, object renderoption, object camera);

        public virtual void InvalidateGeometry()
        {
            if (Bind)
            {
                UnbindGeometry();
            }
        }

        public abstract void UnbindGeometry();

        public int CompileShader(ShaderType type, string source)
        {
            int shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);
            GL.CompileShader(shader);
            int length = 0;
            int compiled = 0;
            GL.GetShader(shader, ShaderParameter.CompileStatus, out compiled);
            if (compiled == 0)
            {
                length = 0;
                GL.GetShader(shader, ShaderParameter.InfoLogLength, out length);
                if (length > 0)
                {
                    StringBuilder log = new StringBuilder(length);
                    GL.GetShaderInfoLog(shader, length, out length, log);

                    throw new InvalidOperationException("GL2 : Couldn't compile shader: " + log.ToString());
                }

                GL.DeleteShader(shader);
                throw new InvalidOperationException("Unable to compile shader of type : " + type.ToString());
            }
            return shader;
        }

        public int LinkShaderProgram(int vertex_shader, int fragement_shader)
        {
            int program = GL.CreateProgram();
            GL.AttachShader(program, vertex_shader);
            GL.AttachShader(program, fragement_shader);
            GL.LinkProgram(program);
            int result = 0;
            GL.GetProgram(program, ProgramParameter.LinkStatus, out result);
            if (result == 0)
            {
                throw new InvalidOperationException("Problem on linking the programs.");
            }
            return program;            
        }
    }
}
