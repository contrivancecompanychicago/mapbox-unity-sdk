﻿namespace Mapbox.Unity.Ar
{
	using UnityEngine;
	using Mapbox.Unity.Location;
	using System;

	//using System.Threading.Tasks;
	public class DeviceOrientationLocalizationStrategy : ComputeARLocalizationStrategy
	{
		public override event Action<Alignment> OnLocalizationComplete;

		public override void ComputeLocalization(CentralizedLocator centralizedARLocator)
		{
			Debug.Log("First Alignment");
			var deviceHeading = LocationProviderFactory.Instance.DefaultLocationProvider.CurrentLocation.DeviceOrientation;
			Debug.Log("First alignment heading: " + deviceHeading);
			Alignment alignment = new Alignment
			{
				Position = centralizedARLocator.CurrentMap.transform.position,
				Rotation = deviceHeading
			};

			Debug.Log("Alignment complete");
			OnLocalizationComplete(alignment);
		}
	}
}
