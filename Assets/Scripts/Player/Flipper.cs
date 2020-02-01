using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public bool m_FacingRight = true;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Flips players sprite
        if (!pauseMenu.gameIsPausedPublic)
        {
            if (difference.x > 0 && !m_FacingRight)
            {
                Flip();

            }
            else if (difference.x < 0 && m_FacingRight)
            {
                Flip();
            }
        }
    }
    private void Flip()
	{
		m_FacingRight = !m_FacingRight;
		Vector3 charScale = transform.localScale;
		charScale.x *= -1;
		transform.localScale = charScale;
	}
}
