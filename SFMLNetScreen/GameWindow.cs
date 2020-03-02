using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace SFMLNetScreen {
    public class GameWindow {
        public RenderWindow PrincipalWindow { get; }

        public List <Drawable> ToRender { get; }

        public delegate void KeyDownHandler (Object sender, KeyEventArgs e);

        public delegate void KeyUpHandler (Object sender, KeyEventArgs e);

        public KeyUpHandler KUpHandler { get; set; }

        public KeyDownHandler KDownHandler { get; set; }

        public GameWindow () {
            this.PrincipalWindow = new RenderWindow (new VideoMode (800, 600), "SFML.NET Game Core");
            this.ToRender        = new List <Drawable> ();

            this.PrincipalWindow.KeyPressed  += (s, e) => { this.KDownHandler (s, e); };
            this.PrincipalWindow.KeyReleased += (s, e) => { this.KUpHandler (s, e); };

            this.KUpHandler   += (s, e) => { };
            this.KDownHandler += (s, e) => { };
        }

        public void Update (Single delta) {
            this.PrincipalWindow.DispatchEvents ();
        }

        public void Draw () {
            this.PrincipalWindow.Clear (Color.Black);

            if (this.ToRender.Count > 0) {
                foreach (Drawable d in this.ToRender) {
                    this.PrincipalWindow.Draw (d);
                }
            }

            this.PrincipalWindow.Display ();
        }
    }
}