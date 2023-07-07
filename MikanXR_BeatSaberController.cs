using CustomAvatar;
using MikanXRBeatSaber.Utilities;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using MikanXRBeatSaber.Configuration;
using Mikan;
using MikanXR;

namespace MikanXRBeatSaber
{
    public class MikanXRBeatSaberController : MonoBehaviour
    {
        public static readonly string MenuSceneName = "MainMenu";
        public static readonly string PostSongMenuSceneName = "MainMenu";
        public static readonly string GameSceneName = "GameCore";
        public static readonly string HealthWarningSceneName = "HealthWarning";
        public static readonly string EmptyTransitionSceneName = "EmptyTransition";
        public static readonly string CreditsSceneName = "Credits";
        public static readonly string BeatmapEditorSceneName = "BeatmapEditor";
        readonly string[] MainSceneNames = { GameSceneName, CreditsSceneName, BeatmapEditorSceneName };

        public static readonly string GlowShaderName = "BeatSaber/Unlit Glow";
        public static readonly string GlowPropertyName = "_Glow";

        private bool lastMainSceneWasNotMenu = false;

        private GameScenesManager gameScenesManager = null;

        public static MikanXRBeatSaberController Instance { get; private set; }
        public SaberManager GameSaberManager { get; private set; }
        public VRController LeftVRController { get; private set; }
        public VRController RightVRController { get; private set; }
        public VRIKManager AvatarIKManager { get; private set; }
        public TrackingHelper RoomTrackingUtils { get; private set; }
        public GameObject MikanSceneObject { get; private set; }
        public GameObject MikanCameraObject { get; private set; }
        public BeatSaberUtilities BSUtilities { get; private set; }

        //public List<Transform> ColorANotes = new List<Transform>();
        //public List<Transform> ColorBNotes = new List<Transform>();
        //public Color ColorA = Color.red;
        //public Color ColorB = Color.blue;

        private void SceneManager_activeSceneChanged(Scene oldScene, Scene newScene)
        {           
            try
            {
                Plugin.Log?.Info($"MikanXRBeatSaberController: Active scene changed: {oldScene.name} -> {newScene.name}");

                if (oldScene.name == GameSceneName || oldScene.name == MenuSceneName)
                {
                    DespawnMikanScene();
                    UnbindSceneComponents();
                }

                if (newScene.name == GameSceneName)
                {
                    //InvokeAll(gameSceneActive);

                    gameScenesManager = Resources.FindObjectsOfTypeAll<GameScenesManager>().FirstOrDefault();

                    if (gameScenesManager != null)
                    {
                        gameScenesManager.transitionDidFinishEvent -= GameSceneLoadedCallback;
                        gameScenesManager.transitionDidFinishEvent += GameSceneLoadedCallback;
                    }
                }
                else if (newScene.name == MenuSceneName)
                {
                    gameScenesManager = Resources.FindObjectsOfTypeAll<GameScenesManager>().FirstOrDefault();

                    //InvokeAll(menuSceneActive);

                    if (gameScenesManager != null)
                    {

                        if (oldScene.name == EmptyTransitionSceneName && !lastMainSceneWasNotMenu)
                        {
                            //     Utilities.Logger.log.Info("Fresh");

                            gameScenesManager.transitionDidFinishEvent -= OnMenuSceneWasLoadedFresh;
                            gameScenesManager.transitionDidFinishEvent += OnMenuSceneWasLoadedFresh;
                        }
                        else
                        {
                            gameScenesManager.transitionDidFinishEvent -= OnMenuSceneWasLoaded;
                            gameScenesManager.transitionDidFinishEvent += OnMenuSceneWasLoaded;
                        }
                    }

                    lastMainSceneWasNotMenu = false;
                }

                if (MainSceneNames.Contains(newScene.name))
                {
                    lastMainSceneWasNotMenu = true;
                }
            }
            catch (Exception e)
            {
                Plugin.Log?.Error(e);
            }
        }

        private void OnMenuSceneWasLoaded(ScenesTransitionSetupDataSO transitionSetupData, DiContainer diContainer)
        {
            gameScenesManager.transitionDidFinishEvent -= OnMenuSceneWasLoaded;
            //InvokeAll(menuSceneLoaded);
        }

        private void OnMenuSceneWasLoadedFresh(ScenesTransitionSetupDataSO transitionSetupData, DiContainer diContainer)
        {
            gameScenesManager.transitionDidFinishEvent -= OnMenuSceneWasLoadedFresh;

            //var levelDetailViewController = Resources.FindObjectsOfTypeAll<StandardLevelDetailViewController>().FirstOrDefault();
            //levelDetailViewController.didChangeDifficultyBeatmapEvent += delegate (StandardLevelDetailViewController vc, IDifficultyBeatmap beatmap) { InvokeAll(difficultySelected, vc, beatmap); };

            //var characteristicSelect = Resources.FindObjectsOfTypeAll<BeatmapCharacteristicSegmentedControlController>().FirstOrDefault();
            //characteristicSelect.didSelectBeatmapCharacteristicEvent += delegate (BeatmapCharacteristicSegmentedControlController controller, BeatmapCharacteristicSO characteristic) { InvokeAll(characteristicSelected, controller, characteristic); };

            //var packSelectViewController = Resources.FindObjectsOfTypeAll<LevelSelectionNavigationController>().FirstOrDefault();
            //packSelectViewController.didSelectLevelPackEvent += delegate (LevelSelectionNavigationController controller, IBeatmapLevelPack pack) { InvokeAll(levelPackSelected, controller, pack); };
            //var levelSelectViewController = Resources.FindObjectsOfTypeAll<LevelCollectionViewController>().FirstOrDefault();
            //levelSelectViewController.didSelectLevelEvent += delegate (LevelCollectionViewController controller, IPreviewBeatmapLevel level) { InvokeAll(levelSelected, controller, level); };

            //InvokeAll(earlyMenuSceneLoadedFresh, transitionSetupData);
            //InvokeAll(menuSceneLoadedFresh);
            //InvokeAll(lateMenuSceneLoadedFresh, transitionSetupData)

            if (BindMenuSceneComponents())
            {
                BeatSaberUtilities bsUtilities = diContainer.Resolve<BeatSaberUtilities>();

                SpawnMikanScene(bsUtilities);

                //if (AvatarIKManager != null)
                //{
                //    PluginUtils.SetMaterialFloatValueRecursive(AvatarIKManager.gameObject, GlowShaderName, GlowPropertyName, 1.0f);
                //}
            }
        }

        private void GameSceneLoadedCallback(ScenesTransitionSetupDataSO transitionSetupData, DiContainer diContainer)
        {
            RoomTrackingUtils = diContainer.Resolve<TrackingHelper>();

            // Prevent firing this event when returning to menu
            var gameScenesManager = Resources.FindObjectsOfTypeAll<GameScenesManager>().FirstOrDefault();
            gameScenesManager.transitionDidFinishEvent -= GameSceneLoadedCallback;

            var pauseManager = diContainer.TryResolve<PauseController>();
            if (pauseManager != null)
            {
                pauseManager.didResumeEvent += PauseManager_didResumeEvent;
                pauseManager.didPauseEvent += PauseManager_didPauseEvent;
            }

            var beatmapObjectManager = diContainer.TryResolve<BeatmapObjectManager>();
            if (beatmapObjectManager != null)
            {
                beatmapObjectManager.noteWasSpawnedEvent += BeatmapObjectManager_noteWasSpawnedEvent;
                beatmapObjectManager.noteWasDespawnedEvent += BeatmapObjectManager_noteWasDespawnedEvent;
                beatmapObjectManager.noteWasCutEvent += BeatmapObjectManager_noteWasCutEvent;
                beatmapObjectManager.noteWasMissedEvent += BeatmapObjectManager_noteWasMissedEvent;
            }

            var scoreController = diContainer.TryResolve<ScoreController>();
            if (scoreController != null)
            {
                scoreController.multiplierDidChangeEvent += ScoreController_multiplierDidChangeEvent;
                scoreController.scoreDidChangeEvent += ScoreController_scoreDidChangeEvent;
            }

            var saberCollisionManager = Resources.FindObjectsOfTypeAll<ObstacleSaberSparkleEffectManager>().LastOrDefault(x => x.isActiveAndEnabled);
            if (saberCollisionManager != null)
            {
                saberCollisionManager.sparkleEffectDidStartEvent += SaberCollisionManager_sparkleEffectDidStartEvent;
                saberCollisionManager.sparkleEffectDidEndEvent += SaberCollisionManager_sparkleEffectDidEndEvent;
            }

            var gameEnergyCounter = Resources.FindObjectsOfTypeAll<GameEnergyCounter>().LastOrDefault(x => x.isActiveAndEnabled);
            if (gameEnergyCounter != null)
            {
                gameEnergyCounter.gameEnergyDidReach0Event += GameEnergyCounter_gameEnergyDidReach0Event;
                gameEnergyCounter.gameEnergyDidChangeEvent += GameEnergyCounter_gameEnergyDidChangeEvent;
            }

            var transitionSetup = Resources.FindObjectsOfTypeAll<StandardLevelScenesTransitionSetupDataSO>().FirstOrDefault();
            if (transitionSetup)
            {
                transitionSetup.didFinishEvent -= TransitionSetup_didFinishEvent;
                transitionSetup.didFinishEvent += TransitionSetup_didFinishEvent;
            }

            if (BindGameSceneComponents())
            {                
                BeatSaberUtilities bsUtilities = diContainer.Resolve<BeatSaberUtilities>();

                SpawnMikanScene(bsUtilities);

                //if (AvatarIKManager != null)
                //{
                //    PluginUtils.SetMaterialFloatValueRecursive(AvatarIKManager.gameObject, GlowShaderName, GlowPropertyName, 1.0f);
                //}
            }
        }

        private void TransitionSetup_didFinishEvent(
            StandardLevelScenesTransitionSetupDataSO setupData, 
            LevelCompletionResults results)
        {
            //ColorA = setupData.colorScheme.saberAColor;
            //ColorB = setupData.colorScheme.saberBColor;
        }

        private void GameEnergyCounter_gameEnergyDidChangeEvent(float obj)
        {
        }

        private void GameEnergyCounter_gameEnergyDidReach0Event()
        {
        }

        private void SaberCollisionManager_sparkleEffectDidEndEvent(SaberType obj)
        {
        }

        private void SaberCollisionManager_sparkleEffectDidStartEvent(SaberType obj)
        {
        }

        private void PauseManager_didPauseEvent()
        {
        }

        private void PauseManager_didResumeEvent()
        {
        }

        private void ScoreController_scoreDidChangeEvent(int arg1, int arg2)
        {
        }

        private void ScoreController_multiplierDidChangeEvent(int arg1, float arg2)
        {
        }

        private void BeatmapObjectManager_noteWasDespawnedEvent(NoteController noteController)
        {
        }

        private void BeatmapObjectManager_noteWasMissedEvent(NoteController noteController)
        {
        }

        private void BeatmapObjectManager_noteWasCutEvent(NoteController noteController, in NoteCutInfo noteCutInfo)
        {
        }

        private void BeatmapObjectManager_noteWasSpawnedEvent(NoteController noteController)
        {
            Plugin.Log?.Info("MikanXRBeatSaberController: Note Spawned");

            //PluginUtils.PrintObjectMaterials(noteController.gameObject);
            PluginUtils.SetMaterialFloatValueRecursive(noteController.gameObject, GlowShaderName, GlowPropertyName, 0.0f);

            //if (noteController.noteData.colorType == ColorType.ColorA)
            //{
            //    ColorANotes.Add(noteController.noteTransform);
            //}
            //else if (noteController.noteData.colorType == ColorType.ColorB)
            //{
            //    ColorBNotes.Add(noteController.noteTransform);
            //}
        }

        private void UpdateNotes()
        {
            //float nearAlphaDist = PluginConfig.Instance.NoteNearAlphaDist;
            //float farAlphaDist = PluginConfig.Instance.NoteFarAlphaDist;

            //foreach (Transform noteTransform in ColorANotes)
            //{
            //    if (noteTransform != null)
            //    {
            //        UpdateNoteAlpha(noteTransform, nearAlphaDist, farAlphaDist);
            //    }
            //}

            //foreach (Transform noteTransform in ColorBNotes)
            //{
            //    if (noteTransform != null)
            //    {
            //        UpdateNoteAlpha(noteTransform, nearAlphaDist, farAlphaDist);
            //    }
            //}
        }

        private void UpdateNoteAlpha(Transform noteTransform, float nearAlphaDist, float farAlphaDist)
        {
            Vector3 notePosition = noteTransform.position;
            Quaternion noteOrientation = noteTransform.rotation;
            RoomTrackingUtils.ApplyInverseRoomAdjust(ref notePosition, ref noteOrientation);

            if (notePosition.z <= farAlphaDist)
            {
                float newAlpha = Mathf.Clamp01((farAlphaDist - notePosition.z) / (farAlphaDist - nearAlphaDist));

                PluginUtils.SetMaterialFloatValueRecursive(noteTransform.gameObject, GlowShaderName, GlowPropertyName, newAlpha);
            }
        }

        bool BindGameSceneComponents()
        {
            Plugin.Log?.Info("MikanXRBeatSaberController: Binding Game Scene Components");

            GameObject localPlayerGameCore = GameObject.Find("LocalPlayerGameCore");
            //PluginUtils.PrintObjectTree(localPlayerGameCore, "");
            //PluginUtils.PrintComponents(localPlayerGameCore);
            if (localPlayerGameCore == null)
            {
                Plugin.Log?.Warn("MikanXRBeatSaberController: Failed to find LocalPlayerGameCore game object, bailing!");
                return false;
            }

            Transform GameOrigin = localPlayerGameCore.transform.Find("Origin");
            //PluginUtils.PrintComponents(GameOrigin?.gameObject);
            if (GameOrigin == null)
            {
                Plugin.Log?.Warn("MikanXRBeatSaberController: Failed to find Origin transform, bailing!");
                return false;
            }

            GameObject vrGameCore = GameOrigin?.Find("VRGameCore")?.gameObject;
            //PluginUtils.PrintComponents(vrGameCore);
            if (vrGameCore == null)
            {
                Plugin.Log?.Warn("MikanXRBeatSaberController: Failed to find VRGameCore game object, bailing!");
                return false;
            }

            // Fetch the game saber manager to get the left and right sabers
            GameSaberManager = vrGameCore.GetComponent<SaberManager>();

            AvatarIKManager = FindObjectOfType<VRIKManager>();
            if (AvatarIKManager == null)
            {
                Plugin.Log?.Warn("MikanXRBeatSaberController: Failed to find VRIKManager");
            }

            return true;
        }

        bool BindMenuSceneComponents()
        {
            Plugin.Log?.Info("MikanXRBeatSaberController: Binding Menu Scene Components");

            GameObject menuCore = GameObject.Find("MenuCore");
            //GameObject menuCore = PluginUtils.FindGameObjectRecursiveInScene(loadedScene, "MenuCore");

            //PluginUtils.PrintComponents(menuCore);
            if (menuCore == null)
            {
                Plugin.Log?.Warn("MikanXRBeatSaberController: Failed to find MenuCore game object, bailing!");
                return false;
            }

            Transform GameOrigin = menuCore.transform.Find("Origin");
            //PluginUtils.PrintObjectTree(GameOrigin?.gameObject, "");
            //PluginUtils.PrintComponents(GameOrigin?.gameObject);
            if (GameOrigin == null)
            {
                Plugin.Log?.Warn("MikanXRBeatSaberController: Failed to find Origin transform, bailing!");
                return false;
            }

            Transform menuControllers = GameOrigin?.Find("MenuControllers");
            //PluginUtils.PrintComponents(menuControllers?.gameObject);
            if (menuControllers == null)
            {
                Plugin.Log?.Warn("MikanXRBeatSaberController: Failed to find MenuControllers game object, bailing!");
                return false;
            }

            GameObject controllerLeft = menuControllers?.Find("ControllerLeft")?.gameObject;
            //PluginUtils.PrintComponents(controllerLeft?.gameObject);
            if (controllerLeft == null)
            {
                Plugin.Log?.Warn("MikanXRBeatSaberController: Failed to find ControllerLeft game object, bailing!");
                return false;
            }

            GameObject controllerRight = menuControllers?.Find("ControllerRight")?.gameObject;
            //PluginUtils.PrintComponents(controllerRight);
            if (controllerRight == null)
            {
                Plugin.Log?.Warn("MikanXRBeatSaberController: Failed to find ControllerRight game object, bailing!");
                return false;
            }

            LeftVRController = controllerLeft.GetComponent<VRController>();
            RightVRController = controllerRight.GetComponent<VRController>();

            AvatarIKManager = FindObjectOfType<VRIKManager>();
            if (AvatarIKManager == null)
            {
                Plugin.Log?.Warn("MikanXRBeatSaberController: Failed to find VRIKManager");
            }

            return true;
        }

        private void UnbindSceneComponents()
        {
            GameSaberManager = null;
            LeftVRController = null;
            RightVRController = null;
            AvatarIKManager = null;
            //ColorANotes.Clear();
            //ColorBNotes.Clear();
        }

        void SpawnMikanScene(BeatSaberUtilities bsUtilities)
        {
            if (MikanSceneObject == null)
            {
                Plugin.Log?.Info("MikanXRBeatSaberController: Spawning Mikan XR Scene");
				MikanSceneObject = new GameObject(
	                "MikanSceneObject",
	                new System.Type[] { 
                        typeof(MikanScene), 
                        typeof(MikanSceneEventHandler) });

                MikanScene sceneComponent= MikanSceneObject.GetComponent<MikanScene>();
                sceneComponent.SceneOriginAnchorName= PluginConfig.Instance.SceneOriginAnchorName;

                MikanSceneEventHandler sceneEventHandler = MikanSceneObject.GetComponent<MikanSceneEventHandler>();
                sceneEventHandler.CameraScaleTime= PluginConfig.Instance.CameraScaleTime;

                if (bsUtilities != null)
                {
					Plugin.Log?.Info($"MikanXRBeatSaberController: Attaching to room origin");

					MikanSceneObject.transform.position = bsUtilities.roomCenter;
					MikanSceneObject.transform.rotation = bsUtilities.roomRotation;

                    // Listen for room origin recenter so we can fixup the mikan scene
					BSUtilities = bsUtilities;
					BSUtilities.roomAdjustChanged += OnRoomOriginChanged;
				}
                else
                {
                    Plugin.Log?.Info($"MikanXRBeatSaberController: No room origin found");
                }

                // Create and attach the MikanCamera to the Mikan Scene
                SpawnMikanCamera(MikanSceneObject);

                // Tell the scene to look for the new camera we spawned
                sceneComponent.BindSceneCamera();

                // If we are already connected to Mikan,
                // tell the scene to fetch anchors, setup scene transform, etc
                // Otherwise wait for MikanManager to tell the scene about the connection
                if (MikanClient.Mikan_GetIsConnected())
                {
                    sceneComponent.HandleMikanConnected();
                }
			}
            else
            {
                Plugin.Log?.Info("MikanXRBeatSaberController: Ignoring Spawn DMX Scene request. Already spawned");
            }
        }

		public void OnRoomOriginChanged(Vector3 roomCenter, Quaternion roomRotation)
		{
			Plugin.Log?.Info($"MikanXRBeatSaberController: Room Origin Changed");

			if (MikanSceneObject != null)
			{
				MikanSceneObject.transform.position = roomCenter;
				MikanSceneObject.transform.rotation = roomRotation;
			}
		}

		void DespawnMikanScene()
        {
            Plugin.Log?.Info("MikanXRBeatSaberController: Unloading MikanXR Scene");

			if (BSUtilities != null)
			{
				BSUtilities.roomAdjustChanged -= OnRoomOriginChanged;
				BSUtilities = null;
			}

            DespawnMikanCamera();

			if (MikanSceneObject != null)
            {
                Destroy(MikanSceneObject);
                MikanSceneObject= null;
            }
        }

		public void SpawnMikanCamera(GameObject mikanSceneObject)
		{
			if (MikanCameraObject == null)
			{
				Plugin.Log?.Info($"MikanClient: Spawning Mikan camera");

				MikanCameraObject = new GameObject(
					"MikanCameraObject",
					new System.Type[] { 
                        typeof(Camera),
                        typeof(MikanCamera)});

				Camera cameraComponent = MikanCameraObject.GetComponent<Camera>();
				cameraComponent.stereoTargetEye = StereoTargetEyeMask.None;
				cameraComponent.backgroundColor = new Color(0, 0, 0, 0);
				cameraComponent.clearFlags = CameraClearFlags.SolidColor;
				cameraComponent.forceIntoRenderTexture = true;
				cameraComponent.transform.parent = mikanSceneObject.transform;

                MikanCamera captureComponent = MikanCameraObject.GetComponent<MikanCamera>();

                // If we are connected to Mikan, 
                // copy the camera intrinsics (fov, pixel dimensions, etc) to the Unity Camera
                // If not, wait for Mikan to connect and we'll copy the settings then
                captureComponent.HandleCameraIntrinsicsChanged();

                // If we have a valid render target descriptor (defined video source),
                // create a valid render target from the descriptor
                // If not, wait for Mikan to connect and we'll create it then
                if (MikanManager.Instance.RenderTargetDescriptor != null)
                {
					captureComponent.RecreateRenderTarget(MikanManager.Instance.RenderTargetDescriptor);
				}
                else
                {
                    Plugin.Log?.Warn($"MikanXRBeatSaberController: No valid render target descriptor. Not connected to Mikan yet?");
                }
			}
			else
			{
				Plugin.Log?.Info($"MikanXRBeatSaberController: Ignoring camera spawn request. Already spawned.");
			}
		}

		public void DespawnMikanCamera()
		{
			if (MikanCameraObject != null)
			{
				Plugin.Log?.Info($"MikanXRBeatSaberController: Despawn Mikan camera");
				Destroy(MikanCameraObject);
				MikanCameraObject = null;
			}
			else
			{
				Plugin.Log?.Info($"MikanXRBeatSaberController: Ignoring camera de-spawn request. Already despawned.");
			}
		}

		// These methods are automatically called by Unity, you should remove any you aren't using.
		#region Monobehaviour Messages
		/// <summary>
		/// Only ever called once, mainly used to initialize variables.
		/// </summary>
		private void Awake()
        {
            // For this particular MonoBehaviour, we only want one instance to exist at any time, so store a reference to it in a static property
            //   and destroy any that are created while one already exists.
            if (Instance != null)
            {
                Plugin.Log?.Warn($"MikanXRBeatSaberController: Instance of {GetType().Name} already exists, destroying.");
                GameObject.DestroyImmediate(this);
                return;
            }
            
            GameObject.DontDestroyOnLoad(this); // Don't destroy this object on scene changes
            Instance = this;
            //Plugin.Log?.Debug($"{name}: Awake()");

            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }

        /// <summary>
        /// Only ever called once on the first frame the script is Enabled. Start is called after any other script's Awake() and before Update().
        /// </summary>
        private void Start()
        {
        }

        /// <summary>
        /// Called every frame if the script is enabled.
        /// </summary>
        private void Update()
        {
            if (GameSaberManager != null)
            {
                UpdateNotes();
            }
        }

        /// <summary>
        /// Called every frame after every other enabled script's Update().
        /// </summary>
        private void LateUpdate()
        {

        }

        /// <summary>
        /// Called when the script becomes enabled and active
        /// </summary>
        private void OnEnable()
        {

        }

        /// <summary>
        /// Called when the script becomes disabled or when it is being destroyed.
        /// </summary>
        private void OnDisable()
        {

        }

        /// <summary>
        /// Called when the script is being destroyed.
        /// </summary>
        private void OnDestroy()
        {
            SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;

            Plugin.Log?.Debug($"MikanXRBeatSaberController: {name}: OnDestroy()");
            if (Instance == this)
                Instance = null; // This MonoBehaviour is being destroyed, so set the static instance property to null.

        }
        #endregion
    }
}
