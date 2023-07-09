using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    private int cur = 0;

    public float speed = 0.3f;
    public AudioClip death;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        // Waypoint not reached yet? then move closer
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else
        {
            cur = (cur + 1) % waypoints.Length;
        }

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    private void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            audioSource.PlayOneShot(death);
            Destroy(co.gameObject); // Destroy Pacman

            // Transition to game over scene after a delay
            StartCoroutine(TransitionToGameOverScene());
        }
    }

    private IEnumerator TransitionToGameOverScene()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        SceneManager.LoadScene("GameOverScene"); // Replace "GameOverScene" with the actual name of your game over scene
    }
}
