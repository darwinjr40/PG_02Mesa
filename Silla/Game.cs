﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK.Input;
using System.Drawing;
namespace Silla
{
    class Game : GameWindow
    {   //darwin estuvo aqui
        Cubo p = new Cubo(2,2,2, 2,10,2);//espalda
        Mesa m = new Mesa(0, 0, 0, 5, 5, 5);
        int q = 0;
        Escenario es;
        //------------------------------------------------------------------------------------------------------
        public Game(int ancho, int alto, string titulo) : base(ancho, alto, GraphicsMode.Default, titulo){
                 es = new Escenario();
                 //es.add("pata1", new Cubo(0, 0, 0));
                 es.add("cubo", new Cubo(-5, 0, 0));
                 es.add("mesa1", new Mesa(0, 0, 0, 5, 5, 10));
                 //es.add("mesa2", new Mesa(-5, 0, 0, 2, 2, 2));
        }
        //------------------------------------------------------------------------------------------------------
        protected override void OnRenderFrame(FrameEventArgs e)//ejecuta 60 hz
        {
            base.OnRenderFrame(e);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);//limpia el dibujo 
            GL.Rotate(q, 1, 1, 0);
            //es.dibujar("pata1");
            es.dibujar();
            base.SwapBuffers();
        }
        //------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)//Esta función se ejecuta cada vez que se cambia el tamaño de la ventana.
        {   
            base.OnResize(e);
            GL.Viewport(0, 0, base.Width, base.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            int v = 10;
            GL.Ortho(-v, v, -v, v, -v, 10*v);
            //Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90.0f),(float)Width/Height,)
            //GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }
        //------------------------------------------------------------------------------------------------------
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Key.R)) { q = q % 360 + 2; }
            if (input.IsKeyDown(Key.Escape)) { Exit(); }
         }
        //------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(1.8f, 1, 3, 0);
            GL.Enable(EnableCap.DepthTest);//nuevo
        }
        //------------------------------------------------------------------------------------------------------

      

       
    }
}
