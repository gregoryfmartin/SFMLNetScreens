using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFMLNetScreen {
    public class GameCore {
        private Boolean      _running;
        private Clock        _clock;
        private GameWindow   _gameWindow;
        private Single       _fpsd;
        private PlayerObject _playerObject;
        private AssetManager _assetManager;
        private Sprite       _sprite;

        public GameCore () {
            this._running      = true;
            this._clock        = null;
            this._gameWindow   = null;
            this._playerObject = null;
            this._assetManager = null;
            this._sprite       = null;
        }

        public void Run () {
            this.Init ();

            while (this._running) {
                this._fpsd = this._clock.Restart ().AsSeconds ();

                this.Update (this._fpsd);
                this.Draw ();
            }

            this.Deinit ();
        }

        private void Init () {
            this._gameWindow = new GameWindow ();
            this._gameWindow.PrincipalWindow.SetFramerateLimit (60);
            this._gameWindow.PrincipalWindow.SetVerticalSyncEnabled (true);
            this._gameWindow.KDownHandler += this.CheckGlobalInput;
            this._gameWindow.KDownHandler += this.CheckPlayerInputPressed;
            this._gameWindow.KUpHandler   += this.CheckPlayerInputReleased;

            this._assetManager = new AssetManager ();
            this._assetManager.LoadAssets (@".\GameAssets.zip");

            this._playerObject = new PlayerObject (15.0f) {
                FillColor = Color.Red
            };

            this._sprite =
                new Sprite (this._assetManager.LibraryTextures ["whale"]) {Position = new Vector2f (50.0f, 50.0f)};

            this._gameWindow.ToRender.Add (this._playerObject);
            this._gameWindow.ToRender.Add (this._sprite);

            this._clock = new Clock ();
        }

        private void Update (Single delta) {
            this._gameWindow.Update (delta);
            this._playerObject.Update (delta);
        }

        private void Draw () {
            this._gameWindow.Draw ();
        }

        private void Deinit () {
            this._gameWindow.PrincipalWindow.Close ();
        }

        private void CheckGlobalInput (Object sender, KeyEventArgs e) {
            if (e.Code == Keyboard.Key.Escape) {
                this._running = false;
            }
        }

        private void CheckPlayerInputPressed (Object sender, KeyEventArgs e) {
            this._playerObject.CheckInputPressed (e);
        }

        private void CheckPlayerInputReleased (Object sender, KeyEventArgs e) {
            this._playerObject.CheckInputReleased (e);
        }
    }
}