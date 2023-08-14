using BepInEx;

using UnityEngine;

using UnityEngine.SceneManagement;

using NightUtils;

using System.IO;
using System;

namespace Squidward
{
    [BepInPlugin("com.squidwardinreal.archiverxp", "SquidwardInReal", "0.1")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {"com.squidwardinreal.archiverxp"} is loaded!");
            SceneManager.LoadScene("SnackFalcon");
            SceneManager.sceneLoaded += OnSceneLoaded;

        }

//

        void Squidward()
        {

            var Squidward = new GameObject("squidward");

            var HeySquidward = GameObject.Find("Player/Pivot/SpriteHolder/MaeRig");

            var AHHHHHHH = Squidward.AddComponent<SpriteRenderer>();

            var BOOM = SpriteLoader.LoadSprite(Path.Combine(Paths.PluginPath, "SquidwardInReal/Sprites/squiddy.png"));

            var HEADSHOT = Sprite.Create(BOOM, new Rect(0.0f, 0.0f, BOOM.width, BOOM.height), new Vector2(0.5f, 0.2f), 100.0f);

            var super_mario = GameObject.Find("MaeRig");

            //WORKAROUND:
            super_mario.transform.SetPositionX(999);
            super_mario.transform.SetPositionY(999);

            AHHHHHHH.sprite = HEADSHOT;

            AHHHHHHH.size = new Vector2(0.5873f, 0.5327f);

            AHHHHHHH.transform.position = HeySquidward.transform.position;
            //new Vector2(0.0f, 0.0f);

            Squidward.transform.parent = HeySquidward.transform.parent;

            Squidward.transform.localPosition = new Vector3(0f, -0.513f, 0f);

            Squidward.transform.localScale = new Vector3(0.5964f, 0.5673f, 1);
        }

        void Update()
        {
            var Ward = GameObject.Find("Player/Pivot/SpriteHolder/squidward");

            var Sponge = Ward.GetComponent<SpriteRenderer>();

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Sponge.flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Sponge.flipX = false;
            }
        }


        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            var Squid = GameObject.Find("Player/Pivot/SpriteHolder/MaeRig");

            if (Squid == null)
            {
                Console.WriteLine("No Squiddy to attach to");
            }
            else
            {
                Squidward();
            }
        }

    }
}
