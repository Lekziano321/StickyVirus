using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isMusicPaused = false;
    private float musicStartPosition = 0f; // Menyimpan posisi awal musik

    public Button pauseButton; // Ganti dengan referensi ke tombol PauseBTN Anda di Unity
    public Button resumeButton; // Ganti dengan referensi ke tombol ResumeBTN Anda di Unity
    public GameObject continuePanel; // Tambahkan referensi ke GameObject ContinuePanel Anda di Unity

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Menghubungkan fungsi PauseMusic() dengan tombol PauseBTN
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(PauseMusic);
        }

        // Menghubungkan fungsi ResumeMusic() dengan tombol ResumeBTN
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeMusic);
        }
    }

    private void Update()
    {
        // Periksa apakah ContinuePanel aktif
        if (continuePanel != null && continuePanel.activeSelf)
        {
            // Matikan semua AudioSource
            audioSource.Pause();
        }
    }

    private void PauseMusic()
    {
        if (audioSource.isPlaying)
        {
            // Simpan posisi awal musik sebelum dijeda
            musicStartPosition = audioSource.time;
            audioSource.Pause();
            isMusicPaused = true;
        }
        else
        {
            // Lanjutkan musik dari posisi awal
            audioSource.time = musicStartPosition;
            audioSource.Play();
            isMusicPaused = false;
        }
    }

    private void ResumeMusic()
    {
        if (isMusicPaused)
        {
            // Lanjutkan pemutaran dari posisi awal musik
            audioSource.time = musicStartPosition;
            audioSource.Play();
            isMusicPaused = false;
        }
    }
}
