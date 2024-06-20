using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource MainTheme;

    public void PlayMainTheme() 
    {
        if (MainTheme != null) MainTheme.Play();
    } 
    
}
