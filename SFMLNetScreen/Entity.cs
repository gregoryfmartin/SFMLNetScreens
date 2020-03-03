using System;
using SFML.Graphics;

namespace SFMLNetScreen {
    public abstract class Entity : Sprite {
        protected Entity () : base () {}

        public abstract void Update (Single delta);
    }
}