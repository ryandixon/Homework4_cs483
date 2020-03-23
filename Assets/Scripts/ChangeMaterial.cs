using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{
    public Texture[] albedoTextures;
    public Texture[] bumpTextures;
    public MeshRenderer rend;
    public Slider red;
    public Slider green;
    public Slider blue;
    public int currentAlbedoTexture = 1;
    public int currentBumpTexture = 1;
    // Start is called before the first frame update
    void Start()
    {
        rend.material.EnableKeyword ("_NORMALMAP");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }

    public void OnEdit() {
        Color color = rend.material.color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        rend.material.color = color;
        rend.material.SetColor("_EmissionColor", color);
    }

    public void ChangeAlbedo(){      
        if (albedoTextures.Length == 0)
            return;

        currentAlbedoTexture++;

        if(currentAlbedoTexture == albedoTextures.Length + 1)
            currentAlbedoTexture = 1;

        print(currentAlbedoTexture);

        rend.material.SetTexture("_MainTex", albedoTextures[currentAlbedoTexture - 1]);
        
    }

    public void ChangeNormal(){
        if (bumpTextures.Length == 0)
            return;
        
        currentBumpTexture++;

        if(currentBumpTexture == bumpTextures.Length +1)
            currentBumpTexture = 1;

        print(currentBumpTexture);
        rend.material.SetTexture("_BumpMap", bumpTextures[currentBumpTexture - 1]);
    }
}
