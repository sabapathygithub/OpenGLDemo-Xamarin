using OpenTK.Graphics.ES20;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Opengl_Sample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        float red, green, blue;
        public MainPage()
        {
            InitializeComponent();
            display.Clicked += (s, o) => OpenglView.Display();
            toggle.Toggled += (s, o) => {
                OpenglView.HasRenderLoop = toggle.IsToggled;
            };
            OpenglView.OnDisplay = r =>
            {
                GL.ClearColor(red, green, blue, 1.0f);
                GL.Clear((ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit));                

                red += 0.01f;
                if (red >= 1.0f)
                    red -= 1.0f;
                green += 0.02f;
                if (green >= 1.0f)
                    green -= 1.0f;
                blue += 0.03f;
                if (blue >= 1.0f)
                    blue -= 1.0f;
            };
        }

        private void Display_Clicked(object sender, EventArgs e)
        {

        }

        private void toggle_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}
