using Mikan;
using MikanXR;
using UnityEngine;

namespace MikanXRBeatSaber.Logging
{
	public class MikanLogger_Plugin : MonoBehaviour, IMikanLogger
	{
		public void Log(MikanLogLevel mikanLogLevel, string log_message)
		{
			switch (mikanLogLevel)
			{
			case MikanLogLevel.Trace:
				Plugin.Log?.Trace($"Trace | {log_message}");
				break;
			case MikanLogLevel.Debug:
				Plugin.Log?.Debug($"DEBUG | {log_message}");
				break;
			case MikanLogLevel.Info:
				Plugin.Log?.Info($"INFO | {log_message}");
				break;
			case MikanLogLevel.Warning:
				Plugin.Log?.Warn($"WARNING | {log_message}");
				break;
			case MikanLogLevel.Error:
				Plugin.Log?.Error($"ERROR | {log_message}");
				break;
			case MikanLogLevel.Fatal:
				Plugin.Log?.Critical($"FATAL | {log_message}");
				break;
			}
		}
	}
}
