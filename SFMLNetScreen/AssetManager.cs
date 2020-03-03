using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using SFML.Graphics;

namespace SFMLNetScreen {
    public class AssetManager {
        public Dictionary <String, Texture> LibraryTextures { get; }

        public AssetManager () {
            this.LibraryTextures = new Dictionary <String, Texture> ();
        }

        public void LoadAssets (String archive) {
            try {
                ZipArchive zipArchive = ZipFile.OpenRead (archive);

                foreach (ZipArchiveEntry entry in zipArchive.Entries) {
                    String [] filename = entry.Name.Split (new Char [] {'.'});
                    if (filename.Length > 1) {
                        if (filename [1].Equals ("png") || filename [1].Equals ("jpg") ||
                            filename [1].Equals ("jpeg")) {
                            this.LibraryTextures.Add (filename [0], this.CopyTextureMem (entry));
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine (e.Message);
                Environment.Exit (-99);
            }
        }

        private Texture CopyTextureMem (ZipArchiveEntry entry) {
            Byte [] b;
            using (MemoryStream ms = new MemoryStream ()) {
                entry.Open ().CopyTo (ms);
                b = ms.ToArray ();
            }

            return new Texture (b);
        }
    }
}