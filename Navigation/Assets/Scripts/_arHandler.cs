using UnityEngine;
using System.Collections;

public class _arHandler : MonoBehaviour{
	
	#region private member variables
	public static string mTrackableName;
	public static int index; 
	public UILabel Label_info;
	private bool mShowScreen = true; 
	private ArrayList mTitleList = new ArrayList();
	private ArrayList mTextList = new ArrayList(); 
	//private GameObject momotos_guiText;
	#endregion	
	
	// Use this for initialization, Button inUN
	void Start()
	{
		mTitleList.Add ("");
		//1
		mTitleList.Add("牛津學堂");
		//2
		mTitleList.Add("大禮拜堂");
		//3
		mTitleList.Add("教士會館");
		//4
		mTitleList.Add("姑娘樓");
		//5
		mTitleList.Add("馬偕行醫");
		//6
		mTitleList.Add("三H學院(學生宿舍大樓)");
		//7
		mTitleList.Add("活動中心");
		//8
		mTitleList.Add("數理管理大樓與體育館");
		//9
		mTitleList.Add("牧師樓");
		//10
		mTitleList.Add("馬偕故居");
		 
		mTextList.Add ("");
		//1
		mTextList.Add ("漢名為「理學堂大書院」，是加拿大基督教長老教會傳教士"+
		               "馬偕博士(Rev. George Leslie Mackay)於1882年在台灣淡"+
		               "水創立的西式現代化學校。馬偕博士於台灣傳教期間，深感"+
		               "創設新式學校之重要，乃於1880年回加拿大募款，獲其故鄉"+
		               "安大略省牛津郡報紙《前哨評論》 (Sentinel Review)新聞"+
		               "社之刊載並大力發起募款活動，得到各方熱烈迴響，共募得"+
		               "加幣6,215元，作為其建校基金。1881年，馬偕博士重返淡"+
		               "水，擇定牛津學堂現址，親手規劃、監工，興建校舍。"+
		               "1882年7月26日如期峻工，取名「理學堂大書院」。因感懷"+
		               "其故鄉加拿大牛津郡鄉親之盛情襄贊，英文乃命名為"+
		               "Oxford College，故後人稱之為牛津學堂。");
		//2
		mTextList.Add("於1997年完工，樓層分地下三層、地上四層、屋突三層，合計"+
		              "十層。當中，大禮拜堂可容納最多約1500人，小禮拜堂則可容"+
		              "納最多約180人，而階梯教室可容納最多約160人。大禮拜堂也"+
		              "設有由荷蘭管風琴廠佩爾斯（PELS & VAN LEEUWEN）以手"+
		              "工製造的巨型管風琴，是台灣最高兼為首台設有32呎音管的管"+
		              "風琴。它的外部採用哥德式的設計風格，而內部則以傳統設計"+
		              "為本，以配合上述禮拜堂的建築設計。它與周邊建築共同組成"+
		              "具有古蹟風貌的建築群。");
		//3
		mTextList.Add("建於1875年，為馬偕博士所設計的西班牙風格建築，其時用作" +
		              "宣教師宿舍,近代作為前校長公館,現已規劃為真理大學教士會" +
		              "館,作為紀念在台宣教士之用外,也提供餐飲,文化導覽,藝文空" +
		              "間等服務。");
		//4
		mTextList.Add ("建於1906年，為當時淡水女學校校長金仁里姑娘、高哈拿姑娘" +
		               "兩位女宣教師的宿舍。「姑娘」是台灣教會對外國單身女宣教" +
		               "師的尊稱，而曾經生活於「姑娘樓」的還有黎瑪美、安義理、" +
		               "杜道理和德明利等姑娘，在二次大戰期間，姑娘樓一度成為淡" +
		               "水中學男生宿舍，並改名為「朱雀寮」。戰後，除了重回淡水" +
		               "的杜道理、德明利姑娘之外，在淡江中學服務的李仁美姑娘、" +
		               "高瑪烈姑娘也都居住於此。 1965年因真理大學創校所需，最" +
		               "後一位女宣教師徳明利姑娘搬往淡江中學後，「姑娘樓」便成" +
		               "為真理大學校長室，校方對本建築一直視為古蹟加以維護保存。");
		//5
		mTextList.Add ("");
		//6
		mTextList.Add("為提升學生住宿品質，將原有宿舍拆除改建。除採歷史建築及塑造匾域整體建築特色之外，所有宿舍所有宿舍採套房式設計，" +
		              "並擁有獨立空調系統。每棟地面層（1F）設置殘障者使用的宿舍及舍監宿舍，有效照顧行動不便之學生。間數為333間，總容納人數可達1153人。" +
		              "人道樓為男宿，內有軍訓室。幽默樓為女宿，內有衛生保健組。謙遜樓為女宿(中間最大棟)，內有諮商輔導組、服務學習組與宿舍辦公室。");
		//7
		mTextList.Add("於1980年完工，總建坪5530.02㎡。樓層分地上七層、地下三層，內有音樂廳、牛津演講廳、演奏廳、社團辦公室、音樂系…等。");
		//8
		mTextList.Add("數位管理大樓：建於1985年，地上十層、地下三層，四周自然景觀美不勝收。" +
		              "內設兩學部教室、教師研究室與電腦中心、視聽中心。現為數理暨管理學院大樓。" +
		              "體育館：建於1990年。該建築自地平面向下25.5公尺，總建坪4000坪，非但無礙自然景觀，其工程之艱鉅與龐大堪稱亞洲第一。館內共分四層，" +
		              "分別設有網球館、籃球館、排球館、羽球館、桌球館、武道館及體操館等完備專科體育設施，學生勤奮讀書之餘，無論晴雨更可藉以鍛鍊強健體魄。");
		

		//9
		mTextList.Add("請看影片。\n");
		//10
		mTextList.Add("俗稱小白宮，是馬偕博士在1875年所建，他於此結婚生子，也在此臨終。" +
		              "西斑牙式的白堊孤廊建築，是馬偕親自設計督工的，建材由廈門購入。明治年間，乃木總督曾來此拜訪參觀。馬偕故居在二次大戰初期改為「安樂寮」" +
		              "，供失去家庭的婦女住宿靜養，後來淡水中學租作學寮，稱為「白虎寮」，戰爭末期充作彈藥庫。二次大戰後，馬偕次女偕以利續住，直到年老。" +
		              "後來淡專(真理大學前身)設校，成為淡江英文老師宿舍 。1965年後曾經作為淡專圖書館、實習旅館，以及外籍老師宿舍。" +
		              "1994年作為本校真理大學國際學術交流會館，由總務處事務組負責經營管理之業務，提供國內外學者或貴賓住宿。" +
		              "2007年更名為馬偕古厝，由總務處古蹟管理及校園美化組負責經營管理之業務");
		
		 
		//==================================================================================
	}
	
	
	
	// Update is called once per frame
	void Update () {
		

		
	}

	void OnGUI()
	{
			index = 0; 
			if (mTrackableName.Equals ("test_3"))
				index = 2;
			else if (mTrackableName.Equals ("aaa"))
				index = 1;
			else if (mTrackableName.Equals ("test_3"))
				index = 2;
			else if (mTrackableName.Equals ("ok5"))
				index = 3;
			else if (mTrackableName.Equals ("ok3"))
				index = 4;
			else if (mTrackableName.Equals ("test_5"))
				index = 5;
			else if (mTrackableName.Equals ("6"))
				index = 6;
			else if (mTrackableName.Equals ("7"))
				index = 7; 
			Label_info.text=mTitleList [index]+"\n"+mTextList [index];
	}
}
