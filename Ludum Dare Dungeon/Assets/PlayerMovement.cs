using UnityEngine;
using System.Collections;

public class RandomWep
{
	public string name;
	public int atkB;
	public int maxHealthB;
	public int maxSB;
	public Sprite sA;
	public Sprite sB;
	public int speedB;
	public float expBoost;

	public RandomWep(string name, int atkB, Sprite sA, Sprite sB, int maxHealthB, int maxSB, int speedB, float xpB)
	{
		this.name=name;
		this.atkB=atkB;
		this.sA=sA;
		this.sB=sB;
		this.maxHealthB=maxHealthB;
		this.maxSB=maxSB;
		this.speedB=speedB;
		this.expBoost=xpB;
	}
}

public class PlayerMovement : MonoBehaviour
{
	public Vector3 lastPos;
	public Sprite spr1;
	public Sprite spr2;
	public Sprite atk;
	public GameObject r;
	public GameObject spineProjectile;
	public static int health;
	public static int maxhealth;
	public static int sp;
	public static int maxsp;
	public static int attack;
	public float ticksUntilRegen;
	public static int exp, expGoal;
	public static int level;
	public float atkF;
	public string[] namePart1;
	public string[] namePart2;
	public string[] namePart3;
	public string[] namePart4;
	public Sprite[] broomSticks;
	public Sprite[] broomHeads;
	public Sprite[] swordHandles;
	public Sprite[] swordBlades;
	public GameObject weaponPartA;
	public GameObject weaponPartB;
	public static RandomWep[] items = new RandomWep[2];
	public static int selectedItem = 0;
	public int speed = 20;
	public Sprite blankSprite;
	public RandomWep[] shopItems = new RandomWep[4];
	public RandomWep[] chestItem = new RandomWep[1];
	public static PlayerMovement instance;
	public static int statPoints = 0;
	bool usedDoorOnce = false;

	public void GenerateBroomstick(RandomWep[] items, int selectedItem)
	{
		items[selectedItem].atkB=Random.Range(-PlayerMovement.level, PlayerMovement.level*2)+1;
		items[selectedItem].sA=broomSticks[Random.Range(0, broomSticks.Length)];
		items[selectedItem].sB=broomHeads[Random.Range(0, broomHeads.Length)];
		items[selectedItem].name=namePart1[Random.Range(0, namePart1.Length)]+"Broomstick "+namePart2[Random.Range(0, namePart2.Length)]+""+namePart3[Random.Range(0, namePart3.Length)]+""+namePart4[Random.Range(0, namePart4.Length)];
		items[selectedItem].maxHealthB=0;
		items[selectedItem].maxSB=0;
		items[selectedItem].speedB=0;
		items[selectedItem].expBoost=1;
		if(Random.Range(0, 3)==0)
		{
			if(Random.Range (0, 2)==0)
				items[selectedItem].maxHealthB=Random.Range(-level, level);
			else
				items[selectedItem].maxHealthB=Random.Range(1, level);
		}
		if(Random.Range(0, 5)==0)
		{
			if(Random.Range (0, 2)==0)
				items[selectedItem].maxSB=Random.Range(-level/2, level/2);
			else
				items[selectedItem].maxSB=Random.Range(1, level/2);
		}
		if(Random.Range(0, 2)==0)
		{
			if(Random.Range (0, 2)==0)
				items[selectedItem].speedB=Random.Range(-10, 10);
			else
				items[selectedItem].speedB=Random.Range(1, 10);
		}
		if(Random.Range(0, 4)==0)
		{
			float l2f = (float)level/16f;
			if(Random.Range (0, 2)==0)
				items[selectedItem].expBoost=Random.Range(-0.25f, l2f*2);
			else
				items[selectedItem].expBoost=Random.Range(1, l2f);
		}
	}

	public void GenerateSword(RandomWep[] items, int selectedItem)
	{
		items[selectedItem].atkB=Random.Range(-PlayerMovement.level, PlayerMovement.level*2)+1;
		items[selectedItem].sA=swordHandles[Random.Range(0, swordHandles.Length)];
		items[selectedItem].sB=swordBlades[Random.Range(0, swordBlades.Length)];
		items[selectedItem].name=namePart1[Random.Range(0, namePart1.Length)]+"Sword "+namePart2[Random.Range(0, namePart2.Length)]+""+namePart3[Random.Range(0, namePart3.Length)]+""+namePart4[Random.Range(0, namePart4.Length)];
		items[selectedItem].maxHealthB=0;
		items[selectedItem].maxSB=0;
		items[selectedItem].speedB=0;
		items[selectedItem].expBoost=1;
		if(Random.Range(0, 3)==0)
		{
			if(Random.Range (0, 2)==0)
				items[selectedItem].maxHealthB=Random.Range(-level, level);
			else
				items[selectedItem].maxHealthB=Random.Range(1, level);
		}
		if(Random.Range(0, 5)==0)
		{
			if(Random.Range (0, 2)==0)
				items[selectedItem].maxSB=Random.Range(-level/2, level/2);
			else
				items[selectedItem].maxSB=Random.Range(1, level/2);
		}
		if(Random.Range(0, 2)==0)
		{
			if(Random.Range (0, 2)==0)
				items[selectedItem].speedB=Random.Range(-10, 10);
			else
				items[selectedItem].speedB=Random.Range(1, 10);
		}
		if(Random.Range(0, 4)==0)
		{
			float l2f = (float)level/16f;
			if(Random.Range (0, 2)==0)
				items[selectedItem].expBoost=Random.Range(-0.25f, l2f*2);
			else
				items[selectedItem].expBoost=Random.Range(1, l2f);
		}
	}

	void Start()
	{
		instance=this;
		if(PlayerMovement.maxhealth==0)
		{
			PlayerMovement.maxhealth=10;
			PlayerMovement.maxsp=4;
			PlayerMovement.attack=1;
			PlayerMovement.expGoal=10;
			PlayerMovement.health=PlayerMovement.maxhealth;
			PlayerMovement.sp=PlayerMovement.maxsp;
			PlayerMovement.level=1;
		}
		for(int i = 0; i<items.Length; i++)
		{
			if(items[i]==null)
				items[i] = new RandomWep("Nothing", 0, blankSprite, blankSprite, 0, 0, 0, 1);
		}
		for(int i = 0; i<shopItems.Length; i++)
		{
			shopItems[i] = new RandomWep("Nothing", 0, blankSprite, blankSprite, 0, 0, 0, 1);
			if(Random.Range(0, 2)==0)
				this.GenerateSword(shopItems, i);
			else
				this.GenerateBroomstick(shopItems, i);
		}
	}

	void Update()
	{
		if(this.transform.position.y<=-100)
			health=-1000;
		weaponPartA.GetComponent<SpriteRenderer>().sprite=items[selectedItem].sA;
		weaponPartB.GetComponent<SpriteRenderer>().sprite=items[selectedItem].sB;
		if(health>maxhealth+items[selectedItem].maxHealthB)
			health=maxhealth+items[selectedItem].maxHealthB;
		if(sp>maxsp+items[selectedItem].maxSB)
			sp=maxsp+items[selectedItem].maxSB;
		if(Input.GetKeyUp("1"))
		{
			selectedItem=0;
		}
		if(Input.GetKeyUp("2"))
		{
			selectedItem=1;
		}
		/*if(Input.GetKeyUp("3"))
		{
			selectedItem=2;
		}
		if(Input.GetKeyUp("4"))
		{
			selectedItem=3;
		}
		if(Input.GetKeyUp("5"))
		{
			selectedItem=4;
		}*/
		ticksUntilRegen-=Time.deltaTime*60;
		if(ticksUntilRegen<1)
		{
			ticksUntilRegen=1*60;
			if(health<(maxhealth+items[selectedItem].maxHealthB))
			{
				health+=1+(level/10);
			}
			if(sp<(maxsp+items[selectedItem].maxSB))
			{
				sp+=1+(level/10);
			}
		}
		if(Input.GetButtonUp("Regen"))
		{
			Application.LoadLevel(1);
		}
		if(Input.GetButtonUp("Fire2") && sp>0)
		{
			sp-=1;
			GameObject s = (GameObject)Instantiate(spineProjectile, transform.position, transform.rotation);
			Projectile p = s.GetComponent<Projectile>();
			p.damage=attack;
			p.source=this.gameObject;
			p.speed=20000;
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rh;
			Physics.Raycast(r, out rh);
			if(!rh.Equals(null))
			{
				if(rh.collider!=null)
				{
					p.target=rh.collider.gameObject.transform.position;
				}
				else
				{
					Destroy(s);
				}
			}
			else
			{
				Destroy(s);
			}
			//p.target=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		transform.position+=new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime*(speed+items[selectedItem].speedB), 0, Input.GetAxis("Vertical")*Time.deltaTime*(speed+items[selectedItem].speedB));
		if(Input.GetButtonDown("Jump") && sp>=2)
		{
			sp-=2;
			health+=level;
			if(health>(maxhealth+items[selectedItem].maxHealthB))
				health=(maxhealth+items[selectedItem].maxHealthB);
		}
		atkF-=Time.deltaTime*60;
		if(lastPos!=transform.position)
		{
			if(atkF<1)
			{
				if(r.GetComponent<SpriteRenderer>().sprite!=spr1)
					r.GetComponent<SpriteRenderer>().sprite=spr1;
				else
					r.GetComponent<SpriteRenderer>().sprite=spr2;
				Quaternion qat2 = weaponPartA.transform.rotation;
				qat2.eulerAngles = new Vector3(1.5f, 180f, 0);
				weaponPartA.transform.localRotation = qat2;
				weaponPartA.transform.localPosition = new Vector3(weaponPartA.transform.localPosition.x, 0.564f, weaponPartA.transform.localPosition.z);
			}
			Quaternion qat = Quaternion.identity;
			if(lastPos.x<transform.position.x)
				qat.eulerAngles = new Vector3(0, 0, 0);
			else if(lastPos.x>transform.position.x)
				qat.eulerAngles = new Vector3(0, 180, 0);
			else
				qat.eulerAngles = new Vector3(0, 0, 0);
			r.transform.rotation = qat;
		}
		lastPos=transform.position;
		if(health<1)
		{
			Die();
		}
		if(exp>=expGoal)
		{
			exp-=expGoal;
			//expGoal=(expGoal+(10*(level*level)));
			expGoal=(int)(expGoal*1.6f);
			level+=1;
			statPoints+=3;
			sp=maxsp;
			health=(maxhealth+items[selectedItem].maxHealthB);
		}
	}

	public void Reset()
	{
		items = new RandomWep[2];
		shopItems = new RandomWep[4];
		chestItem = new RandomWep[1];
		exp=0;
		expGoal=10;
		maxhealth=10;
		attack=1;
		level=1;
		maxsp=4;
		sp=maxsp;
		health=maxhealth;
		selectedItem=0;
	}

	public GUIStyle healthBarStyle;
	public GUIStyle HbarBGStyle;
	public GUIStyle XPBarStyle;
	public GUIStyle XbarBGStyle;
	public GUIStyle SPBarStyle;
	public GUIStyle SbarBGStyle;

	void OnGUI()
	{
		GUI.Box(new Rect(10, 10, 200*((float)health/(float)(maxhealth+items[selectedItem].maxHealthB)), 25), "", healthBarStyle);
		GUI.Box(new Rect(10, 10, 200, 25), "", HbarBGStyle);
		GUI.Label(new Rect(10, 10, 200, 25), "HP: "+(float)health+"/"+(float)(maxhealth+items[selectedItem].maxHealthB));
		GUI.Box(new Rect(10, 70, 200*((float)exp/(float)expGoal), 25), "", XPBarStyle);
		GUI.Box(new Rect(10, 70, 200, 25), "", XbarBGStyle);
		GUI.Label(new Rect(10, 70, 200, 25), "XP: "+exp+"/"+expGoal);
		GUI.Label(new Rect(10, 130, 200, 25), "ATK: "+attack);
		GUI.Label(new Rect(10, 220, 200, 25), "Floor: "+((DifficultyManager.timeRunning/2)));
		string itemSTR = items[selectedItem].name+", ATK "+items[selectedItem].atkB;
		if(statPoints>0)
		{
			if(GUI.Button(new Rect(220, 10, 25, 25), "+HP"))
			{
				statPoints-=1;
				maxhealth+=10;
			}
			if(GUI.Button(new Rect(220, 40, 25, 25), "+SP"))
			{
				statPoints-=1;
				maxsp+=4;
			}
			if(GUI.Button(new Rect(150, 130, 25, 25), "+ATK"))
			{
				statPoints-=1;
				attack+=1;
			}
		}
		if(items[selectedItem].maxHealthB!=0)
		{
			itemSTR+=", HP "+items[selectedItem].maxHealthB;
		}
		if(items[selectedItem].maxSB!=0)
		{
			itemSTR+=", SP "+items[selectedItem].maxSB;
		}
		if(items[selectedItem].speedB!=0)
		{
			itemSTR+=", Speed "+items[selectedItem].speedB;
		}
		if(items[selectedItem].expBoost!=1)
		{
			itemSTR+=", Exp* "+items[selectedItem].expBoost;
		}
		GUI.Label(new Rect(10, 160, 400, 50), itemSTR);
		GUI.Label(new Rect(10, 100, 200, 25), "LVL: "+level+", "+statPoints+" Statpoints");
		GUI.Label(new Rect(10, 190, 200, 25), "Speed: "+(items[selectedItem].speedB+this.speed));
		GUI.Box(new Rect(10, 40, 200*((float)sp/(float)(maxsp+items[selectedItem].maxSB)), 25), "", SPBarStyle);
		GUI.Box(new Rect(10, 40, 200, 25), "", SbarBGStyle);
		GUI.Label(new Rect(10, 40, 200, 25), "SP: "+(float)sp+"/"+(float)(maxsp+items[selectedItem].maxSB));
		RaycastHit[] hits = Physics.SphereCastAll(transform.position, 1f, Vector3.forward, 1f);
		foreach(RaycastHit h in hits)
		{
			if(h.collider.tag=="Loot")
			{
				RandomWep w  = h.collider.GetComponent<Chest>().item;
				string lootSTR = w.name+", ATK "+w.atkB;
				if(w.maxHealthB!=0)
				{
					lootSTR+=", HP "+w.maxHealthB;
				}
				if(w.maxSB!=0)
				{
					lootSTR+=", SP "+w.maxSB;
				}
				if(w.speedB!=0)
				{
					lootSTR+=", Speed "+w.speedB;
				}
				if(w.expBoost!=1)
				{
					lootSTR+=", Exp* "+w.expBoost;
				}
				if(GUI.Button(new Rect(10, Screen.height-100, 750, 50), "Take "+lootSTR))
				{
					RandomWep t = items[selectedItem];
					h.collider.GetComponent<Chest>().item=t;
					items[selectedItem]=w;
				}
			}
			if(h.collider.tag=="Shop")
			{
				for(int i = 0; i<shopItems.Length; i++)
				{
					RandomWep w  = shopItems[i];
					string lootSTR = w.name+", ATK "+w.atkB;
					if(w.maxHealthB!=0)
					{
						lootSTR+=", HP "+w.maxHealthB;
					}
					if(w.maxSB!=0)
					{
						lootSTR+=", SP "+w.maxSB;
					}
					if(w.speedB!=0)
					{
						lootSTR+=", Speed "+w.speedB;
					}
					if(w.expBoost!=1)
					{
						lootSTR+=", Exp* "+w.expBoost;
					}
					if(GUI.Button(new Rect(10, Screen.height-(100*i), 750, 50), "Take "+lootSTR))
					{
						RandomWep t = items[selectedItem];
						shopItems[i]=t;
						items[selectedItem]=w;
					}
				}
			}
		}
	}

	void Die()
	{
		transform.FindChild("Renderer").GetComponent<AudioSource>().Play();
		transform.DetachChildren();
		Destroy(this.gameObject);
		health=maxhealth;
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag=="Mob")
		{
			other.collider.gameObject.GetComponent<Mob>().health-=attack+items[selectedItem].atkB;
			other.collider.gameObject.GetComponent<AudioSource>().Play();
			transform.FindChild("Renderer").GetComponent<SpriteRenderer>().sprite=atk;
			Quaternion qat = weaponPartA.transform.rotation;
			qat.eulerAngles = new Vector3(1.5f, 180f, 52.43f);
			weaponPartA.transform.localRotation = qat;
			weaponPartA.transform.localPosition = new Vector3(weaponPartA.transform.localPosition.x, -0.25f, weaponPartA.transform.localPosition.z);
			atkF=20;
			if(other.collider.gameObject.GetComponent<Mob>().health<1)
			{
				int expGained = other.collider.gameObject.GetComponent<Mob>().maxhealth*other.collider.gameObject.GetComponent<Mob>().attack;
				float blah = expGained*items[selectedItem].expBoost;
				exp+=(int) blah;
			}
		}
	}

	public Sprite chestOpenSprite;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Respawn" && !usedDoorOnce)
		{
			usedDoorOnce=true;
			if(DifficultyManager.timeRunning==60)
				Application.LoadLevel(3);
			else
				Application.LoadLevel(1);
			DifficultyManager.timeRunning+=2;
		}
		if(other.tag=="Loot")
		{
			if(other.GetComponent<Chest>().opened==false)
			{
				chestItem[0] = new RandomWep("Nothing", 0, blankSprite, blankSprite, 0, 0, 0, 1);
				if(Random.Range(0, 2)==0)
					this.GenerateSword(chestItem, 0);
				else
					this.GenerateBroomstick(chestItem, 0);
				other.GetComponent<Chest>().item=chestItem[0];
				other.GetComponent<Chest>().opened=true;
				other.GetComponent<SpriteRenderer>().sprite=chestOpenSprite;
			}
		}
	}
}