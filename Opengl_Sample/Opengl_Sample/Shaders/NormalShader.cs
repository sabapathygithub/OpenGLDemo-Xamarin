using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.ES20;
using OpenTK;
using System.Diagnostics;

namespace Opengl_Sample.Shaders
{
    public abstract class NormalShader : Shader
    {
        string vertex_shader = @"#version 330
in vec3 vertex_position;
in vec3 vertex_color;

uniform mat4 u_proj;
uniform mat4 u_view;
uniform mat4 u_model;

out vec3 fragment_color;

void main() {

    gl_Position = u_proj * u_view * u_model * vec4(vertex_position, 1.0);
    fragment_color = vertex_color;
}";
        string fragment_shader = @"#version 330
in vec3 fragment_color;
out vec4 FragColor;

void main()
{
    FragColor = vec4(fragment_color, 1.0);
}";

        private Vector3[] vertices;

        private Vector3[] colors;

        int position_buffer = 0;
        int color_buffer = 0;
        int shader_program = 0;
        int vertex_position = 0;
        int vertex_color = 0;
        int model = 0;
        int view = 0;
        int projection = 0;

        public override bool BindGeometry(object geometry)
        {
            UnbindGeometry();
            if(!PrepareBinding(geometry))
            {
                return false;
            }
            GL.GenBuffers(1, out position_buffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, position_buffer);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * 3), vertices, BufferUsage.StaticDraw);
            
            GL.GenBuffers(1, out color_buffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, color_buffer);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(colors.Length * 3), colors, BufferUsage.StaticDraw);

            Bind = true;
            return true;
        }

        public override bool Compile()
        {
            int vs = CompileShader(ShaderType.VertexShader, vertex_shader);
            int fs = CompileShader(ShaderType.FragmentShader, fragment_shader);
            try
            {
                shader_program = LinkShaderProgram(vs, fs);
                vertex_position = GL.GetAttribLocation(shader_program, "vertex_position");
                vertex_color = GL.GetAttribLocation(shader_program, "vertex_color");

                model = GL.GetAttribLocation(shader_program, "u_model");
                view = GL.GetAttribLocation(shader_program, "u_view");
                projection = GL.GetAttribLocation(shader_program, "u_proj");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            Compiled = true;
            return true;
        }

        public override bool RenderGeometry(object geometry, object renderoption, object camera)
        {
            if (!PrepareRendering(renderoption))
                return false;
            GL.UseProgram(shader_program);

            
            return true;

        }

        public override void UnbindGeometry()
        {
            if(Bind)
            {
                GL.DeleteBuffers(1, new int[1] { position_buffer });
                GL.DeleteBuffers(1, new int[1] { color_buffer });
                Bind = false;
            }
        }

        public abstract bool PrepareBinding(object geometry);

        public abstract bool PrepareRendering(object renderoption);
    }
}
