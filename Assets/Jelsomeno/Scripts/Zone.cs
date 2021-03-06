using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jelsomeno
{

    public class Zone : SlipstreamJumper.Zone
    {

        new public static ZoneInfo info = new ZoneInfo()
        {
            zoneName = " Zone Rocco",
            creator = "Rocco Jelsomeno",
            sceneFile = "ZoneJelsomeno"
        };

        //singleton
        public static Zone main;

        public AABB player;

        // one variable to hold all of the platforms 
        private List<AABB> platforms = new List<AABB>();

        public List<AABB> powerups = new List<AABB>();



        private void Awake()
        {
            if(main != null)
            {
                Destroy(gameObject);

            }
            else
            {
                main = this;
            }
        }

        private void OnDestroy()
        {
            if (main == this) main = null;
        }

        void LateUpdate()
        {

            PlayerMovement pm = player.GetComponent<PlayerMovement>();

            foreach(AABB box in platforms)
            {
                if (player.OverlapCheck(box))
                {
                    pm.ApplyFix(player.FindFix(box));
                }
            }

            foreach(AABB power in powerups)
            {
                if (player.OverlapCheck(power))
                {
                    //player collides with powerup!
                    // do something
                    SpringBlock sb = power.GetComponent<SpringBlock>();
                    if (sb)
                    {
                        sb.PlayerHit(pm);
                    }


                }
            }


        }

        public void AddPlatform(AABB platform)
        {
            platforms.Add(platform);

        }

        public void RemovePlatform(AABB platform)
        {
            platforms.Remove(platform);
        }
     
           
       

    }
}
