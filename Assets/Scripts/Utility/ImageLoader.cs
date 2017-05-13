using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImageLoader : MonoBehaviour {
    private static Dictionary<string, Sprite> _imagesPool = new Dictionary<string, Sprite>();
	public static Sprite LoadSprite(string url)
    {
        if (!_imagesPool.ContainsKey(url))
        {
            _imagesPool[url] = Resources.Load<Sprite>(url);
        }
        if (_imagesPool[url] == null)
        {
            LoggingManager.AddErrorToLog("Didnt found image "+url);
        }
        return _imagesPool[url];
    }
}
