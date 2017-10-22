using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NCMB;

public class rankscenemanager : MonoBehaviour {

	public GameObject buttonsound;
	bool[] getrank = new bool[6];

	GameObject rankpref1;
	GameObject rankpref2;
	GameObject rankpref3;


	List<HighScore> topRankersList1 = new List<HighScore> ();
	List<HighScore> topRankersList2 = new List<HighScore> ();
	List<HighScore> topRankersList3 = new List<HighScore> ();

	public GameObject NormalButton;
	public GameObject HardButton;
	public GameObject CrazyButton;
	public GameObject NormalButtonPushed;
	public GameObject HardButtonPushed;
	public GameObject CrazyButtonPushed;

	public GameObject Rank1;
	public GameObject Rank2;
	public GameObject Rank3;

	public GameObject normalownrank;
	public GameObject hardownrank;
	public GameObject crazyownrank;

	int[] playernum;
	int[] ownrank;

	// Use this for initialization
	void Start () {
		ownrank = new int[3];
		playernum = new int[3];
		fetchTopRankers ();
		fetchnumofplayer ();

	}
	
	// Update is called once per frame
	void Update () {

		if (getrank[0]&&getrank[1]&&getrank[2]&&getrank[3]&&getrank[4]&&getrank[5]) {

			for (int i = 0; i < topRankersList1.Count; i++) {
				rankpref1 = GameObject.Find ("Rank1/Viewport/Content/Rank (" + (i + 1) + ")");
				rankpref1.transform.FindChild ("RankName").GetComponent<Text> ().text = topRankersList1 [i].name;
				rankpref1.transform.FindChild ("RankScore").GetComponent<Text> ().text = topRankersList1 [i].highscore.ToString ();
			}
			for (int i = 0; i < topRankersList2.Count; i++) {
				rankpref2 = GameObject.Find ("Rank2/Viewport/Content/Rank (" + (i + 1) + ")");
				rankpref2.transform.FindChild ("RankName").GetComponent<Text> ().text = topRankersList2 [i].name;
				rankpref2.transform.FindChild ("RankScore").GetComponent<Text> ().text = topRankersList2 [i].highscore.ToString ();
			}
			for (int i = 0; i < topRankersList3.Count; i++) {
				rankpref3 = GameObject.Find ("Rank3/Viewport/Content/Rank (" + (i + 1) + ")");
				rankpref3.transform.FindChild ("RankName").GetComponent<Text> ().text = topRankersList3 [i].name;
				rankpref3.transform.FindChild ("RankScore").GetComponent<Text> ().text = topRankersList3 [i].highscore.ToString ();
			}

			Debug.Log (playernum [0]);
			Debug.Log (playernum [1]);
			Debug.Log (playernum [2]);

			for (int i = 1; i < 4; i++) {
				GameObject.Find ("yourRank" + i + "/numberofplayers").GetComponent<Text>().text = "/" + playernum [i - 1];
			}

			getrank [0] = false;
			getrank [1] = false;
			getrank [2] = false;
			getrank [3] = false;

			Rank1.SetActive (true);
			Rank2.SetActive (false);
			Rank3.SetActive (false);
			normalownrank.SetActive (true);
			hardownrank.SetActive (false);
			crazyownrank.SetActive (false);


//			normalownrank.GetComponent<numberofplayers>().text = "/" + fetchnumofplayer (1);
//			hardownrank.text = "/" + fetchnumofplayer (2);
//			crazyownrank.text = "/" + fetchnumofplayer (2);



		}
	}
	public void homebutton(){
		Instantiate (buttonsound);
		StartCoroutine ("home");
	}

	public void normalbutton(){
		Instantiate (buttonsound);
		NormalButton.SetActive (false);
		NormalButtonPushed.SetActive (true);
		HardButton.SetActive (true);
		HardButtonPushed.SetActive (false);
		CrazyButton.SetActive (true);
		CrazyButtonPushed.SetActive (false);
		Rank1.SetActive (true);
		Rank2.SetActive (false);
		Rank3.SetActive (false);
		normalownrank.SetActive (true);
		hardownrank.SetActive (false);
		crazyownrank.SetActive (false);

	}

	public void hardbutton(){
		Instantiate (buttonsound);
		NormalButton.SetActive (true);
		NormalButtonPushed.SetActive (false);
		HardButton.SetActive (false);
		HardButtonPushed.SetActive (true);
		CrazyButton.SetActive (true);
		CrazyButtonPushed.SetActive (false);
		Rank1.SetActive (false);
		Rank2.SetActive (true);
		Rank3.SetActive (false);
		normalownrank.SetActive (false);
		hardownrank.SetActive (true);
		crazyownrank.SetActive (false);
	}

	public void crazybutton(){
		Instantiate (buttonsound);
		NormalButton.SetActive (true);
		NormalButtonPushed.SetActive (false);
		HardButton.SetActive (true);
		HardButtonPushed.SetActive (false);
		CrazyButton.SetActive (false);
		CrazyButtonPushed.SetActive (true);
		Rank1.SetActive (false);
		Rank2.SetActive (false);
		Rank3.SetActive (true);
		normalownrank.SetActive (false);
		hardownrank.SetActive (false);
		crazyownrank.SetActive (true);
	}








	// サーバーからトップ5を取得 ---------------    
	public void fetchTopRankers()
	{
		// データストアの「HighScore」クラスから検索
		NCMBQuery<NCMBObject> query1 = new NCMBQuery<NCMBObject> ("HighScore");
		query1.OrderByDescending ("Score1");
		query1.Limit = 20;
		query1.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {

			if (e != null) {
				//検索失敗時の処理
			} else {
				//検索成功時の処理
				List<HighScore> list = new List<HighScore>();
				// 取得したレコードをHighScoreクラスとして保存
				foreach (NCMBObject obj in objList) {
					int    s = System.Convert.ToInt32(obj["Score1"]);
					string n = System.Convert.ToString(obj["Name"]);

					list.Add( new HighScore( s, n ,1) );
				}
				topRankersList1 = list;
				getrank[0]=true;
			}


		});
		NCMBQuery<NCMBObject> query2 = new NCMBQuery<NCMBObject> ("HighScore");
		query2.OrderByDescending ("Score2");
		query2.Limit = 20;
		query2.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {

			if (e != null) {
				//検索失敗時の処理
			} else {
				//検索成功時の処理
				List<HighScore> list = new List<HighScore>();
				// 取得したレコードをHighScoreクラスとして保存
				foreach (NCMBObject obj in objList) {
					int    s = System.Convert.ToInt32(obj["Score2"]);
					string n = System.Convert.ToString(obj["Name"]);
					list.Add( new HighScore( s, n ,2) );
				}
				topRankersList2 = list;
				getrank[1]=true;
			}


		});
		NCMBQuery<NCMBObject> query3 = new NCMBQuery<NCMBObject> ("HighScore");
		query3.OrderByDescending ("Score3");
		query3.Limit = 20;
		query3.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {

			if (e != null) {
				//検索失敗時の処理
			} else {
				//検索成功時の処理
				List<HighScore> list = new List<HighScore>();
				// 取得したレコードをHighScoreクラスとして保存
				foreach (NCMBObject obj in objList) {
					int    s = System.Convert.ToInt32(obj["Score3"]);
					string n = System.Convert.ToString(obj["Name"]);
					list.Add( new HighScore( s, n ,3) );
				}
				topRankersList3 = list;
				getrank[2]=true;
			}


		});

	}

	void fetchnumofplayer(){
			
			NCMBQuery<NCMBObject> query1 = new NCMBQuery<NCMBObject> ("HighScore");
			query1.WhereNotEqualTo ("Score" + 1, null);
			query1.CountAsync ((int count1, NCMBException e) => {
				if (e != null) {
					//検索失敗時の処理
				} else {
					playernum[0]=count1;
					getrank[3]=true;
				}
			});

		NCMBQuery<NCMBObject> query2 = new NCMBQuery<NCMBObject> ("HighScore");
		query2.WhereNotEqualTo ("Score" + 2, null);
		query2.CountAsync ((int count2, NCMBException e) => {
			if (e != null) {
				//検索失敗時の処理
			} else {
				playernum[1]=count2;
				getrank[4]=true;
			}
		});

		NCMBQuery<NCMBObject> query3 = new NCMBQuery<NCMBObject> ("HighScore");
		query3.WhereNotEqualTo ("Score" + 3, null);
		query3.CountAsync ((int count3, NCMBException e) => {
			if (e != null) {
				//検索失敗時の処理
			} else {
				playernum[2]=count3;
				getrank[5]=true;
			}
		});

		//for文でやろうとしたが、iの更新がcountの取得よりも早く、count取得時にはi=4でArrayエラーが起こるためfor文を分解した
	}



	IEnumerator home(){
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("StartScene");
	}

}