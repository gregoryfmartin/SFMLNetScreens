using System;
using System.Collections.Generic;
using System.Linq;

namespace SFMLNetScreen {
    public class ScreenManager {
        public Dictionary <ScreenMeta, Screen> Screens { get; }

        public ScreenManager () {
            this.Screens = new Dictionary <ScreenMeta, Screen> () {
                {new ScreenMeta () {
                    ScreenName = "SplashScreen", 
                    CurrentlyUsed = true
                }, new SampleScreen ()}
            };
        }

        public Screen GetCurrentScreen () {
            return (from kvp in this.Screens where kvp.Key.CurrentlyUsed select kvp.Value).FirstOrDefault ();
        }

        public void SetCurrentScreen (String screenName) {
            // Check to see if the desired screen actually exists
            Boolean foundScreen = false;

            foreach (ScreenMeta sm in this.Screens.Keys.Where (sm => sm.ScreenName.Equals (screenName))) {
                foundScreen = true;
            }

            if (foundScreen) {
                foreach (ScreenMeta sm in this.Screens.Keys) {
                    sm.CurrentlyUsed = false;
                }

                foreach (ScreenMeta sm in this.Screens.Keys.Where (sm => sm.ScreenName.Equals (screenName))) {
                    sm.CurrentlyUsed = true;
                }
            }
            else {
                // Do nothing here; not really intuitive
                return;
            }
        }
    }
}