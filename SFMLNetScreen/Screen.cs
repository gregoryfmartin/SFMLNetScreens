using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;

namespace SFMLNetScreen {
    public abstract class Screen : Drawable {
        public AssetManager                AManager { get; }
        public Dictionary <String, Entity> Entities { get; }

        protected Screen () {
            this.AManager = new AssetManager ();
            this.Entities = new Dictionary <String, Entity> ();
        }

        public abstract void Draw (RenderTarget target, RenderStates states);

        public abstract void LoadAssets (String archiveFile);

        public abstract void Update (Single delta);

        public abstract void CheckGlobalInput (Object sender, KeyEventArgs e);

        public abstract void CheckPlayerInputPressed (Object sender, KeyEventArgs e);

        public abstract void CheckPlayerInputReleased (Object sender, KeyEventArgs e);
    }
}