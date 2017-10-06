using NCMB;
using System.Collections.Generic;
using UnityEngine;


public class HighScore
{
	public int highscore;
	public string name;
	public string ObjectId;
	// コンストラクタ -----------------------------------
	public HighScore (int _score, string _name)
	{
		highscore = _score;
		name = _name;
	}

	// サーバーにハイスコアを保存 -------------------------
	public void Save ()
	{
		NCMBObject obj = new NCMBObject ("HighScore");
		obj.Add ("Name", name);
		obj.Add ("Score", highscore);

		if (!PlayerPrefs.HasKey ("ObjectIdKey")) {
			Debug.Log("abc");
			obj.SaveAsync ((NCMBException e) => {      
				if (e != null) {
					//エラー処理
				} else {
					//成功時の処理
					PlayerPrefs.SetString ("ObjectIdKey", obj.ObjectId);
				}                   
			});
		} else {
			obj.ObjectId = PlayerPrefs.GetString ("ObjectIdKey");
			obj.SaveAsync ((NCMBException e) => {      
				if (e != null) {
					//エラー処理
				} else {
					//成功時の処理
				}                   
			});
		}
	}



	// サーバーからハイスコアを取得  -----------------
	public void Fetch ()
	{
		// データストアの「HighScore」クラスから、Nameをキーにして検索
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
		query.WhereEqualTo ("Name", name);
		query.FindAsync ((List<NCMBObject> objList, NCMBException e) => {

			//検索成功したら  
			if (e == null) {
				// ハイスコアが未登録だったら
				if (objList.Count == 0) {
					NCMBObject obj = new NCMBObject ("HighScore");
					obj ["Name"] = name;
					obj ["Score"] = 0;
					obj.SaveAsync ();
					highscore = 0;
				} 
					// ハイスコアが登録済みだったら
					else {
					highscore = System.Convert.ToInt32 (objList [0] ["Score"]); 
				}
			}
		});
	}

}
