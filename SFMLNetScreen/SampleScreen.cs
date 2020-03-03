using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFMLNetScreen {
    public class SampleScreen : Screen {
        public SampleScreen () : base () {
            this.LoadAssets (@".\SampleScreen.zip");
            this.Entities.Add ("PlayerObject", new PlayerObject () {
                Texture  = this.AManager.LibraryTextures ["whale"],
                TextureRect = new IntRect() {
                    Height = 64,
                    Left = 0,
                    Top = 0,
                    Width = 64
                },
                Position = new Vector2f (50.0f, 50.0f)
            });
        }

        public override void Draw (RenderTarget target, RenderStates states) {
            foreach (KeyValuePair <String, Entity> kvp in this.Entities) {
                target.Draw (kvp.Value);
            }
        }

        public override void LoadAssets (String archiveFile) {
            this.AManager.LoadAssets (archiveFile);
        }

        public override void Update (Single delta) {
            foreach (KeyValuePair <String, Entity> kvp in this.Entities) {
                kvp.Value.Update (delta);
            }
        }

        /// <summary>
        /// This screen really isn't interested in anything globally that would be going on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void CheckGlobalInput (Object sender, KeyEventArgs e) {
            return;
        }

        /// <summary>
        /// Move the player image all around the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void CheckPlayerInputPressed (Object sender, KeyEventArgs e) {
            (this.Entities["PlayerObject"] as PlayerObject)?.CheckInputPressed (e);
        }

        /// <summary>
        /// Stop moving the player image all around the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void CheckPlayerInputReleased (Object sender, KeyEventArgs e) {
            (this.Entities["PlayerObject"] as PlayerObject)?.CheckInputReleased (e);
        }
    }
}