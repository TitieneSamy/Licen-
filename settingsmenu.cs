using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class settingsmenu : MonoBehaviour {

    public Dropdown resolutiondropdown;
   Resolution[] resolutions;
  void Start()
    {
     
       resolutions= Screen.resolutions;

        resolutiondropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentresolutionindex =0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentresolutionindex = i;
            }
        }

        resolutiondropdown.AddOptions(options);
        resolutiondropdown.value = currentresolutionindex;
        resolutiondropdown.RefreshShownValue();
    }

   
    public void Setquality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }
    public void Setfullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
    public void SEtResolution(int resolutionindex)
    {
        Resolution resolution = resolutions[resolutionindex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
}
