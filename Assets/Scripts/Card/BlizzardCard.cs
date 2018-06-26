using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlizzardCard : Card{
    public override void ExecuteEffect(int i)
    {
        effect = (Effect)i;

        switch (effect)
        {
            case Effect.Slow:
                Debug.Log("Slow");
                break;
        }
    }

    
	public class StatusEffect {

		public float time;
		public string name;

		public StatusEffect (string _name, float _time) {
			name = _name;
			time = _time;
		}
	}


		//List of effects
		List<StatusEffect> statuses;

		void Start () {
			statuses = new List<StatusEffect>();
		}

		void Update () {
			//Add status effect, press 1, 2, or 3
			{
				statuses.Add(new StatusEffect("SpeedDown", 2));
				Debug.Log(statuses[statuses.Count-1].name+" added!");
			}

			//Lower status time
			for(int i=0; i<statuses.Count; i++){
				statuses[i].time -= Time.deltaTime;
				if(statuses[i].time <= 0){
					//Remove status and do any needed removal code
					Debug.Log(statuses[i].name+" ended! ("+(statuses.Count-1)+" remaining)");
					statuses.RemoveAt(i);
				}
			}
		}
    
}

