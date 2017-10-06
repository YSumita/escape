using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NCMB;

public class rankscenemanager : MonoBehaviour {

	public GameObject buttonsound;
	float timer;
	int mover;
	bool push;
	bool getrank = false;
	float gosa;
	GameObject rankpref;


	List<HighScore> topRankersList = new List<HighScore> ();

	// Use this for initialization
	void Start () {
		timer = -1f;
		mover = 0;
		push = true;
		fetchTopRankers ();
	
	
	}
	
	// Update is called once per frame
	void Update () {

		if (getrank) {
			for (int i = 0; i < topRankersList.Count; i++) {
				rankpref = GameObject.Find ("Rank (" + (i+1) + ")");
				rankpref.transform.FindChild ("RankName").GetComponent<Text> ().text = topRankersList [i].name;
				rankpref.transform.FindChild ("RankScore").GetComponent<Text> ().text = topRankersList [i].highscore.ToString ();
			}
			getrank = false;
		}




		if (timer >= 0) {
			timer += Time.deltaTime;
		}

		if (timer >= 0.3) {
			if (mover == 1) {
				SceneManager.LoadScene ("StartScene");
			}
		}
	}

	public void homebutton(){
		if (push) {
			mover = 1;
			timer = 0f;
			Instantiate (buttonsound);
			push = false;
		}
	}

	// サーバーからトップ5を取得 ---------------    
	public void fetchTopRankers()
	{
		// データストアの「HighScore」クラスから検索
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
		query.OrderByDescending ("Score");
		query.Limit = 20;
		query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {

			if (e != null) {
				//検索失敗時の処理
			} else {
				//検索成功時の処理
				List<HighScore> list = new List<HighScore>();
				// 取得したレコードをHighScoreクラスとして保存
				foreach (NCMBObject obj in objList) {
					int    s = System.Convert.ToInt32(obj["Score"]);
					string n = System.Convert.ToString(obj["Name"]);
					list.Add( new HighScore( s, n ) );
				}
				topRankersList = list;
				getrank = true;
			}


		});
	}

}