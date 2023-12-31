﻿using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace MikanXRBeatSaber.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }

        // Must be 'virtual' if you want BSIPA to detect a value change and save the config automatically.
		public virtual float NoteNearAlphaDist { get; set; } = 2.7f;
		public virtual float NoteFarAlphaDist { get; set; } = 3.0f;
		public virtual float CameraScaleTime { get; set; } = 1.0f;
		public virtual string SceneOriginAnchorName { get; set; } = "beatSaberOrigin";

		/// <summary>
		/// This is called whenever BSIPA reads the config from disk (including when file changes are detected).
		/// </summary>
		public virtual void OnReload()
        {
        }

        /// <summary>
        /// Call this to force BSIPA to update the config file. This is also called by BSIPA if it detects the file was modified.
        /// </summary>
        public virtual void Changed()
        {
        }

        /// <summary>
        /// Call this to have BSIPA copy the values from <paramref name="other"/> into this config.
        /// </summary>
        public virtual void CopyFrom(PluginConfig other)
        {
            // This instance's members populated from other
        }
    }
}