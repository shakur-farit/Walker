using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Data;
using UnityEngine;

namespace Infrastructure.Services.Randomizer
{
	public class SaveService : ISaveService
	{
		private readonly string savePath = Path.Combine(Application.persistentDataPath, "savefile.json");


		public void SaveProgress(Progress progress)
		{
			try
			{
				string json = JsonUtility.ToJson(progress);
				File.WriteAllText(savePath, json);
				Debug.Log("Progress saved.");
			}
			catch (Exception e)
			{
				Debug.LogError("Failed to save progress: " + e.Message);
			}
		}

		public Progress LoadProgress()
		{
			if (File.Exists(savePath))
			{
				try
				{
					string json = File.ReadAllText(savePath);
					Progress progress = JsonUtility.FromJson<Progress>(json);
					Debug.Log("Progress loaded.");
					return progress;
				}
				catch (Exception e)
				{
					Debug.LogError("Failed to load progress: " + e.Message);
					return new Progress();
				}
			}

			Debug.LogWarning("Save file not found. Returning null.");
			return null;
		}

		public void DeleteProgress()
		{
			if (File.Exists(savePath))
			{
				try
				{
					File.Delete(savePath);
					Debug.Log("Progress deleted.");
				}
				catch (Exception e)
				{
					Debug.LogError("Failed to delete progress: " + e.Message);
				}
			}
			else
			{
				Debug.LogWarning("Save file not found.");
			}
		}
	}
}