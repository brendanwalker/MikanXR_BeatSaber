using System.Collections;
using Mikan;
using UnityEngine;

public class MikanSceneEventHandler : MonoBehaviour
{
	private float _cameraScaleTime = 1.0f;
    public float CameraScaleTime
    {
        get { return _cameraScaleTime; }
        set { _cameraScaleTime= value; }
    }

    private MikanManager _mikanManager;
    private MikanScene _mikanScene;
    private MikanScriptContent _scriptContent;
    private Coroutine _currentRoutine;

    // Start is called before the first frame update
    void Start()
    {
        _mikanManager= MikanManager.Instance;
        if (_mikanManager != null)
        {            
            _mikanManager.OnMessageEvent += OnMikanMessage;
		}

		_mikanScene = this.gameObject.GetComponent<MikanScene>();
		if (_mikanScene != null && _scriptContent != null)
		{
			float startScale = _scriptContent.cameraZoomInCurve.Evaluate(0);

			_mikanScene.CameraPositionScale = startScale;
		}
	}

	void OnDisable()
	{
		Cleanup();
	}

    void Cleanup()
    {
        HaltCameraAnimation();

		_mikanManager = MikanManager.Instance;
		if (_mikanManager != null)
		{
            _mikanManager.OnMessageEvent -= OnMikanMessage;
		}
	}

	public void OnMikanMessage(string message)
    {
        if (message == "resetCameraZoom")
        {
            HaltCameraAnimation();

            if (_mikanScene != null && _scriptContent != null)
            {
                float startScale = _scriptContent.cameraZoomInCurve.Evaluate(0);

				_mikanScene.CameraPositionScale = startScale;
			}
        }
        else if (message == "startCameraZoom")
        {
            PlayCameraAnimation();
        }
    }

    public void HaltCameraAnimation()
    {
		if (_currentRoutine != null)
		{
			StopCoroutine(_currentRoutine);
			_currentRoutine = null;
		}
	}

	public void PlayCameraAnimation()
    {
        HaltCameraAnimation();

        if (_scriptContent != null)
        {
			_currentRoutine = StartCoroutine(CameraAnimCoroutine());
		}
	}

    private IEnumerator CameraAnimCoroutine()
    {
        float startScale = _scriptContent.cameraZoomInCurve.Evaluate(0);
        float endScale = _scriptContent.cameraZoomInCurve.Evaluate(1);

        if (_mikanScene != null)
            _mikanScene.CameraPositionScale= startScale;

        for (float time = 0; time < _cameraScaleTime; time += Time.unscaledDeltaTime)
        {
            float t = time / _cameraScaleTime;
            float scaleValue = _scriptContent.cameraZoomInCurve.Evaluate(t);

            if (_mikanScene != null)
                _mikanScene.CameraPositionScale= scaleValue;

            yield return null;
        }

        if (_mikanScene != null)
            _mikanScene.CameraPositionScale= endScale;

        _currentRoutine = null;
    }
}
