﻿using System;
using System.Reflection;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;
using MikanXRBeatSaber.Logging;
using MikanXRBeatSaber.Zenject.Internal;
using MikanXRBeatSaber.Zenject;
using Mikan;

namespace MikanXRBeatSaber
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public static string HarmonyId = "com.BrendanWalker.beatsaber.MikanXRBeatSaber";

        public string Name => "MikanXRBeatSaber";
        public string Version => "0.0.1";

        // TODO: If using Harmony, uncomment and change YourGitHub to the name of your GitHub account, or use the form "com.company.project.product"
        //       You must also add a reference to the Harmony assembly in the Libs folder.
        // public const string HarmonyId = "com.github.YourGitHub.MikanXRBeatSaber";
        // internal static readonly HarmonyLib.Harmony harmony = new HarmonyLib.Harmony(HarmonyId);

        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal static MikanXRBeatSaberController PluginController { get { return MikanXRBeatSaberController.Instance; } }
        internal static MikanManager MikanClientInstance { get { return MikanManager.Instance; } }

        internal static Harmony HarmonyInstance { get; private set; }

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public Plugin(IPALogger ipaLogger)
        {
            Instance = this;
            Plugin.Log = ipaLogger;
            Plugin.Log?.Debug("Logger initialized.");

            HarmonyInstance = new Harmony(HarmonyId);

            // can't inject at this point so just create it
            ILogger<Plugin> logger = new IPALogger<Plugin>(ipaLogger);

            ZenjectHelper.Init(ipaLogger);
            ZenjectHelper.BindSceneComponent<PCAppInit>();
            ZenjectHelper.Register<MikanXRBeatSaberInstaller>().WithArguments(ipaLogger).OnMonoInstaller<PCAppInit>();
        }

        #region BSIPA Config
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Plugin.Log?.Debug("Config loaded");
        }
        #endregion


        /// <summary>
        /// Called when the plugin is enabled (including when the game starts if the plugin is enabled).
        /// </summary>
        [OnEnable]
        public void OnEnable()
        {
            GameObject gameObject = new GameObject("MikanXRBeatSaberPlugin");
            gameObject.AddComponent<MikanXRBeatSaberController>();
            gameObject.AddComponent<MikanManager>();
            gameObject.AddComponent<MikanLogger_Plugin>();
            ApplyHarmonyPatches();
        }

        /// <summary>
        /// Called when the plugin is disabled and on Beat Saber quit. It is important to clean up any Harmony patches, GameObjects, and Monobehaviours here.
        /// The game should be left in a state as if the plugin was never started.
        /// Methods marked [OnDisable] must return void or Task.
        /// </summary>
        [OnDisable]
        public void OnDisable()
        {
            if (PluginController != null)
                GameObject.Destroy(PluginController);
            if (MikanClientInstance != null)
                GameObject.Destroy(MikanClientInstance);
            RemoveHarmonyPatches();
        }

        /// <summary>
        /// Attempts to apply all the Harmony patches in this assembly.
        /// </summary>
        internal static void ApplyHarmonyPatches()
        {
            try
            {
                Plugin.Log?.Debug("Applying Harmony patches.");
                HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                Plugin.Log?.Error("Error applying Harmony patches: " + ex.Message);
                Plugin.Log?.Debug(ex);
            }
        }

        /// <summary>
        /// Attempts to remove all the Harmony patches that used our HarmonyId.
        /// </summary>
        internal static void RemoveHarmonyPatches()
        {
            try
            {
                // Removes all patches with this HarmonyId
                HarmonyInstance.UnpatchAll(HarmonyId);
            }
            catch (Exception ex)
            {
                Plugin.Log?.Error("Error removing Harmony patches: " + ex.Message);
                Plugin.Log?.Debug(ex);
            }
        }
    }
}
