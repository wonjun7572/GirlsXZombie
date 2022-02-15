using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAdsSpawner : MonoBehaviour {

	public string gameID;

	void Awake() {
		if (Advertisement.isSupported) {
			//Advertisement.allowPrecache = true;
			Advertisement.Initialize (gameID);
		} else {
			Debug.Log("Platform not supported");
		}
	}

    [System.Obsolete]
    public void OnShowAdsFM( float amount) {	
		// Show with default zone, pause engine and print result to debug log
		Advertisement.Show("rewardedVideoZone", new ShowOptions {
			//pause = true,
			resultCallback = result => {			
				//Here code for success video watch.	
				//you can add coins here!.
			}
		});
	}

    [System.Obsolete]
    public void OnShowAdsSimple() {	
		// Show with default zone, pause engine and print result to debug log
		Advertisement.Show("rewardedVideoZone", new ShowOptions {
			//pause = true,
			resultCallback = result => {			
				//Here code for success video watch.
			}
		});
	}
}
