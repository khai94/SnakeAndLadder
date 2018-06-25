using UnityEngine;

/// <summary>
/// This class controls the Music in the Scene
/// </summary>
public class MusicController : MonoBehaviour
{
    /// <summary>
    /// Set the list of music in the Unity3D Editor
    /// </summary>
    public AudioClip[] Music;

    /// <summary>
    /// In the Editor, assign this to the object carrying the Audio Source
    /// </summary>
    public AudioSource Source;

    /// <summary>
    /// The current song that is playing, we are using -1 for "none"
    /// </summary>
    private int _index = -1;

    /// <summary>
    /// Goes to the next song
    /// </summary>
    public void PlayNextSong()
    {
        if (!CheckSource()) // Make sure an Audio Source was specified in the Editor
            return;

        if (_index >= (Music.Length - 1)) // Loop to the first song if needed, keeping in mind Arrays start 0, but Length starts counting at 1
            _index = 0;
        else
            _index += 1;

        PlayByID(_index); // Rather than recreate working code, simply loop through our existing play function
    }

    /// <summary>
    /// Goes back to the previous song
    /// </summary>
    public void PlayLastSong()
    {
        if (!CheckSource()) // Make sure an Audio Source was specified in the Editor
            return;

        if (_index <= 0) // Loop to the last song if needed, keeping in mind Arrays start 0, but Length starts counting at 1
            _index = Music.Length - 1;
        else
            _index -= 1;

        PlayByID(_index); // Rather than recreate working code, simply loop through our existing play function
    }

    /// <summary>
    /// Plays a song by the ID (number of the array)
    /// </summary>
    /// <param name="songIndex"></param>
    public void PlayByID(int songIndex)
    {
        if (!CheckSource()) // Make sure an Audio Source was specified in the Editor
            return;

        if (songIndex > (Music.Length - 1)) // Check if the song is even in the list!
        {
            Debug.LogError("MusicController:PlayByID > Song index invalid " + songIndex);
            return;
        }

        Source.Stop(); // Stop any existing music, should happen anyways, but ensures we reset to frame 0 on all dvices
        Source.clip = Music[songIndex]; // Set the song to play
        _index = songIndex; // Mark our index
        Source.Play(); // Begin playing the song
    }

    /// <summary>
    /// Pauses any playing music
    /// </summary>
    public void Pause()
    {
        if (!CheckSource()) // Make sure an Audio Source was specified in the Editor
            return;

        Source.Pause();
    }

    /// <summary>
    /// Resumes any playing music
    /// </summary>
    public void Resume()
    {
        if (!CheckSource()) // Make sure an Audio Source was specified in the Editor
            return;

        Source.Play();
    }

    /// <summary>
    /// Toggles between Play and Pause
    /// </summary>
    public void TogglePause()
    {
        if (!CheckSource()) // Make sure an Audio Source was specified in the Editor
            return;

        if (Source.isPlaying)
            Pause();
        else
            Resume();
    }

    /// <summary>
    /// Stops any music currently playing
    /// </summary>
    public void Stop()
    {
        if (!CheckSource()) // Make sure an Audio Source was specified in the Editor
            return;

        Source.Stop();
        _index = -1;
    }

    /// <summary>
    ///  Checks if the AudioSource is assigned in the scene
    /// </summary>
    /// <returns>True if it exists, False if it doesn't</returns>
    private bool CheckSource()
    {
        if (Source != null) return true;

        Debug.LogError("MusicController:CheckSource > Audio Source is not set in the editor.");
        return false;
    }

}
