using UnityEngine;

namespace Views.Tank
{
    public class Entity: MonoBehaviour
    {
        public float Health { get; set; }
        public float Armor { get; set;}

        private float _startHealth;

        public void StartHealth()
        {
            _startHealth = Health;
        }

        void OnGUI(){
            //the hp bar background location on screen
            Rect rcBg = new Rect(0,0,60,14);
            //the current HP bar 
            Rect rcCurrent = new Rect(0,0,((Health)/_startHealth)*56,8);
 
            //the important part : where this object is located in my screen
            Vector3 point = Camera.main.WorldToScreenPoint(new Vector3(
                transform.position.x,
                transform.position.y+1f,
                transform.position.z)
            );
         
            //had to add the substraction since my Y axis were revesed (
            rcBg.y = Screen.height-point.y;  
    
            //do some ugly hardcoding so the bar is pretty and centered
            rcBg.x = point.x-30;
            rcCurrent.x=rcBg.x+2;
            rcCurrent.y=rcBg.y+3;
            
            GUI.Box(rcBg,"");
            GUI.Box(rcCurrent,"");
        }
    }
}