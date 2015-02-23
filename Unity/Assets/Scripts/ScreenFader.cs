using UnityEngine;

public class ScreenFader : MonoBehaviour
{

    public float fadeinspeed;
    public float fadeoutspeed;
    public int visibleframes;

    private bool fadein = true;
    private bool fadeout = false;
    private int counter = 0;

    private SpriteRenderer spriterenderer;

    void Start()
    {

        spriterenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        if (fadein)
        {

            // Lerp the colour of the texture between itself and transparent
            spriterenderer.color = Color.Lerp(spriterenderer.color, Color.clear, fadeinspeed * Time.deltaTime);

            // If the texture is almost clear, stop the fadein
            if (spriterenderer.color.a <= 0.1f)
            {
                
                spriterenderer.color = Color.clear;
                spriterenderer.enabled = false;

                fadein = false;
            }

        }
        else if (fadeout)
        {

            // Make sure the texture is enabled
            spriterenderer.enabled = true;

            // Lerp the colour of the texture between itself and black
            spriterenderer.color = Color.Lerp(spriterenderer.color, Color.black, fadeoutspeed * Time.deltaTime);

            // If the screen is almost black, load the menu
            if (spriterenderer.color.a >= 0.99f)
            {

                Application.LoadLevel("MainMenu");

            }

        }
        else
        {

            counter++;

            if (counter == visibleframes)
            {

                fadeout = true;

            }

        }

    }

}
